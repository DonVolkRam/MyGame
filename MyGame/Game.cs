using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

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
        /// <summary>
        /// ширина окна
        /// </summary>
        public static int Width { get; set; }
        /// <summary>
        /// высота окна
        /// </summary>
        public static int Height { get; set; }
        /// <summary>
        /// очки за астероиды
        /// </summary>
        public static int Score { get; set; }
        /// <summary>
        /// текущее количество астероидов
        /// </summary>
        public static int AsteroidCount { get; set; }
        /// <summary>
        /// создаем журнал событий
        /// </summary>
        public static Journal _journal = new Journal();
        /// <summary>
        /// констркутор
        /// </summary>
        static Game()
        {
        }
        private static Ship _ship;
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
        /// таймер
        /// </summary>
        private static Timer _timer = new Timer();
        /// <summary>
        /// переменная для случайных значений
        /// </summary>
        public static Random Rnd = new Random();
        /// <summary>
        /// инициалзация графической составляющей
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            //Timer timer = new Timer { Interval = 100 };            
            Score = 0;
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
        public static List<BackGround> _BG;
        public static List<Medicine> _kit;
        //public static List<Star> _star = new List<Star>();

        /// <summary>
        /// Метод окончания игры
        /// </summary>
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Graphics.DrawString($"Your Score {Score}", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 200, 200);
            Buffer.Render();
            File.WriteAllText("..\\..\\score.dat", Score.ToString());
            Greetings Gre = new Greetings();
            Gre.ShowDialog();
        }
        /// <summary>
        /// создание объектов
        /// </summary>
        public static void Load()
        {
            _BG = new List<BackGround>();
            _obj = new List<BaseObject>();
            _asteroids = new List<Asteroid>();
            _bullet = new List<Bullet>();
            _kit = new List<Medicine>();

            _ship = new Ship(new Point(10, 400), new Point(10, 10), new Size(160, 50));

            var rnd = new Random();

            int starCount = 200;
            int asteroidCount = AsteroidCount = 20;
            int kitCount = 5;
            _BG.Add(new BackGround(new Point(0, 0), new Point(-1, -1), new Size(1600, 1000)));
            _BG.Add(new BackGround(new Point(1600, 0), new Point(-1, -1), new Size(1600, 1000)));
            //_BG.Add(new Cloud(new Point(0, 0), new Point(-2, -2), new Size(1600, 1000), 1));
            //_BG.Add(new Cloud(new Point(1600, 0), new Point(-2, -2), new Size(1600, 1000), 2));
            for (int i = 0; i < starCount; i++)
                _obj.Add(new Star());
            for (int i = 0; i < asteroidCount; i++)
                _asteroids.Add(new Asteroid(true));
            for (int i = 0; i < kitCount; i++)
                _kit.Add(new Medicine()); 
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
            foreach (Asteroid obj in _asteroids)
                obj?.Draw();
            foreach (Bullet obj in _bullet)
                obj?.Draw();
            foreach (Medicine obj in _kit)
                obj?.Draw();
            //foreach (Star obj in _star)
            //    obj?.Draw();
            _ship?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Score:" + Score,
                                SystemFonts.DefaultFont, Brushes.White, 0, 20);

                Buffer.Graphics.DrawString("Energy:" + _ship.Energy,
                SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }
            Buffer.Render();
        }
        /// <summary>
        /// обновление объектов
        /// </summary>
        public static void Update()
        {
            Random rnd = new Random();
            bool Bcontinue = true;
            foreach (BackGround obj in _BG)
                obj?.Update();
            foreach (BaseObject obj in _obj)
                obj.Update();
            foreach (Asteroid obj in _asteroids)
                obj.Update();
            foreach (Bullet obj in _bullet)
                obj.Update();
            foreach (Medicine obj in _kit)
                obj?.Update();
            //задание 4 создание астероидов на 1 больше после их уничтожения
            if (_asteroids.Count != 0)
            {
                for (int i = 0; i < _asteroids?.Count && Bcontinue; i++)
                {
                    for (int j = 0; j < _bullet?.Count; j++)
                    {
                        if (_bullet[j].Collision(_asteroids[i]))
                        //                        if (_asteroids[i].Collision(_bullet[j]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            if (_asteroids[i].DecreasePower())
                            {
                                _journal.Write += _asteroids[i].WriteDESTROY;
                                _asteroids.RemoveAt(i);
                                _bullet.RemoveAt(j);
                                //_asteroids[i] = new Asteroid(false);
                                Score++;
                                Bcontinue = false;
                                break;
                            }
                            else
                            {
                                _bullet.RemoveAt(j);
                                Bcontinue = false;
                                break;
                            }
                        }
                        if (_bullet[j].OutofScreen())
                        {
                            _bullet.RemoveAt(j);
                            //Bcontinue = false;
                            //break;
                        }
                    }
                    if (Bcontinue == false)
                        break;
                    if (_ship.Collision(_asteroids[i]))
                    {
                        if (_asteroids[i].DecreasePower())
                        {
                            _asteroids.RemoveAt(i);
                            //_asteroids[i] = new Asteroid(false);
                            System.Media.SystemSounds.Asterisk.Play();
                            _ship?.EnergyLow(rnd.Next(10, 20));
                            Bcontinue = false;
                            break;
                        }
                    }
                    if (Bcontinue == false)
                        break;
                }
            }
            else
            {
                AsteroidCount++;
                for (int i = 0; i < AsteroidCount; i++)
                    _asteroids.Add(new Asteroid(false));
            }
            for (int j = 0; j < _kit?.Count; j++)
            {
                if (_ship.Collision(_kit[j]))
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    _journal.Write += _ship.WriteAPPLY;
                    _kit[j].Heal(ref _ship);
                    _kit[j] = new Medicine();
                    //_kit.RemoveAt(i);
                }
            }
            if (_ship.Energy <= 0)
            {
                //                    System.Media.SystemSounds.Exclamation.Play();
                _ship?.Die();
                Finish();
            }
            _journal.Start();
        }
        /// <summary>
        /// метод обработки нажатия стрелочных клавиш и контрола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            //_bullet.Add(new Bullet(new Point(_ship.Rect.X + 30, _ship.Rect.Y + 8), new Point(16, 0), new Size(8, 2)));

            if (e.KeyCode == Keys.ControlKey)
            {
                System.Media.SystemSounds.Beep.Play();
                _bullet.Add(new Bullet(new Point(_ship.Rect.X + 30, _ship.Rect.Y + 8), new Point(16, 0), new Size(8, 2)));
                _journal.Write += _ship.WriteFIRE;
            }
            else
            {
                _journal.Write += _ship.WriteMOVE;
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Right) _ship.Right();
            if (e.KeyCode == Keys.Left) _ship.Left();
        }
    }
}