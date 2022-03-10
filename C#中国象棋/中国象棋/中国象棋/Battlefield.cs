using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 中国象棋
{
    class Battlefield
    {  

        public const int width = 9;
        public const int height = 10;
        public const int chessSize = 57;
        public static Chess[,] ChessGroup = new Chess[height, width];
        public static int[] BitChess = new int[height];
        public static IntPtr ChessHandle;


        #region 初始化
        /// <summary>
        /// 初始化棋盘
        /// </summary>
        public static void resetChessBoard()
        {
            //红方
            Chess Red_King= new Chess(Chess.Level.帅, new Point(10 + chessSize * 4, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Guard1 = new Chess(Chess.Level.士, new Point(10 + chessSize * 3, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Guard2 = new Chess(Chess.Level.士, new Point(10 + chessSize * 5, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Elephant1 = new Chess(Chess.Level.相, new Point(10 + chessSize * 2, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Elephant2 = new Chess(Chess.Level.相, new Point(10 + chessSize * 6, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Horse1 = new Chess(Chess.Level.马, new Point(10 + chessSize, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Horse2 = new Chess(Chess.Level.马, new Point(10 + chessSize * 7, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Chariot1 = new Chess(Chess.Level.车, new Point(10, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Chariot2 = new Chess(Chess.Level.车, new Point(10 + chessSize * 8, 10+chessSize*9), Chess.Camp.红棋);
            Chess Red_Cannon1 = new Chess(Chess.Level.炮, new Point(10 + chessSize, 10 + chessSize * 7), Chess.Camp.红棋);
            Chess Red_Cannon2 = new Chess(Chess.Level.炮, new Point(10 + chessSize * 7, 10 + chessSize * 7), Chess.Camp.红棋);
            Chess Red_Soldier1 = new Chess(Chess.Level.兵, new Point(10, 10 + chessSize * 6), Chess.Camp.红棋);
            Chess Red_Soldier2 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 2, 10 + chessSize * 6), Chess.Camp.红棋);
            Chess Red_Soldier3 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 4, 10 + chessSize * 6), Chess.Camp.红棋);
            Chess Red_Soldier4 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 6, 10 + chessSize * 6), Chess.Camp.红棋);
            Chess Red_Soldier5 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 8, 10 + chessSize * 6), Chess.Camp.红棋);
            Red_King.Draw(ChessHandle);
            Red_Guard1.Draw(ChessHandle);
            Red_Guard2.Draw(ChessHandle);
            Red_Elephant1.Draw(ChessHandle);
            Red_Elephant2.Draw(ChessHandle);
            Red_Horse1.Draw(ChessHandle);
            Red_Horse2.Draw(ChessHandle);
            Red_Chariot1.Draw(ChessHandle);
            Red_Chariot2.Draw(ChessHandle);
            Red_Cannon1.Draw(ChessHandle);
            Red_Cannon2.Draw(ChessHandle);
            Red_Soldier1.Draw(ChessHandle);
            Red_Soldier2.Draw(ChessHandle);
            Red_Soldier3.Draw(ChessHandle);
            Red_Soldier4.Draw(ChessHandle);
            Red_Soldier5.Draw(ChessHandle);
            //黑方
            Chess Black_King = new Chess(Chess.Level.帅, new Point(10 + chessSize * 4, 10), Chess.Camp.黑棋);
            Chess Black_Guard1 = new Chess(Chess.Level.士, new Point(10 + chessSize * 3, 10), Chess.Camp.黑棋);
            Chess Black_Guard2 = new Chess(Chess.Level.士, new Point(10 + chessSize * 5, 10), Chess.Camp.黑棋);
            Chess Black_Elephant1 = new Chess(Chess.Level.相, new Point(10 + chessSize * 2, 10 ), Chess.Camp.黑棋);
            Chess Black_Elephant2 = new Chess(Chess.Level.相, new Point(10 + chessSize * 6, 10 ), Chess.Camp.黑棋);
            Chess Black_Horse1 = new Chess(Chess.Level.马, new Point(10 + chessSize, 10 ), Chess.Camp.黑棋);
            Chess Black_Horse2 = new Chess(Chess.Level.马, new Point(10 + chessSize * 7, 10), Chess.Camp.黑棋);
            Chess Black_Chariot1 = new Chess(Chess.Level.车, new Point(10, 10 ), Chess.Camp.黑棋);
            Chess Black_Chariot2 = new Chess(Chess.Level.车, new Point(10 + chessSize * 8, 10), Chess.Camp.黑棋);
            Chess Black_Cannon1 = new Chess(Chess.Level.炮, new Point(10 + chessSize, 10 + chessSize * 2), Chess.Camp.黑棋);
            Chess Black_Cannon2 = new Chess(Chess.Level.炮, new Point(10 + chessSize * 7, 10 + chessSize * 2), Chess.Camp.黑棋);
            Chess Black_Soldier1 = new Chess(Chess.Level.兵, new Point(10, 10 + chessSize * 3), Chess.Camp.黑棋);
            Chess Black_Soldier2 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 2, 10 + chessSize * 3), Chess.Camp.黑棋);
            Chess Black_Soldier3 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 4, 10 + chessSize * 3), Chess.Camp.黑棋);
            Chess Black_Soldier4 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 6, 10 + chessSize * 3), Chess.Camp.黑棋);
            Chess Black_Soldier5 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 8, 10 + chessSize * 3), Chess.Camp.黑棋);
            Black_King.Draw(ChessHandle);
            Black_Guard1.Draw(ChessHandle);
            Black_Guard2.Draw(ChessHandle);
            Black_Elephant1.Draw(ChessHandle);
            Black_Elephant2.Draw(ChessHandle);
            Black_Horse1.Draw(ChessHandle);
            Black_Horse2.Draw(ChessHandle);
            Black_Chariot1.Draw(ChessHandle);
            Black_Chariot2.Draw(ChessHandle);
            Black_Cannon1.Draw(ChessHandle);
            Black_Cannon2.Draw(ChessHandle);
            Black_Soldier1.Draw(ChessHandle);
            Black_Soldier2.Draw(ChessHandle);
            Black_Soldier3.Draw(ChessHandle);
            Black_Soldier4.Draw(ChessHandle);
            Black_Soldier5.Draw(ChessHandle);
            //红发对象添加至数组
            ChessGroup[9, 0] = Red_Chariot1;
            ChessGroup[9, 1] = Red_Horse1;
            ChessGroup[9, 2] = Red_Elephant1;
            ChessGroup[9, 3] = Red_Guard1;
            ChessGroup[9, 4] = Red_King;
            ChessGroup[9, 5] = Red_Guard2;
            ChessGroup[9, 6] = Red_Elephant2;
            ChessGroup[9, 7] = Red_Horse2;
            ChessGroup[9, 8] = Red_Chariot2;
            ChessGroup[7, 1] = Red_Cannon1;
            ChessGroup[7, 7] = Red_Cannon2;
            ChessGroup[6, 0] = Red_Soldier1;
            ChessGroup[6, 2] = Red_Soldier2;
            ChessGroup[6, 4] = Red_Soldier3;
            ChessGroup[6, 6] = Red_Soldier4;
            ChessGroup[6, 8] = Red_Soldier5;
            //黑发对象添加至数组
            ChessGroup[3, 0] = Black_Soldier1;
            ChessGroup[3, 2] = Black_Soldier2;
            ChessGroup[3, 4] = Black_Soldier3;
            ChessGroup[3, 6] = Black_Soldier4;
            ChessGroup[3, 8] = Black_Soldier5;
            ChessGroup[2, 1] = Black_Cannon1;
            ChessGroup[2, 7] = Black_Cannon2;
            ChessGroup[0, 0] = Black_Chariot1;
            ChessGroup[0, 1] = Black_Horse1;
            ChessGroup[0, 2] = Black_Elephant1;
            ChessGroup[0, 3] = Black_Guard1;
            ChessGroup[0, 4] = Black_King;
            ChessGroup[0, 5] = Black_Guard2;
            ChessGroup[0, 6] = Black_Elephant2;
            ChessGroup[0, 7] = Black_Horse2;
            ChessGroup[0, 8] = Black_Chariot2;
            //位数组赋值
            BitChess[0] = 0x1ff;
            BitChess[2] = 0x82;
            BitChess[3] = 0x155;
            BitChess[6] = 0x155;
            BitChess[7] = 0x82;
            BitChess[9] = 0x1ff;
        }
        #endregion

        /// <summary>
        /// 非空检验
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static bool isEmpty(int x, int y)
        {
          
            if ((BitChess[y] & (1 << (width - 1 - x))) != 0)
            return false;
            return true;
        }
        /// <summary>
        /// 是否将军
        /// </summary>
        /// <returns></returns>
        public static bool Kill_King(Chess chess)
        {
            if (chess.Level1 == Chess.Level.帅)
            {
                Graphics g = Graphics.FromHwnd(ChessHandle);
                Font font = new Font("隶书", 36f);
                Brush brush = null;
                Point point = new Point(170, 240);
                if (chess.CampOwn == Chess.Camp.黑棋)
                {
                    brush = new SolidBrush(Color.Red);
                    g.DrawString("红棋胜利", font, brush, point);
                }
                else
                {
                    brush = new SolidBrush(Color.Black);
                    g.DrawString("黑棋胜利", font, brush, point);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 清空棋子对象
        /// </summary>
        public static void ClearChess()
        {
            //清空位数组
            for (int i = 0; i < height; i++)
            {
                BitChess[i] = 0;
            }
            //清空对象组
            for (int i = 0; i < height; i++)
            {
                for (int ii = 0; ii < width; ii++)
                {
                    ChessGroup[i, ii] = null;
                }
            }
            
        }
    }
}
