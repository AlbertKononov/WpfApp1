using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Worker : Employee
    {
        /// <summary>
        /// Работник
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="Age">Возраст</param>
        public Worker(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Salary = 1000;
            this.Age = Age;
            Post = "Рабочий";
        }

    }
}
