using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Worker_2 : Employee
    {

        /// <summary>
        /// Дополнительный персонал
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Age"></param>
        public Worker_2(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Salary = 1000;
            this.Age = Age;
            Post = "Дополнительный персонал";
        }
    }
}
