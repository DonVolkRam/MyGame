using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Star : BaseObject
    {
        /// <summary>
        /// Конструкктор звеездного объекта
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { ChoseRandomImage(); }
        /// <summary>
        /// Конструкктор звездного объекта
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер объекта</param>
        public Star(Point pos, Size size) : base(pos, size) { ChoseRandomImage(); }

        static Star()
        {
            Rnd = new Random();
        }
        /// <summary>
        /// создание объектов в приветственном окне
        /// </summary>
        /// <param name="a"></param>
        public Star(int a) : base(a)
        {
            ChoseRandomImage();
            Dir.X /= 2;


            Size.Width *= Dir.X;
            Size.Height *= Dir.X;
            Size.Width *= -1;
            Size.Height *= -1;
        }
        public Star() : base()
        {
            ChoseRandomImage();
//            if (Dir.X == 0)
//                Dir.X = -1;
            Dir.X /= 2;


            Size.Width *= Dir.X;
            Size.Height *= Dir.X;
        }
        /// <summary>
        /// выбор случайного изображения
        /// </summary>
        void ChoseRandomImage()
        {
            int n = Rnd.Next() % 5;

            switch (n)
            {
                case 0: LoadImage("..\\..\\star_w.png"); break;
                case 1: LoadImage("..\\..\\star_y.png"); break;
                case 2: LoadImage("..\\..\\star_b.png"); break;
                case 3: LoadImage("..\\..\\star_r.png"); break;
                default: LoadImage("..\\..\\star_w.png"); break;
            }
        }
        /// <summary>
        /// обновелние положения звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width) Pos.X = Game.Width + Size.Width;
            //            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }
        /// <summary>
        /// обновления для приветственного окна
        /// </summary>
        public void Update1()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width) Pos.X = Greetings.Width + Size.Width;
            //            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }
    }
}
