using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    /// <summary>
    /// класс рабочего с помесячной оплатой
    /// </summary>
    class FixedSalaryWorker : Worker
    {
        public FixedSalaryWorker(string firstname, string lastname, int age, float salary, float fee) : 
            base(firstname, lastname, age, salary, fee) { }

        public FixedSalaryWorker() : base() { }

        /// <summary>
        /// возврат значения зарплаты
        /// </summary>
        /// <returns></returns>
        public override float MounthSalary()
        {
            return Salary;
        }
    }
}
