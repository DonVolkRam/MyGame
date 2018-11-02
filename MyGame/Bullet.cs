using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Класс описатель пули
    /// </summary>
    class Bullet : BaseObject
    {
        /// <summary>
        /// Конструирует Пулю
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Напрвление движение</param>
        /// <param name="size">Размер пули</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Отрисовка пули
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width,
            Size.Height);
        }
        /// <summary>
        /// Обновление пули
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }
        /// <summary>
        /// метод проверки вылета пули за передлы экрана
        /// </summary>
        /// <returns></returns>
        public bool OutofScreen()
        {
            if (Pos.X > Game.Width + 100) //100 для запаса
                return true;
            return false;
        }
    }

}
