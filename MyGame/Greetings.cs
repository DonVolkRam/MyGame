using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Greetings : Form
    {
        /// <summary>
        /// ширина окна
        /// </summary>
        public new static int Width { get; set; }
        /// <summary>
        /// высота окна
        /// </summary>
        public new static int Height { get; set; }

        public Greetings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height

            };
            
            Game.Init(form);
            //form.Show();
            Game.Draw();
            form.ShowDialog();
            this.Close();
            //Application.Run(form);

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update_();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (Star obj in _star)
                obj?.Draw1();
            Buffer.Render();
        }
        /// <summary>
        /// обновление объектов
        /// </summary>
        public static void Update_()
        {
            foreach (Star obj in _star)
                obj?.Update1();
        }

        private static List<Star> _star;

        private void Greetings_Shown(object sender, EventArgs e)
        {
            this.CenterToScreen();
            _star = new List<Star>();
            for (int i = 0; i < 50; i++)
                _star.Add(new Star(9));

            Timer _timer = new Timer();
            Random Rnd = new Random();

            //Timer timer = new Timer { Interval = 100 };

            _timer.Start();
            _timer.Tick += Timer_Tick;
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = ClientSize.Width;
            Height = ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

        }
        /// <summary>
        /// кнопка выхода из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Вывод информации о рекордах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Record_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Текущий рекорд " + File.ReadAllText("..\\..\\score.dat")+ " очков");
        }
    }
}
