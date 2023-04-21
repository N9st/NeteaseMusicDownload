using System;
using System.Drawing;
using System.IO;
using NeteaseMusicDownloadWinForm.Utility;
using Sunny.UI;

namespace NeteaseMusicDownloadWinForm
{
    public partial class TipForm : UIForm
    {
        //退出登录委托
        public delegate void ExitLogin(object sender, EventArgs e);
        //退出登录事件
        public event ExitLogin ExitLoginEvent;
        public TipForm(string tipText)
        {
            InitializeComponent();
            uiLabel1.Text = tipText;
        }
        //普通的Ok信息提示框
        public void OkForm()
        {
            //隐藏取消按钮
            uiButton2.Hide();
            //禁用取消按钮
            uiButton2.Enabled = false;
            //拉长确定按钮
            uiButton1.Size = new Size(386, 52);
        }
        //关闭提示框
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //关闭提示框
        private void UiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //删除cookie文件，懒，这是一个虚假的退出登录，或者单纯点击确定关闭窗口
        private void UiButton1_Click(object sender, EventArgs e)
        {
            if (uiLabel1.Text.Contains("退出"))
            {
                //删除cookie文件
                File.Delete(Login.ConfigPath);
                //指向改为null
                Login.Cookie = null;
                //执行委托事件，反馈给主窗口
                ExitLoginEvent(new object(), new EventArgs());
            }
            this.Close();
        }
    }
}
