﻿using System;
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
        /// <summary>
        /// Конструкктор объекта астероида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            ChoseRandomImage();
            Power = 1;
        }
        /// <summary>
        /// Конструкктор объекта астероида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер</param>
        public Asteroid(Point pos, Size size) : base(pos, size)
        {
            ChoseRandomImage();
            Power = 1;
        }

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
        public Asteroid() : base()
        {
            ChoseRandomImage();
            Power = 1;
            Dir.X /= 2;
            Dir.Y /= 2;
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
