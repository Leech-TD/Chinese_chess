using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace 中国象棋
{
    public partial class Form1 : Form
    {
        #region 变量
        Chess Cur_Chess = null;  //当前操作棋子                          
       static int whole_time = 20;//分
       static  int per_time=120;//秒
       static int count = 60;
        int[] King_Hour = new int[] { 20,20};
        private int player = 1; //0是黑棋，1是红棋
        public int Player
        {
            get { return player; }
            set
            {
                if (value != player)
                {
                    player = value;

                    WhenPlayerChanged();
                }
                player = value;
            }

        }
        public static IntPtr playHandle;

        MusicPlayer playbgm = new MusicPlayer("",playHandle);


        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Battlefield.ChessHandle = ChessBoard.Handle;
            wholeresttime.Text = King_Hour[player].ToString() + "分";
            playbgm.Mp3_Play(@"sound/卡农.mp3");

        }

        /// <summary>
        /// 棋盘清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessBoardClear(object sender, EventArgs e)
        {
            this.Timer.Enabled = false;
            ChessBoard.Invalidate();
            Battlefield.ClearChess();
            Cur_Chess = null;
            Player = 1;
            oprateror.Image = Image.FromFile(@"pic\子\帅.png ");
            this.textBox1.Text = null;
            中国象棋.Chess.info = null;
            
        }


        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameStart(object sender, EventArgs e)
        {
            this.Timer.Start();
            Battlefield.resetChessBoard();
            if (time1.Text != string.Empty)
            {
                whole_time = int.Parse(time1.Text);
                King_Hour[0] = whole_time;
                King_Hour[1] = whole_time;

            }
            if (time2.Text != string.Empty)
                per_time = (int.Parse(time2.Text)) * 60;
            oprateror.Image = Image.FromFile(@"pic\子\帅.png ");
        }

        /// <summary>
        /// 棋盘点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessBoardClick(object sender, MouseEventArgs e)
        {
            int x = (e.X - 10) / Battlefield.chessSize;//横轴
            int y = (e.Y - 10) / Battlefield.chessSize;//纵轴
            bool isGameOver = false;
            if (!Battlefield.isEmpty(x, y))
            {   //(选子、吃子、换子)点击坐标位不为空
                Chess chess = Battlefield.ChessGroup[y, x];
                if (Cur_Chess != null)
                {   //当前棋子不为空
                    if (chess.CampOwn == Cur_Chess.CampOwn)
                    {   //我方阵营，换子操作
                        Cur_Chess.Eraser(Battlefield.ChessHandle);
                        Cur_Chess.Draw(Battlefield.ChessHandle);
                        Cur_Chess = chess;
                        Cur_Chess.Choise(Battlefield.ChessHandle);
                        MusicPlayer.play("normall");
                    }
                    else
                    {   //敌方阵营，吃子操作
                        if (!Cur_Chess.Move(x, y))
                            return;
                        Cur_Chess.Eraser(Battlefield.ChessHandle);
                        Battlefield.BitChess[(Cur_Chess.Location.Y - 10) / Battlefield.chessSize] -= (1 << (Battlefield.width - 1 - ((Cur_Chess.Location.X - 10) / Battlefield.chessSize)));
                        Battlefield.ChessGroup[(Cur_Chess.Location.Y - 10) / Battlefield.chessSize, (Cur_Chess.Location.X - 10) / Battlefield.chessSize] = null;
                        Cur_Chess.Location = chess.Location;
                        //检查被吃棋子是否是将军
                        isGameOver = Battlefield.Kill_King(Battlefield.ChessGroup[y, x]);
                        Battlefield.ChessGroup[y, x] = Cur_Chess;
                        Cur_Chess.Draw(Battlefield.ChessHandle);
                        MusicPlayer.play("吃子");
                        Change_Player();
                        //将军被吃==Game Over
                        if (isGameOver)
                            Battlefield.ClearChess();
                    }
                }
                else
                {   //当前棋子为空，选子操作
                    if ((Player == 0) && (chess.CampOwn == Chess.Camp.黑棋))
                    {
                        Cur_Chess = chess;
                        Cur_Chess.Choise(Battlefield.ChessHandle);
                        MusicPlayer.play("normall");
                    }
                    else if ((Player == 1) && (chess.CampOwn == Chess.Camp.红棋))
                    {
                        Cur_Chess = chess;
                        Cur_Chess.Choise(Battlefield.ChessHandle);
                        MusicPlayer.play("normall");
                    }
                }

            }
            else if (Cur_Chess != null)
            { //(移动)点击坐标位为空，当前对象不为空
                if (!Cur_Chess.Move(x, y))
                    return;
             Cur_Chess.Eraser(Battlefield.ChessHandle);
                Battlefield.BitChess[(Cur_Chess.Location.Y - 10) / Battlefield.chessSize] -= (1 << (Battlefield.width - 1 - ((Cur_Chess.Location.X - 10) / Battlefield.chessSize)));
                Battlefield.ChessGroup[(Cur_Chess.Location.Y - 10) / Battlefield.chessSize, (Cur_Chess.Location.X - 10) / Battlefield.chessSize] = null;
                Battlefield.BitChess[y] = Battlefield.BitChess[y] | (1 << (Battlefield.width - 1 - x));
                Battlefield.ChessGroup[y, x] = Cur_Chess;
                Cur_Chess.Location = new Point(x * Battlefield.chessSize + 10, y * Battlefield.chessSize + 10);
                Cur_Chess.Draw(Battlefield.ChessHandle);
                MusicPlayer.play("normall");
                Change_Player();
            }
           
        }

        /// <summary>
        /// 结束一方操作，轮到一下方
        /// </summary>
        public void Change_Player() {
            Cur_Chess = null;
            Player = ++Player % 2;
            if (Player == 0)
            {
                oprateror.Image = Image.FromFile(@"pic\子\将.png ");
              
            }
            else {
                oprateror.Image = Image.FromFile(@"pic\子\帅.png ");
          

            }
        }
        /// <summary>
        /// 读秒
        /// </summary>
        private void WhenPlayerChanged()
        {
            if (time2.Text != string.Empty)
                per_time = (int.Parse(time2.Text))*60;
            else
                per_time = 120;
            resttime.Text = per_time.ToString() + "秒";
            count = 59;
            this.textBox1.Text = 中国象棋.Chess.info;

        }

        /// <summary>
        /// 退出
        /// </summary>
        private void GameExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutUs(object sender, EventArgs e)
        {
            MessageBox.Show(" QQ:1481567342","责任人：龙腾");
        }

        
        private void _timer_Tick(object sender, EventArgs e)
        {
            nowtime.Text = string.Format("现在时间：{0}", DateTime.Now.ToLongTimeString());
            wholeresttime.Text = King_Hour[player].ToString()+"分";
            if (King_Hour[player] >= 0 && per_time > 0)
            {
                per_time--;
                count--;
                resttime.Text = per_time.ToString() + "秒";

                if (count == 0)
                {
                    King_Hour[player]--;
                    wholeresttime.Text = King_Hour.ToString() + "分";
                    count = 59;
                }

            }
            else
            {
                Chess Cur_Chess = Battlefield.ChessGroup[9,4];

                Cur_Chess.Level1 = Chess.Level.帅;
                if(player==1  )
                Cur_Chess.CampOwn = Chess.Camp.红棋;
                else
                Cur_Chess.CampOwn = Chess.Camp.黑棋;

                中国象棋.Battlefield.Kill_King(Cur_Chess);
            }
         
        }

        private void SaveFile_Click(object sender, EventArgs e)//保存
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "txt文件|*。txt";
            sf.AddExtension = true;
            sf.Title = "棋谱信息";
            if(sf.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(this.textBox1.Text);
                sw.Close();
                fs.Close();
            }
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)//二进制保存
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "bin 文件|*。bin";
            sf.AddExtension = true;
            sf.Title = "读二进制文件棋谱";
            if(sf.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(textBox1.Text);
                bw.Close();
                fs.Close();
            }

        }
        #region 播放音乐
        private void 天空之城_Click(object sender, EventArgs e)
        {

            playbgm.CloseMedia();
            playbgm.Mp3_Play(@"sound\天空之城.mp3 ");
        }

        private void 卡农_Click(object sender, EventArgs e)
        {
            playbgm.CloseMedia();

            playbgm.Mp3_Play(@"sound\卡农.mp3 ");
        }

        private void 精忠报国_Click(object sender, EventArgs e)
        {
            playbgm.CloseMedia();

            playbgm.Mp3_Play(@"sound\精忠报国.mp3 ");
        }
        #endregion

        private void 关闭音乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playbgm.CloseMedia();
        }
    }
}
