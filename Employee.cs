using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{   
        /// <summary>
        /// Сотрудник
        /// </summary>
        abstract class Employee
        {

            /// <summary>
            /// Имя
            /// </summary>
            public string Name
            {
                get;
                set;
            }
            /// <summary>
            /// Фамилия
            /// </summary>
            public string Surname
            {
                get;
                set;
            }
            /// <summary>
            /// Зарплата
            /// </summary>
            public double Salary
            {
                get;
                set;
            }

            /// <summary>
            /// Возраст
            /// </summary>
            public int Age
            {
                get;
                set;
            }
                    
        /// <summary>
        /// Должность
        /// </summary>
            public string Post
            {
            get;
            set;
            }


    } 

    
}

