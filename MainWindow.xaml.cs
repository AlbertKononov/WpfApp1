using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Departament> data;
        Departament dep;
        
        public MainWindow()
        {
            InitializeComponent();
            dep = new Departament(0);
            data = dep.dps;
            data = new ObservableCollection<Departament>();
            TrView.ItemsSource = data;
            
        }


        /// <summary>
        /// Создание департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRe(object sender, RoutedEventArgs e)
        {
            TrView.ItemsSource = data;
            data=new ObservableCollection<Departament>()
            {new Departament(10)
            {
                Name = "Главный отдел"
            }
            };
        }

        /// <summary>
        /// Добавление отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDep(object sender, RoutedEventArgs e)
        {
            data.Add(new Departament(10) { Name = "Отдел1" });
        }

        /// <summary>
        /// Добавление поддепартамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubDep(object sender, RoutedEventArgs e)
        {
            TrView.ItemsSource = data;
            if (TrView.SelectedItem==null)
            {            

            }
            if(TrView.SelectedItem!=null)
            {
                (TrView.SelectedItem as Departament).dps.Add(new Departament(10)
                {                   
                    
                });

                for (int i = 0; i < data.Count; i++)
                {
                    Namer("Департамент", data[i].dps);                
                }
            }
        }

        /// <summary>
        /// Отображение сотрудников выбраного департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Director.ItemsSource = (TrView.SelectedItem as Departament).director;
            lvWorkers.ItemsSource = (TrView.SelectedItem as Departament).workers;
        }


        /// <summary>
        /// Удаление работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteWorker(object sender, RoutedEventArgs e)
        {
            if (TrView.SelectedItem == null || lvWorkers.SelectedItem == null)
            {

            }

            if (TrView.SelectedItem != null || lvWorkers.SelectedItem != null)
            {
                (TrView.SelectedItem as Departament).workers.Remove((Worker)lvWorkers.SelectedItem);
            }
            lvWorkers.Items.Refresh();
        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnDeleteDep(object sender, RoutedEventArgs e)
        {
            if (TrView.SelectedItem == null)
            {

            }

            if (TrView.SelectedItem != null)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    DpDeleter((Departament)TrView.SelectedItem, data[i].dps);

                }            
            }


        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddWorker(object sender, RoutedEventArgs e)
        {
            if (TrView.SelectedItem == null)
            {
            }

            if (TrView.SelectedItem != null)
            {
                (TrView.SelectedItem as Departament).workers.Add(new Worker("Имя","Фамилия",20));
            }
            lvWorkers.Items.Refresh();
        }

        /// <summary>
        /// Добавление интерна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddIntern(object sender, RoutedEventArgs e)
        {
            if (TrView.SelectedItem == null)
            {
            }

            if (TrView.SelectedItem != null)
            {
                (TrView.SelectedItem as Departament).workers.Add(new Intern("Имя", "Фамилия", 20));
            }
            lvWorkers.Items.Refresh();
        }

        /// <summary>
        /// Добавление вспомогательного сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddWorker_2(object sender, RoutedEventArgs e)
        {
            if (TrView.SelectedItem == null)
            {
            }

            if (TrView.SelectedItem != null)
            {
                (TrView.SelectedItem as Departament).workers.Add(new Worker_2("Имя", "Фамилия", 20));
            }
            lvWorkers.Items.Refresh();
        }


        /// <summary>
        /// Метод австосоздания имен
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="dp"></param>
        void Namer(string prefix, ObservableCollection<Departament> dp)
        {            
            for (int i = 0; i < dp.Count; i++)
            { 
                dp[i].Name = String.Format("{0}_{1}", prefix, i + 1);               
                if (dp[i].dps != null)
                    Namer(dp[i].Name, dp[i].dps);
            }
        }


        /// <summary>
        /// Метод удаления департамента
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="dps"></param>
        void DpDeleter(Departament dp, ObservableCollection<Departament> dps)
        {
            for(int i = 0; i < dps.Count; i++)
            {

                int count = 0;
                if (dp.Name == dps[i].Name && dp.workers.Count==dps[i].workers.Count)
                {
                    
                    for (int j = 0; j < dps[i].workers.Count; j++)
                    {
                        
                        if (dp.workers[j].Name != dps[i].workers[j].Name ||
                              dp.workers[j].Surname != dps[i].workers[j].Surname)
                        { 
                            count++;                            
                        }                            
                    }
                    if (count == 0)
                    {
                        dps.RemoveAt(i);
                        break;
                    }
                }

                if (dp.Name != dps[i].Name)
                {
                    DpDeleter(dp, dps[i].dps);
                }
            }
        }

       
    }
}

