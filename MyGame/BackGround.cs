using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class BackGround : BaseObject
    {        
        public BackGround (Point pos, Point dir, Size size) : base(pos, dir, size)
        { LoadImage("..\\..\\background.png"); }

        /// <summary>
        /// обновелние положения звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width)
                Pos.X = 1600/*Game.Width*/;
            //            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }

    }
}
