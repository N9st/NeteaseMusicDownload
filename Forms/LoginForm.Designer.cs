namespace NeteaseMusicDownloadWinForm
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeButton = new Sunny.UI.UISymbolButton();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            this.refreshButton = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeButton.Location = new System.Drawing.Point(385, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.closeButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Radius = 0;
            this.closeButton.Size = new System.Drawing.Size(55, 56);
            this.closeButton.Symbol = 61453;
            this.closeButton.SymbolSize = 35;
            this.closeButton.TabIndex = 2;
            this.closeButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeButton.Click += new System.EventHandler(this.CloseLoginForm);
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Enabled = false;
            this.uiImageButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButton1.Location = new System.Drawing.Point(20, 80);
            this.uiImageButton1.Margin = new System.Windows.Forms.Padding(20);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(400, 400);
            this.uiImageButton1.TabIndex = 3;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = null;
            // 
            // refreshButton
            // 
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.Enabled = false;
            this.refreshButton.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.refreshButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshButton.ForeDisableColor = System.Drawing.Color.White;
            this.refreshButton.Location = new System.Drawing.Point(20, 500);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(0);
            this.refreshButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Radius = 0;
            this.refreshButton.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.refreshButton.Size = new System.Drawing.Size(400, 53);
            this.refreshButton.Style = Sunny.UI.UIStyle.Custom;
            this.refreshButton.StyleCustomMode = true;
            this.refreshButton.TabIndex = 6;
            this.refreshButton.TabStop = false;
            this.refreshButton.Text = "获取二维码中";
            this.refreshButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LoginForm
            // 
            this.AllowAddControlOnTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(440, 566);
            this.ControlBox = false;
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.uiImageButton1);
            this.Controls.Add(this.closeButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(0, 55, 0, 0);
            this.ShowRadius = false;
            this.StyleCustomMode = true;
            this.Text = "小红登录";
            this.TitleHeight = 55;
            this.ZoomScaleRect = new System.Drawing.Rectangle(26, 26, 800, 450);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UISymbolButton closeButton;
        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UIButton refreshButton;
    }
}