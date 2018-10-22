﻿using System;
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
        public static List<BaseObject> _objs = new List<BaseObject>();
        public static List<Bullet> _bullet = new List<Bullet>();
//        public static List<BaseObject> _asteroids = new List<BaseObject>();
        /// <summary>
        /// создание объектов
        /// </summary>
        public static void Load()
        {
            //_objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length; i++)
            //    _objs[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 -
            //    i), new Size(20, 20));

            //_objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length; i++)
            //    _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(20,
            //    20));

//            objs = new BaseObject[30];
            Bullet _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            var rnd = new Random();

            _objs.Add(new Backcround(new Point(0, 0), new Point(-2, -2), new Size(1600, 1000)));
            for (int i = 0; i < 3; i++)
            {
                int r = rnd.Next(5, 50);
                _objs.Add(new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r)));
            }
            for (int i = 1; i < 30; i ++)
            {
                int r = rnd.Next(5, 50);
                _objs.Add(new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3)));
            }

        }
        /// <summary>
        /// отрисовка объектов
        /// </summary>
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// обновление объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}