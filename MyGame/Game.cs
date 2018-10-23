using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace MyGame
{
    /// <summary>
    /// 
    /// </summary>
    static class Game
    {
        /// <summary>
        /// крнекси графического буфера
        /// </summary>
        private static BufferedGraphicsContext _context;

        /// <summary>
        /// графический буфер
        /// </summary>
        public static BufferedGraphics Buffer;

        // Свойства
        // Ширина и высота игрового поля
        /// <summary>
        /// ширина окна
        /// </summary>
        public static int Width { get; set; }
        /// <summary>
        /// высотта окна
        /// </summary>
        public static int Height { get; set; }
        /// <summary>
        /// констркутор
        /// </summary>
        static Game()
        {
        }
        /// <summary>
        /// интервал оновления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// инициалзация графической составляющей
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            //4.Сделать проверку на задание размера экрана в классе Game. Если высота или ширина
            //(Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение
            //ArgumentOutOfRangeException().
            if (false)
            if (form.Width > 1000 || form.Height > 1000)
            {
                throw new ArgumentOutOfRangeException();
            }

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
        }
        /// <summary>
        /// колекция объектов
        /// </summary>
        public static List<BackGround> _BG = new List<BackGround>();
        public static List<Star> _star = new List<Star>();
        public static List<Asteroid> _asteroids = new List<Asteroid>();
        public static List<Bullet> _bullet = new List<Bullet>();

        /// <summary>
        /// создание объектов
        /// </summary>
        public static void Load()
        {
            var rnd = new Random();

            _BG.Add(new BackGround(new Point(0, 0), new Point(-2, -2), new Size(1600, 1000)));
            _BG.Add(new BackGround(new Point(1600, 0), new Point(-2, -2), new Size(1600, 1000)));
            for (int i = 0; i < 10; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids.Add(new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r)));
            }
            for (int i = 1; i < 30; i++)
            {
                int r = rnd.Next(5, 50);
                _star.Add(new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3)));
            }
            for (int i = 1; i < 60; i++)
            {
                _bullet.Add(new Bullet(new Point(0, i * 20), new Point(5, 0), new Size(8, 2)));
            }
        }
        /// <summary>
        /// отрисовка объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _BG)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            foreach (Star obj in _star)
                obj.Draw();
            foreach (Bullet obj in _bullet)
                obj.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// обновление объектов
        /// </summary>
        public static void Update()
        {
            Random rnd = new Random();
            foreach (BaseObject obj in _BG)
                obj.Update();
            for (int i = 0; i < _asteroids.Count; i++)
            {

                _asteroids[i].Update();
                for (int j = 0; j < _bullet.Count; j++)
                {
                    //3.Сделать так, чтобы при столкновении пули с астероидом они 
                    //регенерировались в разных концах экрана.
                    if (_asteroids[i].Collision(_bullet[j]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        int r = rnd.Next(15, 50);
                        _asteroids[i] = new Asteroid(new Point(Game.Width, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
                        _bullet[j] = new Bullet(new Point(0, r * 20), new Point(5, 0), new Size(8, 2));
                    }
                }
            }
            foreach (Star obj in _star)
                obj.Update();
            foreach (Bullet obj in _bullet)
                obj.Update();
        }
    }
}