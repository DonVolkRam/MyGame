using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        private int MinSize = 15;
        public int Power { get; set; }
        /// <summary>
        /// Конструкктор объекта астероида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            ChoseRandomImage();
            setPowerBySize();

        }
        /// <summary>
        /// Конструкктор объекта астероида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер</param>
        public Asteroid(Point pos, Size size) : base(pos, size)
        {
            ChoseRandomImage();
            setPowerBySize();
        }

        public Asteroid(bool xaoc) : base()
        {
            ChoseRandomImage();
            
            if (xaoc)
                Pos = new Point(Rnd.Next(Game.Width/3, Game.Width), Convert.ToInt32(Rnd.NextDouble() * Game.Height));
           else
                Pos = new Point(Game.Width, Rnd.Next(0, Game.Height));

            Dir.X /= 2;
            Dir.Y /= 2;
            Size.Width *= Math.Abs(Dir.X);
            Size.Height *= Math.Abs(Dir.X);
            if(Size.Width< MinSize || Size.Height< MinSize)
            {
                Size.Width = MinSize;
                Size.Height = MinSize;
            }
            setPowerBySize();
        }
        /// <summary>
        /// метод выбора случайного изображения
        /// </summary>
        void ChoseRandomImage()
        {
            int n = Rnd.Next() % 4;

            switch (n)
            {
                case 0: LoadImage("..\\..\\asteroid_1.png"); break;
                case 1: LoadImage("..\\..\\asteroid_2.png"); break;
                case 2: LoadImage("..\\..\\asteroid_3.png"); break;
                case 3: LoadImage("..\\..\\asteroid_4.png"); break;
            }
        }
        /// <summary>
        /// обновление положения астероида
        /// </summary>
        public override void Update()
        {
            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < Size.Width) Dir.X = -Dir.X;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < Size.Height) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

            Pos.X += Dir.X;
            Pos.Y += Dir.Y;

            if (Pos.X < 0 || Pos.X > Game.Width)
                Dir.X = -Dir.X;
            else if (Pos.Y < 0 || Pos.Y > Game.Height)
                Dir.Y = -Dir.Y;
        } 
        /// <summary>
        /// метод установки прочности астероида исходя из его размера
        /// </summary>
        private void setPowerBySize()
        {
            if (Size.Height < 20)
                Power = 1;
            else if (Size.Height >= 20 && Size.Height < 30)
                Power = 2;
            else
                Power = 3;
        }
        /// <summary>
        /// метод понижения прочности астероида
        /// </summary>
        /// <returns>возращает истину когда астероид уничтожен</returns>
        public bool DecreasePower()
        {
            this.Power--;
            if (Power <= 0)
                return true;
            return false;
        }
    }
}
