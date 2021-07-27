using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1
{
    class Departament
    {
        /// <summary>
        /// Коллекция департаментов
        /// </summary>
        public ObservableCollection<Departament> dps
        {
            get;
            set;
        }
 
        /// <summary>
        /// Сумма зарплат работников
        /// </summary>
        public double SalaryOfWorkers
        {
            get;
            set;
        }

        /// <summary>
        /// Зарплаты с поддепартаментов с поддепартаментов
        /// </summary>
        public double SalaryOfSubDep
        {
            get;
            set;
        }

        /// <summary>
        /// Директор
        /// </summary>
        public List<Manager> director
        {
            get;
            set;
        }

        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public List<Employee> workers
        {
            get;
            set;
        }

        /// <summary>
        /// Сумма зарплат департамента
        /// </summary>
        public double SalaryOfEmploies
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование департамента
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        

        /// <summary>
        /// Количество Работников
        /// </summary>
        public int NumberOfWorkers
        {
            get;
            set;
        }    
               
        /// <summary>
        /// Конструктор департемента
        /// </summary>
        /// <param name="NumberOfWorkers">
        /// Количество работников на один департамент</param>
        public Departament(int NumberOfWorkers)
        {
            
            this.NumberOfWorkers = NumberOfWorkers;
            dps = new ObservableCollection<Departament>();
            workers = new List<Employee>();
            director = new List<Manager>();
            SalaryOfWorkers = new double();
            SalaryOfSubDep = new double();
            SalaryOfEmploies = new double();

            for (int i = 0; i < NumberOfWorkers; i++)
            {
                workers.Add(new Worker("Имя", "Фамилия", 20));
            }

                director.Add(new Manager("Имя", "Фамилия", 20));
            

            for (int i = 0; i < this.workers.Count; i++)
            {
                this.SalaryOfWorkers =
                 this.SalaryOfWorkers +
                 workers[i].Salary;
            }

            for (int i = 0; i < this.dps.Count; i++)
            {
                this.SalaryOfSubDep =
                    this.dps[i].SalaryOfEmploies +
                    this.SalaryOfSubDep;
            }

            this.SalaryOfEmploies = (this.SalaryOfWorkers
                + this.SalaryOfSubDep) * 1.15;
            director[0].Salary = SalaryOfEmploies;
        }

        public double SubSalary(Departament dp)
        {
            dp.SalaryOfSubDep = 0;
            for (int i = 0; i < dp.dps.Count; i++)
            {
                dp.SalaryOfSubDep +=
                    dp.dps[i].SalaryOfWorkers * 1.15 +
                    SubSalary(dp.dps[i]);
            }
            return dp.SalaryOfSubDep;
        }       

    }

}

