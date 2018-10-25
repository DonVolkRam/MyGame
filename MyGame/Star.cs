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
        Image image = Image.FromFile("..\\..\\star.bmp");
        /// <summary>
        /// Конструкктор звеездного объекта
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size){}
        /// <summary>
        /// Конструкктор звездного объекта
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер объекта</param>
        public Star(Point pos, Size size) : base(pos, size) { }
        /// <summary>
        /// отрисовка звезды
        /// </summary>
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width,
            //Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X,
            //Pos.Y + Size.Height);            
            Game.Buffer.Graphics.DrawImage(image, Pos);
        }
        /// <summary>
        /// обновелние положения звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
//            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }
    }
}
