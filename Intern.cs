using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Intern : Employee
    {
        /// <summary>
        /// Интерн
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Age">Возраст</param>
        public Intern(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Salary = 100;
            this.Age = Age;
            Post = "Интерн";
        }
    }
}
