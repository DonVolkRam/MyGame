using System.Drawing;
namespace MyGame
{
    class Ship : BaseObject
    {
/// <summary>
/// начальное значение жизней
/// </summary>
        private int _energy = 100;


        /// <summary>
        /// путь к изображению
        /// </summary>
        string ImgName = "..\\..\\ship.png";
        public int Energy => _energy;

        /// <summary>
        /// метод понижения количества жизней
        /// </summary>
        /// <param name="n"></param>
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        /// <summary>
        /// Конструктор корабля
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Перемещения</param>
        /// <param name="size">Начальный размер</param>
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            LoadImage(ImgName);
        }
        /// <summary>
        /// Метод отрисовки корабля и прямоугольника колизии
        /// </summary>
        //public override void Draw()
        //{
        //        Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y, Size.Width, Size.Height);
        //        Game.Buffer.Graphics.DrawRectangle(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        //}

        public override void Update()
        {
        }

        /// <summary>
        /// кнопка вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        /// <summary>
        /// кнопка вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        /// <summary>
        /// кнопка вправо
        /// </summary>
        public void Right()
        {
            if (Pos.X < Game.Width) Pos.X = Pos.X + Dir.X;
        }
        /// <summary>
        /// кнопка влево
        /// </summary>
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }
        public static event Message MessageDie;
        /// <summary>
        /// метод смерти
        /// </summary>
        public void Die()
        {
            MessageDie?.Invoke();
        }

    }
}
