using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Manager : Employee
    {
        /// <summary>
        /// Менеджер
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="Age">Возраст</param>
        public Manager(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;            
            this.Age = Age;
            Post = "Управляющий";
        }

    }
}
