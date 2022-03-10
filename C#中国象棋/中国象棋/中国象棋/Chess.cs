using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 中国象棋
{
    class Chess
    {
        public static string info;

        private Size _size;
        public Size Size//大小
        {
            get { return _size; }
            set { _size = value; }
        }

        private Point _location;
        public Point Location//位置
        {
            get { return _location; }
            set { _location = value; }
        }
        public enum Level
        {
            帅 = 1, 士 = 2, 相 = 3, 马 = 4, 车 = 5, 炮 = 6, 兵 = 7
        }
        private Level _level;
        internal Level Level1//等级
        {
            get { return _level; }
            set { _level = value; }
        }
        public enum Camp
        {
            红棋 = 1, 黑棋 = 0
        }
        private Camp _campOwn;
        public Camp CampOwn//阵营
        {
            get { return _campOwn; }
            set { _campOwn = value; }
        }
        
      

        /// <summary>
        /// 构造方法
        /// </summary>
        public Chess(Level level, Point location, Camp camp)
        {
            this.Level1 = level;
            this._location = location;
            this._campOwn = camp;
            this._size = new Size(Battlefield.chessSize, Battlefield.chessSize);
        }

        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="handle"></param>
        public void Draw(IntPtr handle)
        {
            Graphics g = Graphics.FromHwnd(handle);
            Image QIZI = Image.FromFile(@"pic\子\" + getLevelString() + ".png");
            g.DrawImage(QIZI, new Point(this.Location.X + 2, this.Location.Y + 1));
           
        }

        /// <summary>
        /// 根据棋子等级和阵营返回显示字符串
        /// </summary>
        /// <returns></returns>
        public string getLevelString()
        {
            string str = "";
            if (this.CampOwn == Camp.红棋)
                switch (this._level)
                {
                    case Level.帅:
                        str = "帅";
                        break;
                    case Level.士:
                        str = "仕";
                        break;
                    case Level.相:
                        str = "相";
                        break;
                    case Level.马:
                        str = "红马";
                        break;
                    case Level.车:
                        str = "红車";
                        break;
                    case Level.炮:
                        str = "炮";
                        break;
                    case Level.兵:
                        str = "兵";
                        break;
                }
            else
                switch (this._level)
                {
                    case Level.帅:
                        str = "将";
                        break;
                    case Level.士:
                        str = "士";
                        break;
                    case Level.相:
                        str = "象";
                        break;
                    case Level.马:
                        str = "黑马";
                        break;
                    case Level.车:
                        str = "黑車";
                        break;
                    case Level.炮:
                        str = "砲";
                        break;
                    case Level.兵:
                        str = "卒";
                        break;
                }
            return str;
        }
        public string getNumber(int a)
        {
            string str = "";
            if (this.CampOwn == Camp.红棋)
                switch (a)
                {
                    case 0:
                        str = "九";
                        break;
                    case 1:
                        str = "八";
                        break;
                    case 2:
                        str = "七";
                        break;
                    case 3:
                        str = "六";
                        break;
                    case 4:
                        str = "五";
                        break;
                    case 5:
                        str = "四";
                        break;
                    case 6:
                        str = "三";
                        break;
                    case 7:
                        str = "二";
                        break;
                    case 8:
                        str = "一";
                        break;
                }
            else
                switch (a)
                {
                    case 0:
                        str = "1";
                        break;
                    case 1:
                        str = "2";
                        break;
                    case 2:
                        str = "3";
                        break;
                    case 3:
                        str = "4";
                        break;
                    case 4:
                        str = "5";
                        break;
                    case 5:
                        str = "6";
                        break;
                    case 6:
                        str = "7";
                        break;
                    case 7:
                        str = "8";
                        break;
                    case 8:
                        str = "9";
                        break;
                }

            return str;
        }

        /// <summary>
        /// 选中棋子
        /// </summary>
        /// <param name="handle"></param>
        public void Choise(IntPtr handle)
        {
            Graphics g = Graphics.FromHwnd(handle);
            Rectangle rect = new Rectangle(this.Location.X + 4, this.Location.Y + 1,Battlefield.chessSize - 10, Battlefield.chessSize - 10);
            Pen pen = new Pen(Color.Red,2f);
            g.DrawRectangle(pen, rect);
        }
        /// <summary>
        /// 橡皮擦，替换背景实现走子
        /// </summary>
        /// <param name="handle"></param>
        public void Eraser(IntPtr handle)
        {
            
            int x = (this.Location.X - 10) / Battlefield.chessSize;
            int y = (this.Location.Y - 10) / Battlefield.chessSize;
            string Pic = Convert.ToString(y) + Convert.ToString(x);
            Graphics backgroundpic = Graphics.FromHwnd(handle);
            Image img = Image.FromFile(@"pic\bg\" + Pic + ".jpg");
            backgroundpic.DrawImage(img, new Point(this.Location.X+3, this.Location.Y));
        }

        /// <summary>
        /// 棋子移动规则
        /// </summary>
        /// <returns></returns>
        public bool Move(int Delta_X, int Delta_Y)
        {
            int X = (this.Location.X-10 ) / Battlefield.chessSize;
            int Y = (this.Location.Y-10) / Battlefield.chessSize;
            bool BeMove = false;
            switch (this._level)
            {
                case Level.帅:
                    BeMove = King_Move(X, Y, Delta_X, Delta_Y);
                    break;
                case Level.士:
                    BeMove = Guard_Move(X, Y, Delta_X, Delta_Y);
                    break;
                case Level.相:
                    BeMove = Elephant_Move(X, Y, Delta_X, Delta_Y);
                    break;
                case Level.马:
                    BeMove = Horse_Move(X, Y, Delta_X, Delta_Y);
                    break;
                case Level.车:
                    BeMove = Chariot_Move(X, Y, Delta_X, Delta_Y);
                    break;
                case Level.炮:
                    BeMove = Cannon_Move(X, Y, Delta_X, Delta_Y);
                    break;
                case Level.兵:
                    BeMove = Soldier_Move(X, Y, Delta_X, Delta_Y);
                    break;
            }
            if(BeMove)
            {
                if (Y == Delta_Y)
                {

                    info += getLevelString() + getNumber(X) + "平" + getNumber( Delta_X) + " ；";
                }
                else
                if (this.CampOwn == Camp.红棋)
                {
                    if (Delta_Y < Y)
                    {
                        int jian = Y - Delta_Y;
                        info += getLevelString() + getNumber(X) + "进" + jian + " ；";
                    }
                    else
                    {
                        int jian = Delta_Y - Y;
                        info += getLevelString() + getNumber(X) + "退" + jian + " ；";
                    }
                }
                else
                {
                    if (Delta_Y < Y)
                    {                
                        int jian = Y - Delta_Y;
                        info += getLevelString() + getNumber(X) + "退" + jian + " ；";
                    }
                    else
                    {
                        int jian = Delta_Y - Y;

                        info += getLevelString() + getNumber(X) + "进" + jian + " ；";
                    }

                }
            }
            return BeMove;
        }
        #region 棋子移类规则
        /// <summary>
        /// 帅移动
        /// </summary>
        private bool King_Move(int X, int Y, int Delta_X, int Delta_Y)
        {  
            
                if (this.CampOwn == Camp.红棋)
            {   //红棋不出宫殿
                if ((Delta_Y == 7 || Delta_Y == 8 || Delta_Y == 9) && (Delta_X == 3 || Delta_X == 4 || Delta_X == 5))
                    if (Y == Delta_Y && ((X - 1) == Delta_X || (X + 1) == Delta_X))
                        return true;

                    else if (X == Delta_X && ((Y - 1) == Delta_Y || (Y + 1) == Delta_Y))
                        return true;
            }
            else
            {   //黑棋不出宫殿
                if ((Delta_Y == 0 || Delta_Y == 1 || Delta_Y == 2) && (Delta_X == 3 || Delta_X == 4 || Delta_X == 5))
                    if (Y == Delta_Y && ((X - 1) == Delta_X || (X + 1) == Delta_X))
                        return true;
                    else if (X == Delta_X && ((Y - 1) == Delta_Y || (Y + 1) == Delta_Y))
                        return true;
            }
            if (Delta_X == X && Delta_Y != Y && Battlefield.ChessGroup[Delta_Y, Delta_X].Level1 == Level.帅)
            {   //副驾亲征
                if (Delta_Y > Y)
                {
                    for (int i = Y + 1; i < Delta_Y; i++)
                        if (!Battlefield.isEmpty(X, i))
                            return false;
                }
                else
                {
                    for (int i = Y - 1; i > Delta_Y; i--)
                        if (!Battlefield.isEmpty(X, i))
                            return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 士移动
        /// </summary>
        private bool Guard_Move(int X, int Y, int Delta_X, int Delta_Y)
        {
            //宫殿斜轴移动
            if (this.CampOwn == Camp.红棋)
            {   
                if ((Delta_Y == 7 || Delta_Y == 8 || Delta_Y == 9) && (Delta_X == 3 || Delta_X == 4 || Delta_X == 5))
                    if (((X - 1) == Delta_X && (Y - 1) == Delta_Y) || ((X + 1) == Delta_X && (Y + 1) == Delta_Y) || ((X + 1) == Delta_X && (Y - 1) == Delta_Y) || ((X - 1) == Delta_X && (Y + 1) == Delta_Y))
                        return true;
            }
            else
            {   
                if ((Delta_Y == 0 || Delta_Y == 1 || Delta_Y == 2) && (Delta_X == 3 || Delta_X == 4 || Delta_X == 5))
                    if (((X - 1) == Delta_X && (Y - 1) == Delta_Y) || ((X + 1) == Delta_X && (Y + 1) == Delta_Y) || ((X + 1) == Delta_X && (Y - 1) == Delta_Y) || ((X - 1) == Delta_X && (Y + 1) == Delta_Y))
                        return true;
            }
            return false;
        }

        /// <summary>
        /// 相移动
        /// </summary>
        /// <returns></returns>
        private bool Elephant_Move(int X, int Y, int Delta_X, int Delta_Y)
        {   //移动范围限制,不能过河
            if ((this.CampOwn == Camp.红棋) && (Delta_Y == 0 || Delta_Y == 1 || Delta_Y == 2 || Delta_Y == 3 || Delta_Y == 4))
                return false;
            else if ((this.CampOwn == Camp.黑棋) && (Delta_Y == 5 || Delta_Y == 6 || Delta_Y == 7 || Delta_Y == 8 || Delta_Y == 9))
                return false;
            //走田且中间不能有棋子
            if ((Delta_X == X - 2) && (Delta_Y == Y - 2))
            {   
                if (Battlefield.isEmpty(X - 1, Y - 1))
                    return true;
            }
            else if ((Delta_X == X + 2) && (Delta_Y == Y - 2))
            {
                if (Battlefield.isEmpty(X + 1, Y - 1))
                    return true;
            }
            else if ((Delta_X == X - 2) && (Delta_Y == Y + 2))
            {
                if (Battlefield.isEmpty(X - 1, Y + 1))
                    return true;
            }
            else if ((Delta_X == X + 2) && (Delta_Y == Y + 2))
            {
                if (Battlefield.isEmpty(X + 1, Y + 1))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 马移动
        /// </summary>
        /// <returns></returns>
        private bool Horse_Move(int X, int Y, int Delta_X, int Delta_Y)
        {   //马走日且不能别马脚
            if ((Delta_Y == Y - 2) && (Delta_X == X + 1 || Delta_X == X - 1))
            {   
                if (Battlefield.isEmpty(X, Y - 1))
                    return true;
            }
            else if ((Delta_Y == Y + 2) && (Delta_X == X + 1 || Delta_X == X - 1))
            {
                if (Battlefield.isEmpty(X, Y + 1))
                    return true;
            }
            else if ((Delta_X == X - 2) && (Delta_Y == Y + 1 || Delta_Y == Y - 1))
            {
                if (Battlefield.isEmpty(X - 1, Y))
                    return true;
            }
            else if ((Delta_X == X + 2) && (Delta_Y == Y + 1 || Delta_Y == Y - 1))
            {
                if (Battlefield.isEmpty(X + 1, Y))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 車移动
        /// </summary>
        /// <returns></returns>
        private bool Chariot_Move(int X, int Y, int Delta_X, int Delta_Y)
        {   
            if (Delta_X != X && Delta_Y == Y)
            {   //左右
                if (Delta_X > X)
                {
                    for (int i = X + 1; i < Delta_X; i++)
                        if (!Battlefield.isEmpty(i, Y))
                            return false;
                }
                else
                {
                    for (int i = X - 1; i > Delta_X; i--)
                        if (!Battlefield.isEmpty(i, Y))
                            return false;
                }
                return true;
            }
            else if (Delta_X == X && Delta_Y != Y)
            {   //上下
                if (Delta_Y > Y)
                {
                    for (int i = Y + 1; i < Delta_Y; i++)
                        if (!Battlefield.isEmpty(X, i))
                            return false;
                }
                else
                {
                    for (int i = Y - 1; i > Delta_Y; i--)
                        if (!Battlefield.isEmpty(X, i))
                            return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 炮移动
        /// </summary>
        /// <returns></returns>
        private bool Cannon_Move(int X, int Y, int Delta_X, int Delta_Y)
        {
            //直走，炮架
            int barrier = -1;//炮架
            if (Delta_X != X && Delta_Y == Y)
            {   //往左，往右
                barrier = 0;
                if (Delta_X > X)
                {
                    for (int i = X + 1; i < Delta_X; i++)
                        if (!Battlefield.isEmpty(i, Y))
                            barrier++;
                }
                else
                {
                    for (int i = X - 1; i > Delta_X; i--)
                        if (!Battlefield.isEmpty(i, Y))
                            barrier++;
                }
            }
            else if (Delta_X == X && Delta_Y != Y)
            {   //往上，往下
                barrier = 0;
                if (Delta_Y > Y)
                {
                    for (int i = Y + 1; i < Delta_Y; i++)
                        if (!Battlefield.isEmpty(X, i))
                            barrier++;
                }
                else
                {
                    for (int i = Y - 1; i > Delta_Y; i--)
                        if (!Battlefield.isEmpty(X, i))
                            barrier++;
                }
            }
            //障碍为1，动作为吃子
            if (barrier == 1 && (Battlefield.ChessGroup[Delta_Y, Delta_X] != null))
            {
                if (Battlefield.ChessGroup[Delta_Y, Delta_X].CampOwn != this.CampOwn)
                    return true;
            }
            else if (barrier == 0 && (Battlefield.ChessGroup[Delta_Y, Delta_X] == null))
                return true;
            return false;
        }

        /// <summary>
        /// 兵移动
        /// </summary>
        /// <returns></returns>
        private bool Soldier_Move(int X, int Y, int Delta_X, int Delta_Y)
        {    //士兵不可后退
            if (this._campOwn == Camp.红棋)
            {   
                if (((Y - 1) == Delta_Y) && (X == Delta_X))
                    return true;
                else if ((Delta_Y <= 4) && (Y == Delta_Y) && ((X - 1) == Delta_X || (X + 1) == Delta_X))
                    return true;
            }
            else
            {   
                if (((Y + 1) == Delta_Y) && (X == Delta_X))
                    return true;
                else if ((Delta_Y >= 5) && (Y == Delta_Y) && ((X - 1) == Delta_X || (X + 1) == Delta_X))
                    return true;
            }
            return false;
        }
        #endregion
    }
}
