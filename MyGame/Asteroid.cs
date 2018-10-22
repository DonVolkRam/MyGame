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

        /// <summary>
        /// Конструкктор объекта асткроида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size) { Power = 1; }
        /// <summary>
        /// Конструкктор объекта асткроида
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер</param>
        public Asteroid(Point pos, Size size) : base(pos, size) { Power = 1; }
        /// <summary>
        /// отрисовка астероида
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Image image = Image.FromFile("..\\..\\asteroid.bmp");
            Game.Buffer.Graphics.DrawImage(image, Pos);

 //           Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// обновление положения астероида
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < Size.Width) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < Size.Height) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
