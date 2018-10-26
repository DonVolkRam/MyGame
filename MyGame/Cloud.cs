
using System.Drawing;


namespace MyGame
{
    /// <summary>
    /// Класс описатель туманностей
    /// </summary>
    class Cloud : BackGround
    {
        /// <summary>
        /// Конструктор Туманности
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Перемещение</param>
        /// <param name="size">Размер</param>
        /// <param name="img">Номер изображения; если 0 то случайное</param>
        public Cloud(Point pos, Point dir, Size size, int img) : base(pos, dir, size)
        { ChoseRandomImage(img); }

        /// <summary>
        /// Случайный выбиратель изображения
        /// </summary>
        /// <param name="n">номер изображения; если 0 то случайное</param>
        void ChoseRandomImage(int n)
        {
            if (n == 0)
                n = 1 + Rnd.Next() % 2;

            switch (n)
            {
                case 1: LoadImage("..\\..\\cloud_1.png"); break;
                case 2: LoadImage("..\\..\\cloud_2.png"); break;
                    //case 2: LoadImage("..\\..\\cloud_3.png"); break;
                    //case 3: LoadImage("..\\..\\cloud_4.png"); break;
            }
        }
    }
}
