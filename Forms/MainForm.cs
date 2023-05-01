using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using NeteaseMusicDownloadWinForm.Utils;
using System.IO;
using System.Text.Json.Nodes;
using System.Collections.Generic;

namespace NeteaseMusicDownloadWinForm
{
    public partial class MainForm : UIForm
    {
        //记录歌曲的下载状态
        private static readonly Dictionary<string, string> DownloadStatusDict = new Dictionary<string, string>();
        //告诉大家默认保存地址
        public MainForm()
        {
            InitializeComponent();
            downloadPathLabel.Text = $"默认保存地址：{Download.SavePath}";
        }
        //加载登录界面，监听是否登录成功；或者加载退出登录界面
        private void LoginButtonClick(object sender, EventArgs e)
        {
            if (loginButton.Text.Contains("欢迎"))
            {
                N9stTip("是否退出登录？");
            }
            else 
            {
                LoginForm loginForm = new LoginForm();
                //监控是否登录成功，登录成功去获取用户名
                loginForm.FinishLoginEvent += new LoginForm.FinishLogin(MainForm_Load);
                //加载loginForm
                loginForm.ShowDialog();
            }
        }
        //退出程序
        private void ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //最小化
        private void WindowStateMinimized(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //尝试获取用户名（自动登录）
        private async void MainForm_Load(object sender, EventArgs e)
        {
            loginButton.Text = await Login.ReturnUserName();
        }
        //开始搜索
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (loginButton.Text.Contains("尚未登录"))
            {
                N9stTip("请先扫码登录网易云音乐！");
                LoginButtonClick(new object(), new EventArgs());
                return;
            }
            if(wordTextBox.Text == string.Empty)
            {
                N9stTip("请输入要搜索的内容！");
                return;
            }
            //清空所有行，除标题行
            uiDataGridView1.ClearRows();
            //清空歌曲Id List
            Search.SongIdList.Clear();
            JsonNode jsonNode = await Search.GetSongs(wordTextBox.Text);
            //网易云偶尔返回null
            //获取歌曲数量
            string songCount = jsonNode["result"]["songCount"]?.ToString();
            searchResultLabel.Text = songCount == null ? "搜索失败，请稍后再试" : $"共有{songCount}首歌曲符合搜索要求，只显示前30首";
            for (int i = 0; i < jsonNode["result"]["songs"]?.AsArray()?.Count; i++)
            {
                //有些歌，歌手比较多，拼接一下
                string author = null;
                foreach (var item in jsonNode["result"]["songs"][i]["ar"].AsArray())
                {
                    author += item["name"].ToString() + "/";
                }
                //歌曲Id
                string songId = jsonNode["result"]["songs"][i]["id"].ToString();
                //将歌曲ID也储存起来
                Search.SongIdList.Add(songId);
                //获取歌曲的下载状态，获取不到初始化为""
                string downloadStatus =
                    DownloadStatusDict.TryGetValue(songId, out downloadStatus) == true ? downloadStatus : "";
                //依次是歌手名称、歌曲名称、专辑名称、下载状态
                uiDataGridView1.AddRow(i + 1, author.TrimEnd('/'),
                    jsonNode["result"]["songs"][i]["name"].ToString(),
                    jsonNode["result"]["songs"][i]["al"]["name"].ToString(), downloadStatus);
            }
        }
        //监听回车键是否被按下
        private void WordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //按下就直接开始搜索，前提是光标要在wordTextBox上
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(new object(), new EventArgs());
            }
        }
        //开始下载
        private async void UiDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //选中行
            int selectRow = uiDataGridView1.SelectedIndex;
            //歌手名称
            string author = uiDataGridView1.Rows[selectRow].Cells[1].Value.ToString();
            //歌曲名称
            string songName = uiDataGridView1.Rows[selectRow].Cells[2].Value.ToString();
            //下载状态
            string downloadStatus = uiDataGridView1.Rows[selectRow].Cells[4].Value?.ToString();
            //拼接文件名称（保存路径+歌手名称+歌曲名称）
            string fileName = $"{Download.SavePath}\\{author.Replace("/",",")}" + $"-{songName}";
            //判断是否正在下载或已经下载完成
            if (downloadStatus == "开始下载" | downloadStatus.Contains("下载中"))
            {
                N9stTip($"{author}-{songName}\n正在下载！");
                return;
            }
            if (downloadStatus == "下载完成")
            {
                N9stTip($"{author}-{songName}\n已经下载完成！");
                return;
            }
            //歌曲Id
            string songId = Search.SongIdList[selectRow];
            //开始下载，记录歌曲的下载状态
            uiDataGridView1.Rows[selectRow].Cells[4].Value = "开始下载";
            DownloadStatusDict[songId] = "开始下载";
            //开始下载，报告进度
            var process = new Progress<double>(percent =>
            {
                percent *= 100;
                //下载情况汇报
                DownloadStatusDict[songId] = $"{percent:0}" == "-1" ?
                "下载失败" : $"{percent:0}" == "100" ? "下载完成" : $"下载中...{percent:0}%";
                //歌曲所在行，如果你重新搜索了歌曲，某一首歌曲所在行的位置可能会发生改变，通过唯一的歌曲Id定位所在行
                int songRow = Search.SongIdList.IndexOf(songId);
                //-1，就是重新搜索后，歌曲id不在新的列表中
                if (songRow != -1)
                {
                    uiDataGridView1.Rows[songRow].Cells[4].Value = DownloadStatusDict[songId];
                }
            });
            await Task.Run(async () =>
            {
                //异步获取下载链接
                string downloadLink = await Download.GetLink(songId);
                //没有会员，会员专属的歌曲是获取不到下载链接的，又或者网易云偶尔返回null
                if (downloadLink == null)
                {
                    uiDataGridView1.Rows[selectRow].Cells[4].Value = "下载链接为null";
                    DownloadStatusDict[songId] = "下载链接为null";
                    return;
                }
                //判断歌曲的格式
                string fileFormat = downloadLink.EndsWith(".flac") ? "flac" : "mp3";
                //判断文件是否存在，存在就增加副本
                while (File.Exists(fileName + "." + fileFormat))
                {
                    fileName += " - 副本";
                }
                //异步下载
                await Download.Save(downloadLink, fileName + "." + fileFormat, process);
            });
        }
        //弹出提示框
        private void N9stTip(string tipText)
        {
            TipForm tipForm = new TipForm(tipText);
            if (tipText.Contains("退出"))
            { 
                //监控是否成功退出登录
                tipForm.ExitLoginEvent += new TipForm.ExitLogin(MainForm_Load);
            }
            else
            {
                //修改TipForm的样式
                tipForm.OkForm();
            }
            tipForm.ShowDialog();
        }
        //打开下载文件夹
        private void DownloadPathLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Download.SavePath);
        }
    }
}
