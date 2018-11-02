using System;
using System.Collections;
using System.Drawing;
namespace MyGame
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    //public enum MyEnum
    //{
    //    CREATE,
    //    DESTROY,
    //    APPLY,
    //    MOVE,
    //    FIRE
    //}
    /// <summary>
    /// Класс описатель базового объекта
    /// </summary>
    abstract class BaseObject : ICollision
    {
        /// <summary>
        /// Начальная позиция
        /// </summary>
        protected Point Pos;
        /// <summary>
        /// Направление движения
        /// </summary>
        protected Point Dir;
        /// <summary>
        /// Размер
        /// </summary>
        protected Size Size;
        /// <summary>
        /// Случайное значение
        /// </summary>
        protected static Random Rnd;
        /// <summary>
        /// Изображение объекта
        /// </summary>
        protected Image Img;

        /// <summary>
        /// создание статических переменных
        /// </summary>
        static BaseObject()
        {
            Rnd = new Random();
        }

        /// <summary>
        /// Конструкктор базового объекта
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="dir">направление движения</param>
        /// <param name="size">размер объекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;

        }
        /// <summary>
        /// Конструкктор базового объекта
        /// </summary>
        /// <param name="pos">начальная позиция</param>
        /// <param name="size">размер</param>
        protected BaseObject(Point pos, Size size)
        {
            Pos = pos;
            Dir = new Point(Rnd.Next(-10, 10), Rnd.Next(-10, 10));
            Size = size;

        }

        //public void WriteToConsole(MyEnum MES)
        //{
        //    switch (MES)
        //    {
        //        case MyEnum.CREATE:
        //            Console.WriteLine($"создан объект  -  {this}"); break;
        //        case MyEnum.DESTROY:
        //            Console.WriteLine($"уничтожен объект - {this}"); break;
        //        case MyEnum.FIRE:
        //            Console.WriteLine($"{this}  -  произвел выстрел "); break;
        //        case MyEnum.MOVE:
        //            Console.WriteLine($"{this}  -  переместился "); break;
        //        case MyEnum.APPLY:
        //            Console.WriteLine($"{this}  -  применил аптечку"); break;
        //        default:
        //            break;
        //    }
        //}


        /// <summary>
        /// Методы вывода событий
        /// </summary>
        public void WriteCREATE()
        {
            Console.WriteLine($"создан объект  -  {this}");
        }
        public void WriteDESTROY()
        {
            Console.WriteLine($"уничтожен объект  - = {this}");
        }
        public void WriteFIRE()
        {
            Console.WriteLine($"{this}  -  произвел выстрел ");
        }
        public void WriteMOVE()
        {
            Console.WriteLine($"{this}  -  переместился ");
        }
        public void WriteAPPLY()
        {
            Console.WriteLine($"{this}  -  применил аптечку");
        }
        /// <summary>
        /// Конструктор создающщий объект в случайном месте
        /// </summary>
        public BaseObject()
        {
            Pos = new Point(Rnd.Next(0, Game.Width),
                            (Convert.ToInt32(Rnd.NextDouble() * Game.Height)));
            Dir = new Point(Convert.ToInt32(Rnd.NextDouble() * 10) - 11,
                            Convert.ToInt32(Rnd.NextDouble() * 10) - 11);
            Size = new Size(10, 10);

        }
        /// <summary>
        /// класс для создания объектов в другой форме
        /// </summary>
        /// <param name="a"></param>
        public BaseObject(int a)
        {
            Pos = new Point(Rnd.Next(0, Greetings.Width),
                            (Convert.ToInt32(Rnd.NextDouble() * Greetings.Height)));
            Dir = new Point(Convert.ToInt32(Rnd.NextDouble() * 10) - 11,
                            Convert.ToInt32(Rnd.NextDouble() * 10) - 11);
            Size = new Size(10, 10);

        }
        /// <summary>
        /// Метод загрузки изображения по имени файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        protected void LoadImage(string fileName)
        {
            Img = Image.FromFile(fileName);
        }
        /// <summary>
        /// описатель отрисовки
        /// </summary>
        public virtual void Draw()
        {
            if (Img != null)
                Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y, Size.Width, Size.Height);
            else
                Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// описатель отрисовки для приветственного окна
        /// </summary>
        public virtual void Draw1()
        {
            if (Img != null)
                Greetings.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y, Size.Width, Size.Height);
            else
                Greetings.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// описатель обновления объекта
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// сообзение
        /// </summary>
        public delegate void Message();
        /// <summary>
        /// Интерфейс определяющий пересечение объектов
        /// </summary>
        /// <param name="o">объект с которым пересекся текущий</param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}