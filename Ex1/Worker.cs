using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    //Класс обычного рабочего
    abstract class Worker: IComparable
    {
        protected string FirstName { get; }
        protected string LastName { get; }
        protected int Age { get; }
        protected float Salary { get; set; }
        protected float Fee { get; }
        public Random rnd = new Random();

        /// <summary>
        /// Конструктор для задания параметров
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="lastname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="fee">Налог</param>
        public Worker(string firstname, string lastname, int age, float salary, float fee)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Salary = salary;
            Fee = fee;
        }
        /// <summary>
        /// Конструктор для создания случайного рабочего
        /// </summary>
        public Worker()
        {
            FirstName = "Имя" + rnd.Next(0, 100);
            LastName = "Фамилия" + rnd.Next(0, 100);
            Age = rnd.Next(18, 45);
            Salary = rnd.Next(15, 100) * 1000;
            Fee = Salary * 0.13f;
        }

        /// <summary>
        /// переопределение вывода сотрудника
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age} {Salary}";
        }

        abstract public float MounthSalary();

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
