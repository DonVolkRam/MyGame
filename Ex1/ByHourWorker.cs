using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    /// <summary>
    /// класс сотрудника с почасовой оплатой
    /// </summary>
    class ByHourWorker: Worker
    {
        public ByHourWorker(string firstname, string lastname, int age, float salary, float fee) : 
            base(firstname, lastname, age, salary, fee) { }
        public ByHourWorker() : base() { Salary = rnd.Next(20, 100); }

        /// <summary>
        /// возврат зарплаты
        /// </summary>
        /// <returns></returns>
        public override float MounthSalary()
        {
            return Salary * 20.8f * 8;            
        }
    }
}
