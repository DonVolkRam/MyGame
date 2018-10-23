using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Backcround : BaseObject
    {
        public Backcround (Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.Clear(Color.Black);
            Image image = Image.FromFile("..\\..\\background.png");
            Game.Buffer.Graphics.DrawImage(image, Pos);
        }
        /// <summary>
        /// обновелние положения звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width)
                Pos.X = Game.Width;
            //            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }

    }
}
