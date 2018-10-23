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
        protected Random rnd = new Random();
        /// <summary>
        /// Случайнок направление
        /// </summary>
        private int rndDir;
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
            Dir = new Point(rnd.Next(-10, 10), rnd.Next(-10, 10));
            Size = size;

        }
        /// <summary>
        /// получение случаного значения направвления
        /// </summary>
        public int RndDir { get => rnd.Next(-10, 10); set => rndDir = value; }
        /// <summary>
        /// опичатель отрисовки
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// описатель обновления объекта
        /// </summary>
        public abstract void Update();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}