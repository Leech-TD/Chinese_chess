using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 中国象棋
{
    class Chess
    {
        private Size _size;
        /// <summary>
        /// 大小
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private Point _location;
        /// <summary>
        /// 位置
        /// </summary>
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// 象棋类等级
        /// </summary>
        public enum Level
        {
            帅 = 1, 士 = 2, 相 = 3, 马 = 4, 车 = 5, 炮 = 6, 兵 = 7
        }
        private Level _level;
        /// <summary>
        /// 等级
        /// </summary>
        internal Level Level1
        {
            get { return _level; }
            set { _level = value; }
        }


        private Image _imageCh;
        /// <summary>
        /// 图片
        /// </summary>
        public Image ImageCh
        {
            get { return _imageCh; }
            set { _imageCh = value; }
        }

        public enum Camp
        {
            红棋 = 1, 黑棋 = 2
        }
        private Camp _campOwn;
        /// <summary>
        /// 阵营
        /// </summary>
        public Camp CampOwn
        {
            get { return _campOwn; }
            set { _campOwn = value; }
        }


        public Chess() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        public Chess(Level level, Point location, Camp camp)
        {
            this.Level1 = level;
            this._location = location;
            this._campOwn = camp;
            this._size = new Size(GameField.chessSize, GameField.chessSize);
            this._imageCh = Image.FromFile(GameField.picPath);
        }

        /// <summary>
        /// 绘图
        /// </summary>
        /// <param name="handle"></param>
        public void Draw(IntPtr handle)
        {
            Graphics g = Graphics.FromHwnd(handle);
            Brush brush = null;
            if (this._campOwn == Camp.红棋)
                brush = new SolidBrush(Color.Red);
            else if (this._campOwn == Camp.黑棋)
                brush = new SolidBrush(Color.Black);
            Font font = new Font("黑体", 22f);
            g.DrawImage(this._imageCh, new Point(this.Location.X + 1, this.Location.Y + 1));
            g.DrawString(getLevelString(), font, brush, new Point(this.Location.X + 5, this.Location.Y + 10));
            //Rectangle rect = new Rectangle(this.Location.X, this.Location.Y, GameField.chessSize, GameField.chessSize);
        }

        /// <summary>
        /// 根据棋子等级和阵营返回显示字符串
        /// </summary>
        /// <returns></returns>
        public string getLevelString()
        {
            string str = "";
            if (this.CampOwn == Camp.黑棋)
                switch (this._level)
                {
                    case Level.帅:
                        str = "帅";
                        break;
                    case Level.士:
                        str = "士";
                        break;
                    case Level.相:
                        str = "相";
                        break;
                    case Level.马:
                        str = "马";
                        break;
                    case Level.车:
                        str = "车";
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
                        str = "仕";
                        break;
                    case Level.相:
                        str = "象";
                        break;
                    case Level.马:
                        str = "馬";
                        break;
                    case Level.车:
                        str = "車";
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

        /// <summary>
        /// 选中棋子
        /// </summary>
        /// <param name="handle"></param>
        public void Choise(IntPtr handle)
        {
            Graphics g = Graphics.FromHwnd(handle);
            Rectangle rect = new Rectangle(this.Location.X + 1, this.Location.Y + 1, GameField.chessSize - 4, GameField.chessSize - 4);
            Pen pen = new Pen(GameField.choiseColor, 2f);
            g.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// 擦除
        /// </summary>
        /// <param name="handle"></param>
        public void eraser(IntPtr handle)
        {
            Graphics g = Graphics.FromHwnd(handle);
            Image img = Image.FromFile(@"pic\bg\" + getPositionPic() + ".png");
            g.DrawImage(img, new Point(this.Location.X, this.Location.Y));
        }

        /// <summary>
        /// 获取擦除对象所在背景图片名称
        /// </summary>
        /// <returns></returns>
        public string getPositionPic()
        {
            int x = (this.Location.X - 10) / GameField.chessSize;
            int y = (this.Location.Y - 10) / GameField.chessSize;
            //判断背景图片(恐怖)
            string pic = "";
            if (y == 0 && x == 0)
            {
                pic = "角左上";
            }
            else if (y == 0 && x == 8)
            {
                pic = "角右上";
            }
            else if (y == 9 && x == 0)
            {
                pic = "角左下";
            }
            else if (y == 9 && x == 8)
            {
                pic = "角右下";
            }
            else if (y == 0 && (x == 1 || x == 2 || x == 6 || x == 7))
            {
                pic = "边上";
            }
            else if (y == 9 && (x == 1 || x == 2 || x == 6 || x == 7))
            {
                pic = "边下";
            }
            else if (x == 0 && (y == 1 || y == 2 || y == 7 || y == 8))
            {
                pic = "边左";
            }
            else if (x == 8 && (y == 1 || y == 2 || y == 7 || y == 8))
            {
                pic = "边右";
            }
            else if (((y == 2 || y == 7) && (x == 1 || x == 7)) || ((y == 3 || y == 6) && (x == 2 || x == 4 || x == 6)))
            {
                if (y == 2 || y == 3)
                    pic = "点中";
                else
                    pic = "点中1";
            }
            else if (x == 0 && (y == 3 || y == 6))
            {
                if (y == 3)
                    pic = "点左";
                else
                    pic = "点左1";
            }
            else if (x == 8 && (y == 3 || y == 6))
            {
                if (y == 3)
                    pic = "点右";
                else
                    pic = "点右1";
            }
            else if (y == 0 && (x == 3 || x == 4 || x == 5))
            {
                if (x == 3)
                    pic = "九上1";
                else if (x == 4)
                    pic = "九上2";
                else
                    pic = "九上3";
            }
            else if (y == 1 && (x == 3 || x == 4 || x == 5))
            {
                if (x == 3)
                    pic = "九上4";
                else if (x == 4)
                    pic = "九上5";
                else
                    pic = "九上6";
            }
            else if (y == 2 && (x == 3 || x == 4 || x == 5))
            {
                if (x == 3)
                    pic = "九上7";
                else if (x == 5)
                    pic = "九上9";
                else
                    pic = "边中";
            }
            else if (y == 7 && (x == 3 || x == 4 || x == 5))
            {
                if (x == 3)
                    pic = "九下1";
                else if (x == 4)
                    pic = "九下2";
                else
                    pic = "九下3";
            }
            else if (y == 8 && (x == 3 || x == 4 || x == 5))
            {
                if (x == 3)
                    pic = "九下4";
                else if (x == 4)
                    pic = "九下5";
                else
                    pic = "九下6";
            }
            else if (y == 9 && (x == 3 || x == 4 || x == 5))
            {
                if (x == 3)
                    pic = "九下7";
                else if (x == 5)
                    pic = "九下9";
                else
                    pic = "边下";
            }
            else if (y == 4 && (x == 1 || x == 2 || x == 3 || x == 4 || x == 5 || x == 6 || x == 7))
            {
                pic = "河上";
            }
            else if (y == 5 && (x == 1 || x == 2 || x == 3 || x == 4 || x == 5 || x == 6 || x == 7))
            {
                pic = "河下";
            }
            else if (x == 0 && (y == 4 || y == 5))
            {
                pic = "河左";
            }
            else if (x == 8 && (y == 4 || y == 5))
            {
                pic = "河右";
            }
            else if ((y == 6 && (x == 1 || x == 3 || x == 5 || x == 7)) || (y == 7 && (x == 2 || x == 6)) || (y == 8 && (x == 1 || x == 2 || x == 6 || x == 7)))
            {
                pic = "边中1";
            }
            else
            {
                pic = "边中";
            }
            return pic;
        }

        /// <summary>
        /// 棋子移动规则
        /// </summary>
        /// <returns></returns>
        public bool Move(int destX, int destY)
        {
            int X = (this.Location.X - 10) / GameField.chessSize;
            int Y = (this.Location.Y - 10) / GameField.chessSize;
            bool isMove = false;
            switch (this._level)
            {
                case Level.帅:
                    isMove = SuaiMove(X, Y, destX, destY);
                    break;
                case Level.士:
                    isMove = ShiMove(X, Y, destX, destY);
                    break;
                case Level.相:
                    isMove = XiangMove(X, Y, destX, destY);
                    break;
                case Level.马:
                    isMove = MaMove(X, Y, destX, destY);
                    break;
                case Level.车:
                    isMove = CheMove(X, Y, destX, destY);
                    break;
                case Level.炮:
                    isMove = PaoMove(X, Y, destX, destY);
                    break;
                case Level.兵:
                    isMove = BingMove(X, Y, destX, destY);
                    break;
            }
            return isMove;
        }

        /// <summary>
        /// 帅移动
        /// </summary>
        /// <returns></returns>
        private bool SuaiMove(int X, int Y, int destX, int destY)
        {   //(帅)九宫格X、Y轴移动
            if (this.CampOwn == Camp.黑棋)
            {   //上九宫格(黑棋)
                if ((destY == 7 || destY == 8 || destY == 9) && (destX == 3 || destX == 4 || destX == 5))
                    if (Y == destY && ((X - 1) == destX || (X + 1) == destX))
                        return true;
                    else if (X == destX && ((Y - 1) == destY || (Y + 1) == destY))
                        return true;
            }
            else
            {   //下九宫格(红棋)
                if ((destY == 0 || destY == 1 || destY == 2) && (destX == 3 || destX == 4 || destX == 5))
                    if (Y == destY && ((X - 1) == destX || (X + 1) == destX))
                        return true;
                    else if (X == destX && ((Y - 1) == destY || (Y + 1) == destY))
                        return true;
            }
            return false;
        }

        /// <summary>
        /// 士移动
        /// </summary>
        /// <returns></returns>
        private bool ShiMove(int X, int Y, int destX, int destY)
        {
            //(士)九宫格斜轴移动
            if (this.CampOwn == Camp.黑棋)
            {   //上九宫格(黑棋)
                if ((destY == 7 || destY == 8 || destY == 9) && (destX == 3 || destX == 4 || destX == 5))
                    if (((X - 1) == destX && (Y - 1) == destY) || ((X + 1) == destX && (Y + 1) == destY) || ((X + 1) == destX && (Y - 1) == destY) || ((X - 1) == destX && (Y + 1) == destY))
                        return true;
            }
            else
            {   //下九宫格(红棋)
                if ((destY == 0 || destY == 1 || destY == 2) && (destX == 3 || destX == 4 || destX == 5))
                    if (((X - 1) == destX && (Y - 1) == destY) || ((X + 1) == destX && (Y + 1) == destY) || ((X + 1) == destX && (Y - 1) == destY) || ((X - 1) == destX && (Y + 1) == destY))
                        return true;
            }
            return false;
        }

        /// <summary>
        /// 相移动
        /// </summary>
        /// <returns></returns>
        private bool XiangMove(int X, int Y, int destX, int destY)
        {   //移动范围限制,双方(相)不能过河
            if ((this.CampOwn == Camp.黑棋) && (destY == 0 || destY == 1 || destY == 2 || destY == 3 || destY == 4))
                return false;
            else if ((this.CampOwn == Camp.红棋) && (destY == 5 || destY == 6 || destY == 7 || destY == 8 || destY == 9))
                return false;
            //(相)走田
            if ((destX == X - 2) && (destY == Y - 2))
            {   //(相)中间不能有棋子
                if (GameField.isEmpty(X - 1, Y - 1))
                    return true;
            }
            else if ((destX == X + 2) && (destY == Y - 2))
            {
                if (GameField.isEmpty(X + 1, Y - 1))
                    return true;
            }
            else if ((destX == X - 2) && (destY == Y + 2))
            {
                if (GameField.isEmpty(X - 1, Y + 1))
                    return true;
            }
            else if ((destX == X + 2) && (destY == Y + 2))
            {
                if (GameField.isEmpty(X + 1, Y + 1))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 马移动
        /// </summary>
        /// <returns></returns>
        private bool MaMove(int X, int Y, int destX, int destY)
        {   //(马)走日
            if ((destY == Y - 2) && (destX == X + 1 || destX == X - 1))
            {   //(马)移动不能有马脚
                if (GameField.isEmpty(X, Y - 1))
                    return true;
            }
            else if ((destY == Y + 2) && (destX == X + 1 || destX == X - 1))
            {
                if (GameField.isEmpty(X, Y + 1))
                    return true;
            }
            else if ((destX == X - 2) && (destY == Y + 1 || destY == Y - 1))
            {
                if (GameField.isEmpty(X - 1, Y))
                    return true;
            }
            else if ((destX == X + 2) && (destY == Y + 1 || destY == Y - 1))
            {
                if (GameField.isEmpty(X + 1, Y))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 车移动
        /// </summary>
        /// <returns></returns>
        private bool CheMove(int X, int Y, int destX, int destY)
        {   //(车)直走
            if (destX != X && destY == Y)
            {   //往左，往右
                if (destX > X)
                {
                    for (int i = X + 1; i < destX; i++)
                        if (!GameField.isEmpty(i, Y))
                            return false;
                }
                else
                {
                    for (int i = X - 1; i > destX; i--)
                        if (!GameField.isEmpty(i, Y))
                            return false;
                }
                return true;
            }
            else if (destX == X && destY != Y)
            {   //往上，往下
                if (destY > Y)
                {
                    for (int i = Y + 1; i < destY; i++)
                        if (!GameField.isEmpty(X, i))
                            return false;
                }
                else
                {
                    for (int i = Y - 1; i > destY; i--)
                        if (!GameField.isEmpty(X, i))
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
        private bool PaoMove(int X, int Y, int destX, int destY)
        {
            //(炮)直走,跳吃
            int footplate = -1;//踏板数个，也就是障碍
            if (destX != X && destY == Y)
            {   //往左，往右
                footplate = 0;
                if (destX > X)
                {
                    for (int i = X + 1; i < destX; i++)
                        if (!GameField.isEmpty(i, Y))
                            footplate++;
                }
                else
                {
                    for (int i = X - 1; i > destX; i--)
                        if (!GameField.isEmpty(i, Y))
                            footplate++;
                }
            }
            else if (destX == X && destY != Y)
            {   //往上，往下
                footplate = 0;
                if (destY > Y)
                {
                    for (int i = Y + 1; i < destY; i++)
                        if (!GameField.isEmpty(X, i))
                            footplate++;
                }
                else
                {
                    for (int i = Y - 1; i > destY; i--)
                        if (!GameField.isEmpty(X, i))
                            footplate++;
                }
            }
            //踏板为1(即有一个障碍)，且目标位置的棋子的阵营与自己不同
            if (footplate == 1 && (GameField.AllChess[destY, destX] != null))
            {
                if (GameField.AllChess[destY, destX].CampOwn != this.CampOwn)
                    return true;
            }
            else if (footplate == 0 && (GameField.AllChess[destY, destX] == null))
                return true;
            return false;
        }

        /// <summary>
        /// 兵移动
        /// </summary>
        /// <returns></returns>
        private bool BingMove(int X, int Y, int destX, int destY)
        {
            if (this._campOwn == Camp.黑棋)
            {   //(黑兵)只能向上移动
                if (((Y - 1) == destY) && (X == destX))
                    return true;
                else if ((destY <= 4) && (Y == destY) && ((X - 1) == destX || (X + 1) == destX))
                  //过了河Y<4,可以左右移动
                    return true;
            }
            else
            {   //(红兵)只能向下移动
                if (((Y + 1) == destY) && (X == destX))
                    return true;
                else if ((destY >= 5) && (Y == destY) && ((X - 1) == destX || (X + 1) == destX))
                  //过了河Y<4,可以左右移动
                    return true;
            }
            return false;
        }
    }
}
