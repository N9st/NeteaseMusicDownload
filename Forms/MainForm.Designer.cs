namespace NeteaseMusicDownloadWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle111 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle112 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle118 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle119 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle120 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle113 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle114 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle115 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle116 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle117 = new System.Windows.Forms.DataGridViewCellStyle();
            this.closeButton = new Sunny.UI.UISymbolButton();
            this.minbolButton = new Sunny.UI.UISymbolButton();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchButton = new Sunny.UI.UIButton();
            this.wordTextBox = new Sunny.UI.UITextBox();
            this.loginButton = new Sunny.UI.UIButton();
            this.downloadPathLabel = new Sunny.UI.UILabel();
            this.searchResultLabel = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeButton.Location = new System.Drawing.Point(1361, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.closeButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Radius = 0;
            this.closeButton.Size = new System.Drawing.Size(55, 55);
            this.closeButton.Symbol = 61453;
            this.closeButton.SymbolSize = 35;
            this.closeButton.TabIndex = 0;
            this.closeButton.TabStop = false;
            this.closeButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeButton.Click += new System.EventHandler(this.ApplicationExit);
            // 
            // minbolButton
            // 
            this.minbolButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minbolButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minbolButton.Location = new System.Drawing.Point(1306, 0);
            this.minbolButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.minbolButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.minbolButton.Name = "minbolButton";
            this.minbolButton.Radius = 0;
            this.minbolButton.Size = new System.Drawing.Size(55, 55);
            this.minbolButton.Symbol = 61544;
            this.minbolButton.SymbolSize = 35;
            this.minbolButton.TabIndex = 1;
            this.minbolButton.TabStop = false;
            this.minbolButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minbolButton.Click += new System.EventHandler(this.WindowStateMinimized);
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            this.uiDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle111;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle112.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle112.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle112.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle112.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle112.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle112.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle112;
            this.uiDataGridView1.ColumnHeadersHeight = 45;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle118.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle118.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle118.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle118.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle118.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle118.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle118.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle118;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(10, 162);
            this.uiDataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.ReadOnly = true;
            dataGridViewCellStyle119.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle119.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle119.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle119.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle119.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle119.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle119;
            this.uiDataGridView1.RowHeadersVisible = false;
            this.uiDataGridView1.RowHeadersWidth = 72;
            dataGridViewCellStyle120.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle120.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle120.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle120.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle120.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle120;
            this.uiDataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.RowTemplate.Height = 45;
            this.uiDataGridView1.RowTemplate.ReadOnly = true;
            this.uiDataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.ScrollBarHandleWidth = 15;
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ScrollBarWidth = 20;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView1.Size = new System.Drawing.Size(1396, 667);
            this.uiDataGridView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView1.StyleCustomMode = true;
            this.uiDataGridView1.TabIndex = 2;
            this.uiDataGridView1.TabStop = false;
            this.uiDataGridView1.DoubleClick += new System.EventHandler(this.UiDataGridView1_DoubleClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle113.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle113;
            this.Column1.HeaderText = "序号";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 175;
            // 
            // Column2
            // 
            dataGridViewCellStyle114.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle114;
            this.Column2.HeaderText = "歌手名称";
            this.Column2.MinimumWidth = 9;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 280;
            // 
            // Column3
            // 
            dataGridViewCellStyle115.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle115;
            this.Column3.HeaderText = "音乐名称";
            this.Column3.MinimumWidth = 9;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 350;
            // 
            // Column4
            // 
            dataGridViewCellStyle116.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle116;
            this.Column4.HeaderText = "专辑名称";
            this.Column4.MinimumWidth = 9;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 330;
            // 
            // Column5
            // 
            dataGridViewCellStyle117.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle117;
            this.Column5.HeaderText = "下载情况";
            this.Column5.MinimumWidth = 9;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 228;
            // 
            // searchButton
            // 
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchButton.Location = new System.Drawing.Point(828, 81);
            this.searchButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.searchButton.Name = "searchButton";
            this.searchButton.Radius = 0;
            this.searchButton.Size = new System.Drawing.Size(182, 60);
            this.searchButton.TabIndex = 3;
            this.searchButton.TabStop = false;
            this.searchButton.Text = "搜索";
            this.searchButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // wordTextBox
            // 
            this.wordTextBox.ButtonSymbol = 61452;
            this.wordTextBox.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.wordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wordTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.wordTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordTextBox.Location = new System.Drawing.Point(384, 81);
            this.wordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wordTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Radius = 0;
            this.wordTextBox.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.wordTextBox.RectSize = 2;
            this.wordTextBox.ShowText = false;
            this.wordTextBox.Size = new System.Drawing.Size(405, 60);
            this.wordTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.wordTextBox.StyleCustomMode = true;
            this.wordTextBox.Symbol = 61442;
            this.wordTextBox.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.wordTextBox.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.wordTextBox.SymbolSize = 45;
            this.wordTextBox.TabIndex = 4;
            this.wordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.wordTextBox.Watermark = "请输入要搜索的内容";
            this.wordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WordTextBox_KeyDown);
            // 
            // loginButton
            // 
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.loginButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.ForeDisableColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(10, 942);
            this.loginButton.Margin = new System.Windows.Forms.Padding(0);
            this.loginButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.loginButton.Name = "loginButton";
            this.loginButton.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.loginButton.Size = new System.Drawing.Size(1396, 53);
            this.loginButton.Style = Sunny.UI.UIStyle.Custom;
            this.loginButton.StyleCustomMode = true;
            this.loginButton.TabIndex = 5;
            this.loginButton.TabStop = false;
            this.loginButton.Text = "尚未登录，请点击登录";
            this.loginButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // downloadPathLabel
            // 
            this.downloadPathLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadPathLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.downloadPathLabel.Location = new System.Drawing.Point(10, 838);
            this.downloadPathLabel.Name = "downloadPathLabel";
            this.downloadPathLabel.Size = new System.Drawing.Size(1396, 42);
            this.downloadPathLabel.TabIndex = 6;
            this.downloadPathLabel.Text = "保存路径";
            this.downloadPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadPathLabel.Click += new System.EventHandler(this.DownloadPathLabel_Click);
            // 
            // searchResultLabel
            // 
            this.searchResultLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchResultLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchResultLabel.Location = new System.Drawing.Point(10, 887);
            this.searchResultLabel.Name = "searchResultLabel";
            this.searchResultLabel.Size = new System.Drawing.Size(1396, 42);
            this.searchResultLabel.TabIndex = 7;
            this.searchResultLabel.Text = "等待搜索";
            this.searchResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AllowAddControlOnTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1416, 1005);
            this.ControlBox = false;
            this.Controls.Add(this.searchResultLabel);
            this.Controls.Add(this.downloadPathLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.minbolButton);
            this.Controls.Add(this.closeButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10, 55, 10, 10);
            this.ShowRadius = false;
            this.StyleCustomMode = true;
            this.Text = "小红无损音乐下载器（本项目仅供交流学习，尊重音乐版权，请勿滥用）";
            this.TitleHeight = 55;
            this.ZoomScaleRect = new System.Drawing.Rectangle(26, 26, 800, 450);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton closeButton;
        private Sunny.UI.UISymbolButton minbolButton;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UIButton searchButton;
        private Sunny.UI.UITextBox wordTextBox;
        private Sunny.UI.UIButton loginButton;
        private Sunny.UI.UILabel downloadPathLabel;
        private Sunny.UI.UILabel searchResultLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

