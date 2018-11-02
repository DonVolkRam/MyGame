using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static void Main()
        {
            List<Worker> Workers = new List<Worker>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                if (rnd.Next(0, 2) == 0)
                    Workers.Add(new ByHourWorker());
                else
                    Workers.Add(new FixedSalaryWorker());                
            }

            foreach (var Wrk in Workers)
            {
                Console.WriteLine(Wrk.ToString());
            }

            Workers.Sort();
            foreach (var Wrk in Workers)
            {
                Console.WriteLine(Wrk.ToString());
            }
            //for (int i = 0; i < Workers.Count; i++)
            //{
            //    Console.WriteLine(Workers[i].ToString());
            //}
            Console.ReadKey();
        }
    }
}
