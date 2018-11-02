using System.Drawing;

namespace MyGame
{
    class Medicine : BaseObject
    {
        /// <summary>
        /// начальное значени силы аптечки
        /// </summary>
        private int Power = 20;
        /// <summary>
        /// конструктор с задаваемыми параметрами
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Medicine(Point pos, Point dir, Size size) : base(pos, dir, size) { LoadImage("..\\..\\kit.png"); }
        /// <summary>
        /// конструктор со случайными параметрами
        /// </summary>
        public Medicine() : base()
        {
            LoadImage("..\\..\\kit.png");
            Dir.X = -5;
            Size.Height = Size.Width = 40;
            Power = Rnd.Next(20, 40);
        }
        /// <summary>
        /// обновелние положения аптечки
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width) Pos.X = Game.Width + Size.Width;
            //            if (Pos.X > Game.Width) Dir.X = -Dir.X;
        }
        /// <summary>
        /// метод лечения корабля
        /// </summary>
        /// <param name="ship">корабль который нужно личить</param>
        public void Heal(ref Ship ship)
        {
            ship.EnergyHight(this.Power);
        }
    }
}
