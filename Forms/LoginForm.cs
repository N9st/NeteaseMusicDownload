using System;
using System.Threading.Tasks;
using Sunny.UI;
using NeteaseMusicDownloadWinForm.Utility;
using System.Threading;

namespace NeteaseMusicDownloadWinForm
{
    public partial class LoginForm : UIForm
    {
        //完成登录委托
        public delegate void FinishLogin(object sender, EventArgs e);
        //完成登录事件
        public event FinishLogin FinishLoginEvent;
        public LoginForm()
        {
            InitializeComponent();
        }
        //关闭窗口
        private void CloseLoginForm(object sender, EventArgs e)
        {
            this.Close();
        }
        //刷新二维码按钮
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoginForm_Load(new object(), new EventArgs());
        }
        private async void LoginForm_Load(object sender, EventArgs e)
        {
            //获取不到二维码就没必要继续执行啦
            if (await RefreshQrCode())
            {
                //异步执行，防止界面卡死
                await Task.Run(async () =>
                {
                    await MonitorQrCode();
                });
            }
            //登录成功关闭子窗口，登录失败（二维码失效）refreshButton启用
            if (refreshButton.Text == "授权登陆成功")
            {
                //保存cookie
                Login.SaveLoginCookie();
                //加载Cookie
                Login.ReadCookie();
                //执行登录成功事件
                FinishLoginEvent(new object(), new EventArgs());
                //关闭窗口
                this.Close();
            }
            else
            {
                //没有登录成功，刷新二维码按钮可用
                refreshButton.Enabled = true;
            }
        }
        //刷新二维码
        private async Task<bool> RefreshQrCode()
        {
            //第一步生成二维码
            string uniKey = await Login.GetLoginKey();
            if (uniKey != null)
            {
                string qrCodeContent = "http://music.163.com/login?codekey=" + uniKey;
                uiImageButton1.Image = Login.GenerateQrCode(qrCodeContent, 400, 400);
                refreshButton.Text = "等待扫码";
                return true;
            }
            else
            {
                refreshButton.Text = "获取二维码失败";
                return false;
            }
        }
        //监控二维码状态
        private async Task MonitorQrCode()
        {
            //第二步监控二维码的状态
            string qrCodeStatus = "等待扫码";
            
            while (true)
            {
                //延时2秒，不要这么频繁访问
                Thread.Sleep(2000);
                //获取二维码状态
                qrCodeStatus = await Login.CheckQrCodeStatus();
                //控件没有创建不能调用invoke，不然会报错
                if (!refreshButton.Created) 
                {
                    break;
                }
                //修改控件内容，这个地方容易报错。。。没想好怎么写
                refreshButton.Invoke(new EventHandler(delegate
                {
                    //null，是因为有时候网易云会返回null，json就会解析失败，然后我设置返回null
                    refreshButton.Text = qrCodeStatus ?? refreshButton.Text;
                }));
                //判断是否登录成功或者二维码失效
                if (refreshButton.Text == "授权登陆成功" | refreshButton.Text == "二维码不存在或已过期")
                {
                    break;
                }
            }
        }
    }
}
