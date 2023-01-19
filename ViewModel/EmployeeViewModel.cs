using Mvvm_WPF_13.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Controls;

namespace Mvvm_WPF_13.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public EmployeeViewModel()
        {

        }

        public int Id { get; set; } = 1;
        //for serial id
        public int GenerateSerial()
        {
            //serial = id;
            if (Employee_list != null)
            {
                for (int a = 0; a < Employee_list.Count; a++)
                    if (Id == Employee_list[a].Id)
                    {
                        Id++;
                        a = -1;
                    }

            }
            return Id;
        }

        public string Name { get; set; }

        public DateTime DOB { get; set; }
        public int MyselectedIndex { get; set; } = -1;

        private string filtername;
        public string FilterName
        {
            get { return filtername; }
            set { filtername = value; NotifyPropertyChanged(nameof(FilterName)); }
        }


        private int filterid;
        public int FilterID
        {
            get { return filterid; }
            set { filterid = value; NotifyPropertyChanged2(nameof(filterid)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Filter_ByName();
        }


        public void NotifyPropertyChanged2(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Filter_ByID();
        }


        private ObservableCollection<Employee> employee_list;

        public readonly ObservableCollection<Employee> temp23;

        // public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public ObservableCollection<Employee> Employee_list
        {
            get { return employee_list; }
            set { employee_list = value; OnPropertyChange("Employee_list"); }
        }

        private ObservableCollection<Employee> provider;
        public ObservableCollection<Employee> Provider
        {
            get { return provider; }
            set { provider = value; OnPropertyChange("Provider");}
        }
        public VMEvent ShowMessage
        {
            get { return new VMEvent(Showmsg); }

        }


        public VMEvent Deleted
        {
            get { return new VMEvent(Delete); }

        }

        public VMEvent Filter_Name
        {
            get { return new VMEvent(Filter_ByName); }

        }

        public void Showmsg()
        {
            GenerateSerial();

            if (Employee_list == null)
            {
                Employee_list = new ObservableCollection<Employee>();
                Provider = new ObservableCollection<Employee>();
            }

            Employee_list.Add(new Employee { Id = Id, Name = Name, DOB = DOB });
            Provider.Add(new Employee { Id = Id, Name = Name, DOB = DOB });



            //Filter_ByName();
            MessageBox.Show(Name + " successfully added");
        }

        public void Delete()
        {
            int x = MyselectedIndex;
            Employee_list.RemoveAt(x);
            Provider.RemoveAt(x);
        }


        public void Filter_ByName()
        {
            List<Employee> tempp;// = new List<Employee>();
            List<string> result_list=new List<string>();// = new List<Employee>();
            List<string> result2_list=new List<string>();// = new List<Employee>();

            //for comparing two lists
            var result = from se in Employee_list
                         where se.Name.Length < 54                         
                         select se;

            var result2 = from se in Provider
                          where se.Name.Length < 54
                         select se;

            foreach (var i in result)
            {
                result_list.Add(i.Name);
            }

            foreach (var i in result2)
            {
                result2_list.Add(i.Name);
            }

            for (int i = 0; i < Provider.Count; i++)
            {
                if (result_list.Contains(result2_list[i]))
                {
                    
                }
                else
                {
                    Employee_list.Add(Provider[i]);
                }
            }


           

            if (FilterName != null || FilterName != "")
            {
                // tempp = Employee_list.ToList();
                tempp = Employee_list.Where(e => e.Name.Contains(FilterName)).ToList();
                for (int i = Employee_list.Count - 1; i >= 0; i--)
                {

                    var item = Employee_list[i];
                    if (!tempp.Contains(item))
                    {
                        Employee_list.Remove(item);
                       }
                }
                //Employee_list.ToList() = tempp;
                foreach (var item in tempp)
                {
                    if (!Employee_list.Contains(item))
                    {
                        Employee_list.Add(item);
                    }
                }
            }
            Employee_list = new ObservableCollection<Employee>(Employee_list.OrderBy(e => e.Id));
            
        }

        public void Filter_ByID()
        {
            
            List<Employee> tempp;// = new List<Employee>();
            List<int> result_list = new List<int>();// = new List<Employee>();
            List<int> result2_list = new List<int>();// = new List<Employee>();

            //for comparing two lists
            var result = from se in Employee_list
                         where se.Id>0
                         select se;

            var result2 = from se in Provider
                          where se.Id>0
                          select se;

            foreach (var i in result)
            {
                result_list.Add(i.Id);
            }

            foreach (var i in result2)
            {
                result2_list.Add(i.Id);
            }

            for (int i = 0; i < Provider.Count; i++)
            {
                if (result_list.Contains(result2_list[i]))
                {

                }
                else
                {
                    Employee_list.Add(Provider[i]);
                }
            }

                      


            if (FilterID != 0)
            {
                // tempp = Employee_list.ToList();
                tempp = Employee_list.Where(e => e.Id==FilterID).ToList();
                for (int i = Employee_list.Count - 1; i >= 0; i--)
                {

                    var item = Employee_list[i];
                    if (!tempp.Contains(item))
                    {
                        Employee_list.Remove(item);
                    }
                }
                //Employee_list.ToList() = tempp;
                foreach (var item in tempp)
                {
                    if (!Employee_list.Contains(item))
                    {
                        Employee_list.Add(item);
                    }
                }
            }
            Employee_list = new ObservableCollection<Employee>(Employee_list.OrderBy(e => e.Id));

        }

    }

    public class VMEvent : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action CommonEvent;

        public VMEvent(Action action)
        {
            CommonEvent = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            CommonEvent();
        }
    }
}
