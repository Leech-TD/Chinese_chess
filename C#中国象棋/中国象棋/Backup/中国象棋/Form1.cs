using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 中国象棋
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameField.chessHandle = ChessBoard.Handle;
        }

        #region 变量
        Chess curChess = null;  //当前操作棋子
        int isTurn = 1;         //轮流，0是黑棋，1是红棋
        #endregion

        #region 测试
        /// <summary>
        /// 画网格线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRectangle(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(GameField.chessHandle);
            Brush brush = new SolidBrush(Color.Red);
            Pen pen = new Pen(brush);

            for (int i = 0; i < 9; i++)
            {
                for (int ii = 0; ii < 10; ii++)
                {
                    g.DrawRectangle(pen, new Rectangle(10 + (i * 57), 10 + (ii * 57), 57, 57));
                }
            }
        }

        /// <summary>
        /// 擦除当前棋子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraseCurChess(object sender, EventArgs e)
        {
            if (curChess != null)
                curChess.eraser(GameField.chessHandle);
        }

        /// <summary>
        /// 棋盘清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessBoardClear(object sender, EventArgs e)
        {
            ChessBoard.Invalidate();
            GameField.clearChess();
            //初始化变量
            curChess = null;
            isTurn = 0;
            lbl_trun.Text = "黑棋";
            lbl_trun.ForeColor = Color.Black;
        }

        /// <summary>
        /// 显示当前操作棋子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showCurChess(object sender, EventArgs e)
        {
            if (curChess != null)
                MessageBox.Show(curChess.CampOwn.ToString() + ":" + curChess.Level1.ToString());
        }

        #endregion

        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameStart(object sender, EventArgs e)
        {
            GameField.resetChessBoard();
            Music.PlaySong(@"sound\bgMusic.mid");
        }

        /// <summary>
        /// 棋盘点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessBoardClick(object sender, MouseEventArgs e)
        {
            int x = (e.X - 10) / GameField.chessSize;//横轴
            int y = (e.Y - 10) / GameField.chessSize;//纵轴
            bool isGameOver = false;
            if (!GameField.isEmpty(x, y))
            {   //(选子、吃子、换子)点击坐标位不为空
                Chess chess = GameField.AllChess[y, x];
                if (curChess != null)
                {   //当前棋子不为空
                    if (chess.CampOwn == curChess.CampOwn)
                    {   //我方阵营，换子操作
                        curChess.eraser(GameField.chessHandle);
                        curChess.Draw(GameField.chessHandle);
                        curChess = chess;
                        curChess.Choise(GameField.chessHandle);
                        Music.play("换子");
                    }
                    else
                    {   //敌方阵营，吃子操作
                        if (!curChess.Move(x, y))
                            return;
                        curChess.eraser(GameField.chessHandle);
                        GameField.BitChess[(curChess.Location.Y - 10) / GameField.chessSize] -= (1 << (GameField.width - 1 - ((curChess.Location.X - 10) / GameField.chessSize)));
                        GameField.AllChess[(curChess.Location.Y - 10) / GameField.chessSize, (curChess.Location.X - 10) / GameField.chessSize] = null;
                        curChess.Location = chess.Location;
                        //检查被吃棋子是否是将军
                        isGameOver = GameField.JiangJun(GameField.AllChess[y, x]);
                        GameField.AllChess[y, x] = curChess;
                        curChess.Draw(GameField.chessHandle);
                        Music.play("吃子");
                        TrunNext();
                        //将军被吃==Game Over
                        if (isGameOver)
                            GameField.clearChess();
                    }
                }
                else
                {   //当前棋子为空，选子操作
                    if ((isTurn == 0) && (chess.CampOwn == Chess.Camp.黑棋))
                    {
                        curChess = chess;
                        curChess.Choise(GameField.chessHandle);
                        Music.play("选子");
                    }
                    else if ((isTurn == 1) && (chess.CampOwn == Chess.Camp.红棋))
                    {
                        curChess = chess;
                        curChess.Choise(GameField.chessHandle);
                        Music.play("选子");
                    }
                }
            }
            else if (curChess != null)
            { //(移动)点击坐标位为空，当前对象不为空
                if (!curChess.Move(x, y))
                    return;
                curChess.eraser(GameField.chessHandle);
                GameField.BitChess[(curChess.Location.Y - 10) / GameField.chessSize] -= (1 << (GameField.width - 1 - ((curChess.Location.X - 10) / GameField.chessSize)));
                GameField.AllChess[(curChess.Location.Y - 10) / GameField.chessSize, (curChess.Location.X - 10) / GameField.chessSize] = null;
                GameField.BitChess[y] = GameField.BitChess[y] | (1 << (GameField.width - 1 - x));
                GameField.AllChess[y, x] = curChess;
                curChess.Location = new Point(x * GameField.chessSize + 10, y * GameField.chessSize + 10);
                curChess.Draw(GameField.chessHandle);
                Music.play("移动");
                TrunNext();
            }
            
        }

        /// <summary>
        /// 结束一方操作，轮到一下方
        /// </summary>
        public void TrunNext() {
            curChess = null;
            isTurn = ++isTurn % 2;
            if (isTurn == 0)
            {
                lbl_trun.Text = "黑棋";
                lbl_trun.ForeColor = Color.Black;
            }
            else {
                lbl_trun.Text = "红棋";
                lbl_trun.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control) {
                switch (e.KeyCode) { 
                    case Keys.O:
                        GameField.resetChessBoard();
                        Music.PlaySong(@"sound\bgMusic.mid");
                        break;
                    case Keys.A:
                        MessageBox.Show("暂未开发");
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutUs(object sender, EventArgs e)
        {
            AboutUs au = new AboutUs();
            au.Show();
        }

        
        private void 倩女幽魂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Music.PlaySong(@"sound\bgMusic.mid");
        }

        private void 笑傲江湖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Music.PlaySong(@"sound\笑傲江湖.mp3");
        }

       

    }
}
