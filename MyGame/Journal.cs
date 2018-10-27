using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    /// <summary>
    /// описатель методов которые выводят сообзения в консоль
    /// </summary>
    public delegate void MyDelegate();
    /// <summary>
    /// класс для записи журнала
    /// </summary>
    class Journal
    {
        /// <summary>
        /// вывод всех событий
        /// </summary>
        public void Start() { if (Write != null) Write(); }
        /// <summary>
        /// событие произошедшее с объектом
        /// </summary>
        public event MyDelegate Write;
    }
}
