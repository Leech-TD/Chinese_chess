using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 中国象棋
{
    class GameField
    {
        public const int width = 9;
        public const int height = 10;
        public const int chessSize = 57;
        public const string picPath = @"pic\棋子.png";
        public static Color choiseColor = Color.Blue;

        public static Chess[,] AllChess = new Chess[height, width];
        public static int[] BitChess = new int[height];
        public static IntPtr chessHandle;


        #region 初始化
        /// <summary>
        /// 初始化棋盘
        /// </summary>
        public static void resetChessBoard()
        {
            //红方
            Chess chr_general = new Chess(Chess.Level.帅, new Point(10 + chessSize * 4, 10), Chess.Camp.红棋);
            Chess chr_protecter1 = new Chess(Chess.Level.士, new Point(10 + chessSize * 3, 10), Chess.Camp.红棋);
            Chess chr_protecter2 = new Chess(Chess.Level.士, new Point(10 + chessSize * 5, 10), Chess.Camp.红棋);
            Chess chr_elephant1 = new Chess(Chess.Level.相, new Point(10 + chessSize * 2, 10), Chess.Camp.红棋);
            Chess chr_elephant2 = new Chess(Chess.Level.相, new Point(10 + chessSize * 6, 10), Chess.Camp.红棋);
            Chess chr_house1 = new Chess(Chess.Level.马, new Point(10 + chessSize, 10), Chess.Camp.红棋);
            Chess chr_house2 = new Chess(Chess.Level.马, new Point(10 + chessSize * 7, 10), Chess.Camp.红棋);
            Chess chr_car1 = new Chess(Chess.Level.车, new Point(10, 10), Chess.Camp.红棋);
            Chess chr_car2 = new Chess(Chess.Level.车, new Point(10 + chessSize * 8, 10), Chess.Camp.红棋);
            Chess chr_gun1 = new Chess(Chess.Level.炮, new Point(10 + chessSize, 10 + chessSize * 2), Chess.Camp.红棋);
            Chess chr_gun2 = new Chess(Chess.Level.炮, new Point(10 + chessSize * 7, 10 + chessSize * 2), Chess.Camp.红棋);
            Chess chr_soldier1 = new Chess(Chess.Level.兵, new Point(10, 10 + chessSize * 3), Chess.Camp.红棋);
            Chess chr_soldier2 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 2, 10 + chessSize * 3), Chess.Camp.红棋);
            Chess chr_soldier3 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 4, 10 + chessSize * 3), Chess.Camp.红棋);
            Chess chr_soldier4 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 6, 10 + chessSize * 3), Chess.Camp.红棋);
            Chess chr_soldier5 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 8, 10 + chessSize * 3), Chess.Camp.红棋);
            chr_general.Draw(chessHandle);
            chr_protecter1.Draw(chessHandle);
            chr_protecter2.Draw(chessHandle);
            chr_elephant1.Draw(chessHandle);
            chr_elephant2.Draw(chessHandle);
            chr_house1.Draw(chessHandle);
            chr_house2.Draw(chessHandle);
            chr_car1.Draw(chessHandle);
            chr_car2.Draw(chessHandle);
            chr_gun1.Draw(chessHandle);
            chr_gun2.Draw(chessHandle);
            chr_soldier1.Draw(chessHandle);
            chr_soldier2.Draw(chessHandle);
            chr_soldier3.Draw(chessHandle);
            chr_soldier4.Draw(chessHandle);
            chr_soldier5.Draw(chessHandle);
            //黑方
            Chess chb_general = new Chess(Chess.Level.帅, new Point(10 + chessSize * 4, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_protecter1 = new Chess(Chess.Level.士, new Point(10 + chessSize * 3, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_protecter2 = new Chess(Chess.Level.士, new Point(10 + chessSize * 5, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_elephant1 = new Chess(Chess.Level.相, new Point(10 + chessSize * 2, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_elephant2 = new Chess(Chess.Level.相, new Point(10 + chessSize * 6, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_house1 = new Chess(Chess.Level.马, new Point(10 + chessSize, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_house2 = new Chess(Chess.Level.马, new Point(10 + chessSize * 7, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_car1 = new Chess(Chess.Level.车, new Point(10, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_car2 = new Chess(Chess.Level.车, new Point(10 + chessSize * 8, 10 + chessSize * 9), Chess.Camp.黑棋);
            Chess chb_gun1 = new Chess(Chess.Level.炮, new Point(10 + chessSize, 10 + chessSize * 7), Chess.Camp.黑棋);
            Chess chb_gun2 = new Chess(Chess.Level.炮, new Point(10 + chessSize * 7, 10 + chessSize * 7), Chess.Camp.黑棋);
            Chess chb_soldier1 = new Chess(Chess.Level.兵, new Point(10, 10 + chessSize * 6), Chess.Camp.黑棋);
            Chess chb_soldier2 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 2, 10 + chessSize * 6), Chess.Camp.黑棋);
            Chess chb_soldier3 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 4, 10 + chessSize * 6), Chess.Camp.黑棋);
            Chess chb_soldier4 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 6, 10 + chessSize * 6), Chess.Camp.黑棋);
            Chess chb_soldier5 = new Chess(Chess.Level.兵, new Point(10 + chessSize * 8, 10 + chessSize * 6), Chess.Camp.黑棋);
            chb_general.Draw(chessHandle);
            chb_protecter1.Draw(chessHandle);
            chb_protecter2.Draw(chessHandle);
            chb_elephant1.Draw(chessHandle);
            chb_elephant2.Draw(chessHandle);
            chb_house1.Draw(chessHandle);
            chb_house2.Draw(chessHandle);
            chb_car1.Draw(chessHandle);
            chb_car2.Draw(chessHandle);
            chb_gun1.Draw(chessHandle);
            chb_gun2.Draw(chessHandle);
            chb_soldier1.Draw(chessHandle);
            chb_soldier2.Draw(chessHandle);
            chb_soldier3.Draw(chessHandle);
            chb_soldier4.Draw(chessHandle);
            chb_soldier5.Draw(chessHandle);
            //红发对象添加至数组
            AllChess[0, 0] = chr_car1;
            AllChess[0, 1] = chr_house1;
            AllChess[0, 2] = chr_elephant1;
            AllChess[0, 3] = chr_protecter1;
            AllChess[0, 4] = chr_general;
            AllChess[0, 5] = chr_protecter2;
            AllChess[0, 6] = chr_elephant2;
            AllChess[0, 7] = chr_house2;
            AllChess[0, 8] = chr_car2;
            AllChess[2, 1] = chr_gun1;
            AllChess[2, 7] = chr_gun2;
            AllChess[3, 0] = chr_soldier1;
            AllChess[3, 2] = chr_soldier2;
            AllChess[3, 4] = chr_soldier3;
            AllChess[3, 6] = chr_soldier4;
            AllChess[3, 8] = chr_soldier5;
            //黑发对象添加至数组
            AllChess[6, 0] = chb_soldier1;
            AllChess[6, 2] = chb_soldier2;
            AllChess[6, 4] = chb_soldier3;
            AllChess[6, 6] = chb_soldier4;
            AllChess[6, 8] = chb_soldier5;
            AllChess[7, 1] = chb_gun1;
            AllChess[7, 7] = chb_gun2;
            AllChess[9, 0] = chb_car1;
            AllChess[9, 1] = chb_house1;
            AllChess[9, 2] = chb_elephant1;
            AllChess[9, 3] = chb_protecter1;
            AllChess[9, 4] = chb_general;
            AllChess[9, 5] = chb_protecter2;
            AllChess[9, 6] = chb_elephant2;
            AllChess[9, 7] = chb_house2;
            AllChess[9, 8] = chb_car2;
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
            if (x > width - 1 || x < 0)
                return false;
            if (y > height || y < 0)
                return false;
            if ((BitChess[y] & (1 << (width - 1 - x))) != 0)
                return false;
            return true;
        }


        /// <summary>
        /// 选择状态
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static Chess choise(int x, int y)
        {
            if ((BitChess[y] & (1 << (width - 1 - x))) != 0)
            {
                AllChess[y, x].Choise(chessHandle);
                return AllChess[y, x];
            }
            return null;
        }

        /// <summary>
        /// 是否将军
        /// </summary>
        /// <returns></returns>
        public static bool JiangJun(Chess chess)
        {
            if (chess.Level1 == Chess.Level.帅)
            {
                Graphics g = Graphics.FromHwnd(chessHandle);
                Font font = new Font("黑体", 36f);
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
        public static void clearChess()
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
                    AllChess[i, ii] = null;
                }
            }
        }
    }
}
