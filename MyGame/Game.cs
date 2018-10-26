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
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

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

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();

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

            //            Timer timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
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
            form.KeyDown += Form_KeyDown;
        }
        /// <summary>
        /// колекция объектов
        /// </summary>
        private static List<BaseObject> _obj;
        private static List<Asteroid> _asteroids;
        private static List<Bullet> _bullet;

        public static List<BackGround> _BG = new List<BackGround>();
        //public static List<Star> _star = new List<Star>();
        //public static List<Asteroid> _asteroids = new List<Asteroid>();
        //public static List<Bullet> _bullet = new List<Bullet>();


        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        /// <summary>
        /// создание объектов
        /// </summary>
        public static void Load()
        {
            _obj = new List<BaseObject>();
            _asteroids = new List<Asteroid>();
            _bullet = new List<Bullet>();

            var rnd = new Random();


            int starCount = 200;
            int asteroidCount = 30;
            _BG.Add(new BackGround(new Point(0, 0), new Point(-1, -1), new Size(1600, 1000)));
            _BG.Add(new BackGround(new Point(1600, 0), new Point(-1, -1), new Size(1600, 1000)));
            for (int i = 0; i < starCount; i++)
            {
                _obj.Add(new Star());
            }

            for (int i = 0; i < asteroidCount; i++)
            {
                Asteroid asteroid = new Asteroid();
                _obj.Add(asteroid);
                _asteroids.Add(asteroid);
            }

            //for (int i = 1; i < 60; i++)
            //{
            //    _bullet.Add(new Bullet(new Point(0, i * 20), new Point(5, 0), new Size(8, 2)));
            //}
        }
        /// <summary>
        /// отрисовка объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (BackGround obj in _BG)
                obj?.Draw();

            
            foreach (BaseObject obj in _obj)
                obj?.Draw();


            //foreach (Asteroid obj in _asteroids)
            //    obj?.Draw();
            //foreach (Star obj in _star)
            //    obj?.Draw();
            //foreach (Bullet obj in _bullet)
            //    obj?.Draw();

            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy,
                SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }
        /// <summary>
        /// обновление объектов
        /// </summary>
        public static void Update()
        {

            //Random rnd = new Random();
            //foreach (BaseObject obj in _BG)
            //    obj.Update();
            //for (int i = 0; i < _asteroids.Count; i++)
            //{
            //    if (_asteroids[i] == null) continue;
            //    _asteroids[i]?.Update();
            //    for (int j = 0; j < _bullet?.Count; j++)
            //    {
            //        //3.Сделать так, чтобы при столкновении пули с астероидом они 
            //        //регенерировались в разных концах экрана.
            //        if (_asteroids[i].Collision(_bullet[j]))
            //        {
            //            System.Media.SystemSounds.Hand.Play();
            //            int r = rnd.Next(15, 50);
            //            _asteroids[i] = new Asteroid(new Point(Game.Width, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            //            //                       _bullet[j] = new Bullet(new Point(0, r * 20), new Point(5, 0), new Size(8, 2));
            //            _bullet.RemoveAt(j);
            //            continue;
            //        }
            //    }
            //    if (!_ship.Collision(_asteroids[i])) continue;
            //    _ship?.EnergyLow(rnd.Next(1, 10));
            //    System.Media.SystemSounds.Asterisk.Play();
            //    if (_ship.Energy <= 0) _ship?.Die();
            //}
            //foreach (Star obj in _star)
            //    obj?.Update();
            //foreach (Bullet obj in _bullet)
            //    obj?.Update();
            foreach (BackGround obj in _BG)
                obj?.Update();
            foreach (BaseObject obj in _obj)
            {
                obj.Update();
            }
            for (int i = 0; i < _asteroids.Count; i++)
            {
                for (int j = 0; j < _bullet?.Count; j++)
                {
                    if (_bullet[j]?.Collision(_asteroids[i]) == true)
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = new Asteroid();
                    }
                }
            }

        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _bullet.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(8, 0), new Size(8, 2)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

    }
}