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
        public int Power { get; set; }
        string sImg = "..\\..\\asteroid.bmp";
        /// <summary>
        /// Конструкктор объекта астероида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            LoadImage(sImg);
            Power = 1;
        }
        /// <summary>
        /// Конструкктор объекта астероида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер</param>
        public Asteroid(Point pos, Size size) : base(pos, size)
        {
            LoadImage(sImg);
            Power = 1;
        }

        public Asteroid() : base()
        {
            LoadImage(sImg);
            Power = 1;
            Size.Width *= Dir.X;
            Size.Height *= Dir.X;
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
    }
}
