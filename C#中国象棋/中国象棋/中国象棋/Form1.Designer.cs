namespace 中国象棋
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChessBoard = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重置游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBinaryWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.结束游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景音乐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.nowtime = new System.Windows.Forms.Label();
            this.oprateror = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resttime = new System.Windows.Forms.Label();
            this.wholeresttime = new System.Windows.Forms.Label();
            this.time1 = new System.Windows.Forms.TextBox();
            this.time2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.天空之城 = new System.Windows.Forms.ToolStripMenuItem();
            this.卡农 = new System.Windows.Forms.ToolStripMenuItem();
            this.精忠报国 = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭音乐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oprateror)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChessBoard
            // 
            this.ChessBoard.Image = ((System.Drawing.Image)(resources.GetObject("ChessBoard.Image")));
            this.ChessBoard.Location = new System.Drawing.Point(0, 32);
            this.ChessBoard.Margin = new System.Windows.Forms.Padding(4);
            this.ChessBoard.Name = "ChessBoard";
            this.ChessBoard.Size = new System.Drawing.Size(526, 579);
            this.ChessBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ChessBoard.TabIndex = 0;
            this.ChessBoard.TabStop = false;
            this.ChessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessBoardClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏选项ToolStripMenuItem,
            this.背景音乐ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(971, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏选项ToolStripMenuItem
            // 
            this.游戏选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始游戏ToolStripMenuItem,
            this.重置游戏ToolStripMenuItem,
            this.SaveFile,
            this.btnBinaryWrite,
            this.结束游戏ToolStripMenuItem});
            this.游戏选项ToolStripMenuItem.Name = "游戏选项ToolStripMenuItem";
            this.游戏选项ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.游戏选项ToolStripMenuItem.Text = "游戏选项";
            // 
            // 开始游戏ToolStripMenuItem
            // 
            this.开始游戏ToolStripMenuItem.Name = "开始游戏ToolStripMenuItem";
            this.开始游戏ToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.开始游戏ToolStripMenuItem.Text = "开始游戏（Ctrl+W）";
            this.开始游戏ToolStripMenuItem.Click += new System.EventHandler(this.GameStart);
            // 
            // 重置游戏ToolStripMenuItem
            // 
            this.重置游戏ToolStripMenuItem.Name = "重置游戏ToolStripMenuItem";
            this.重置游戏ToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.重置游戏ToolStripMenuItem.Text = "清盘";
            this.重置游戏ToolStripMenuItem.Click += new System.EventHandler(this.ChessBoardClear);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(226, 26);
            this.SaveFile.Text = "保存棋谱";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // btnBinaryWrite
            // 
            this.btnBinaryWrite.Name = "btnBinaryWrite";
            this.btnBinaryWrite.Size = new System.Drawing.Size(226, 26);
            this.btnBinaryWrite.Text = "二进制保存";
            this.btnBinaryWrite.Click += new System.EventHandler(this.btnBinaryWrite_Click);
            // 
            // 结束游戏ToolStripMenuItem
            // 
            this.结束游戏ToolStripMenuItem.Name = "结束游戏ToolStripMenuItem";
            this.结束游戏ToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.结束游戏ToolStripMenuItem.Text = "退出游戏";
            this.结束游戏ToolStripMenuItem.Click += new System.EventHandler(this.GameExit);
            // 
            // 背景音乐ToolStripMenuItem
            // 
            this.背景音乐ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.天空之城,
            this.卡农,
            this.精忠报国,
            this.关闭音乐ToolStripMenuItem});
            this.背景音乐ToolStripMenuItem.Name = "背景音乐ToolStripMenuItem";
            this.背景音乐ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.背景音乐ToolStripMenuItem.Text = "背景音乐";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.帮助ToolStripMenuItem.Text = "帮助(&F)";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.AboutUs);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // nowtime
            // 
            this.nowtime.AutoSize = true;
            this.nowtime.Font = new System.Drawing.Font("华文隶书", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowtime.Location = new System.Drawing.Point(666, 32);
            this.nowtime.Name = "nowtime";
            this.nowtime.Size = new System.Drawing.Size(62, 25);
            this.nowtime.TabIndex = 4;
            this.nowtime.Text = "时间";
            // 
            // oprateror
            // 
            this.oprateror.Image = ((System.Drawing.Image)(resources.GetObject("oprateror.Image")));
            this.oprateror.Location = new System.Drawing.Point(95, 33);
            this.oprateror.Name = "oprateror";
            this.oprateror.Size = new System.Drawing.Size(117, 105);
            this.oprateror.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oprateror.TabIndex = 5;
            this.oprateror.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.oprateror);
            this.groupBox1.Controls.Add(this.resttime);
            this.groupBox1.Controls.Add(this.wholeresttime);
            this.groupBox1.Font = new System.Drawing.Font("隶书", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(719, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 179);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "正在出棋：";
            // 
            // resttime
            // 
            this.resttime.AutoSize = true;
            this.resttime.Font = new System.Drawing.Font("隶书", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resttime.Location = new System.Drawing.Point(6, 118);
            this.resttime.Name = "resttime";
            this.resttime.Size = new System.Drawing.Size(40, 28);
            this.resttime.TabIndex = 6;
            this.resttime.Text = "秒";
            // 
            // wholeresttime
            // 
            this.wholeresttime.AutoSize = true;
            this.wholeresttime.Font = new System.Drawing.Font("隶书", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wholeresttime.Location = new System.Drawing.Point(6, 30);
            this.wholeresttime.Name = "wholeresttime";
            this.wholeresttime.Size = new System.Drawing.Size(40, 28);
            this.wholeresttime.TabIndex = 7;
            this.wholeresttime.Text = "分";
            // 
            // time1
            // 
            this.time1.Location = new System.Drawing.Point(827, 94);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(100, 25);
            this.time1.TabIndex = 9;
            // 
            // time2
            // 
            this.time2.Location = new System.Drawing.Point(827, 135);
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(100, 25);
            this.time2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(667, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "局时（分）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("隶书", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(667, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "步时（分）：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(671, 424);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(288, 309);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "棋谱信息：";
            // 
            // 天空之城
            // 
            this.天空之城.Name = "天空之城";
            this.天空之城.Size = new System.Drawing.Size(181, 26);
            this.天空之城.Text = "《天空之城》";
            this.天空之城.Click += new System.EventHandler(this.天空之城_Click);
            // 
            // 卡农
            // 
            this.卡农.Name = "卡农";
            this.卡农.Size = new System.Drawing.Size(181, 26);
            this.卡农.Text = "《卡农》";
            this.卡农.Click += new System.EventHandler(this.卡农_Click);
            // 
            // 精忠报国
            // 
            this.精忠报国.Name = "精忠报国";
            this.精忠报国.Size = new System.Drawing.Size(181, 26);
            this.精忠报国.Text = "《精忠报国》";
            this.精忠报国.Click += new System.EventHandler(this.精忠报国_Click);
            // 
            // 关闭音乐ToolStripMenuItem
            // 
            this.关闭音乐ToolStripMenuItem.Name = "关闭音乐ToolStripMenuItem";
            this.关闭音乐ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.关闭音乐ToolStripMenuItem.Text = " 关闭音乐";
            this.关闭音乐ToolStripMenuItem.Click += new System.EventHandler(this.关闭音乐ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(971, 745);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.time2);
            this.Controls.Add(this.time1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nowtime);
            this.Controls.Add(this.ChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中国象棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oprateror)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ChessBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景音乐ToolStripMenuItem;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label nowtime;
        private System.Windows.Forms.PictureBox oprateror;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label resttime;
        private System.Windows.Forms.Label wholeresttime;
        private System.Windows.Forms.TextBox time1;
        private System.Windows.Forms.TextBox time2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem btnBinaryWrite;
        private System.Windows.Forms.ToolStripMenuItem 天空之城;
        private System.Windows.Forms.ToolStripMenuItem 卡农;
        private System.Windows.Forms.ToolStripMenuItem 精忠报国;
        private System.Windows.Forms.ToolStripMenuItem 关闭音乐ToolStripMenuItem;
    }
}

