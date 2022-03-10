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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChessBoard = new System.Windows.Forms.PictureBox();
            this.lbl_trun = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重置游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.辅助功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示选中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景音乐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.倩女幽魂ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.笑傲江湖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChessBoard
            // 
            this.ChessBoard.Image = ((System.Drawing.Image)(resources.GetObject("ChessBoard.Image")));
            this.ChessBoard.Location = new System.Drawing.Point(0, 28);
            this.ChessBoard.Name = "ChessBoard";
            this.ChessBoard.Size = new System.Drawing.Size(523, 579);
            this.ChessBoard.TabIndex = 0;
            this.ChessBoard.TabStop = false;
            this.ChessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessBoardClick);
            // 
            // lbl_trun
            // 
            this.lbl_trun.AutoSize = true;
            this.lbl_trun.BackColor = System.Drawing.Color.NavajoWhite;
            this.lbl_trun.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_trun.ForeColor = System.Drawing.Color.Black;
            this.lbl_trun.Location = new System.Drawing.Point(246, 310);
            this.lbl_trun.Name = "lbl_trun";
            this.lbl_trun.Size = new System.Drawing.Size(37, 19);
            this.lbl_trun.TabIndex = 2;
            this.lbl_trun.Text = "黑棋";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏选项ToolStripMenuItem,
            this.辅助功能ToolStripMenuItem,
            this.背景音乐ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(528, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏选项ToolStripMenuItem
            // 
            this.游戏选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始游戏ToolStripMenuItem,
            this.重置游戏ToolStripMenuItem,
            this.结束游戏ToolStripMenuItem});
            this.游戏选项ToolStripMenuItem.Name = "游戏选项ToolStripMenuItem";
            this.游戏选项ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.游戏选项ToolStripMenuItem.Text = "游戏选项";
            // 
            // 开始游戏ToolStripMenuItem
            // 
            this.开始游戏ToolStripMenuItem.Name = "开始游戏ToolStripMenuItem";
            this.开始游戏ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.开始游戏ToolStripMenuItem.Text = "开始游戏  Ctrl+O";
            this.开始游戏ToolStripMenuItem.Click += new System.EventHandler(this.GameStart);
            // 
            // 重置游戏ToolStripMenuItem
            // 
            this.重置游戏ToolStripMenuItem.Name = "重置游戏ToolStripMenuItem";
            this.重置游戏ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.重置游戏ToolStripMenuItem.Text = "重置游戏  Ctrl+A";
            this.重置游戏ToolStripMenuItem.Click += new System.EventHandler(this.ChessBoardClear);
            // 
            // 结束游戏ToolStripMenuItem
            // 
            this.结束游戏ToolStripMenuItem.Name = "结束游戏ToolStripMenuItem";
            this.结束游戏ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.结束游戏ToolStripMenuItem.Text = "结束游戏";
            this.结束游戏ToolStripMenuItem.Click += new System.EventHandler(this.GameExit);
            // 
            // 辅助功能ToolStripMenuItem
            // 
            this.辅助功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示网格ToolStripMenuItem,
            this.显示选中ToolStripMenuItem});
            this.辅助功能ToolStripMenuItem.Name = "辅助功能ToolStripMenuItem";
            this.辅助功能ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.辅助功能ToolStripMenuItem.Text = "辅助功能";
            // 
            // 显示网格ToolStripMenuItem
            // 
            this.显示网格ToolStripMenuItem.Name = "显示网格ToolStripMenuItem";
            this.显示网格ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示网格ToolStripMenuItem.Text = "显示网格";
            this.显示网格ToolStripMenuItem.Click += new System.EventHandler(this.DrawRectangle);
            // 
            // 显示选中ToolStripMenuItem
            // 
            this.显示选中ToolStripMenuItem.Name = "显示选中ToolStripMenuItem";
            this.显示选中ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示选中ToolStripMenuItem.Text = "显示选中";
            this.显示选中ToolStripMenuItem.Click += new System.EventHandler(this.showCurChess);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.AboutUs);
            // 
            // 背景音乐ToolStripMenuItem
            // 
            this.背景音乐ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.倩女幽魂ToolStripMenuItem,
            this.笑傲江湖ToolStripMenuItem});
            this.背景音乐ToolStripMenuItem.Name = "背景音乐ToolStripMenuItem";
            this.背景音乐ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.背景音乐ToolStripMenuItem.Text = "背景音乐";
            // 
            // 倩女幽魂ToolStripMenuItem
            // 
            this.倩女幽魂ToolStripMenuItem.Name = "倩女幽魂ToolStripMenuItem";
            this.倩女幽魂ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.倩女幽魂ToolStripMenuItem.Text = "倩女幽魂";
            this.倩女幽魂ToolStripMenuItem.Click += new System.EventHandler(this.倩女幽魂ToolStripMenuItem_Click);
            // 
            // 笑傲江湖ToolStripMenuItem
            // 
            this.笑傲江湖ToolStripMenuItem.Name = "笑傲江湖ToolStripMenuItem";
            this.笑傲江湖ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.笑傲江湖ToolStripMenuItem.Text = "笑傲江湖";
            this.笑傲江湖ToolStripMenuItem.Click += new System.EventHandler(this.笑傲江湖ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(528, 606);
            this.Controls.Add(this.lbl_trun);
            this.Controls.Add(this.ChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中国象棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChessKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ChessBoard)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ChessBoard;
        private System.Windows.Forms.Label lbl_trun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 辅助功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示网格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示选中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景音乐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 倩女幽魂ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 笑傲江湖ToolStripMenuItem;
    }
}

