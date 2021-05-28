using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Account_Management_System.Models;
using Prism.Mvvm;
using WPF_Account_Management_System.View;
using Prism.Commands;
using System.Windows;
using WPF_Account_Management_System.Helpers;

namespace WPF_Account_Management_System.ViewModel
{
    public class ViewModelEmployee : BindableBase
    {
        /// <summary>
        /// Делегаты управления созданием нового сотрудника и редактированием.
        /// </summary>
        public DelegateCommand WinCreateNewEmployee { get; set; }
        public DelegateCommand WinEditSelectedEmployee { get; set; }
        public DelegateCommand WinDeleteSelectedEmployee { get; set; }
        public DelegateCommand OKWinCreateNewEmployee { get; set; }
        public DelegateCommand CloseWinCreateNewEmployee { get; set; }

        /// <summary>
        /// Контекст БД
        /// </summary>
        private OfficeEntities Context { get; set; }

        /// <summary>
        /// Окно создания нового сотрудника.
        /// </summary>
        private WindowEmployee WinEmployee { get; set; }

        public ViewModelEmployee()
        {
            Context = new OfficeEntities();

            LoadInformationAsync();
            DateBirthday = DateTime.Now;

            WinCreateNewEmployee = new DelegateCommand(() => this.WinCreateEmployee());
            WinEditSelectedEmployee = new DelegateCommand(() => this.WinEditEmployee());
            WinDeleteSelectedEmployee = new DelegateCommand(() => this.DeleteSelectedEmployee());
            OKWinCreateNewEmployee = new DelegateCommand(() => this.BtnOkWinEmployee());
            CloseWinCreateNewEmployee = new DelegateCommand(() => this.BtnCancelWinEmployee());
        }

        #region Св-ва зависимостей
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        private string patronymic;
        public string Patronymic
        {
            get => patronymic;
            set => SetProperty(ref patronymic, value);
        }

        private DateTime dateBirthday;
        public DateTime DateBirthday
        {
            get => dateBirthday;
            set => SetProperty(ref dateBirthday, value);
        }

        private string about;
        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        private Department department;
        public Department Department
        {
            get => department;
            set => SetProperty(ref department, value);
        }

        private List<Department> departments;
        public List<Department> Departments
        {
            get => departments;
            set => SetProperty(ref departments, value);
        }

        private List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set => SetProperty(ref selectedEmployee, value);
        }
        #endregion

        /// <summary>
        /// Асинхроный метод загрузки сотрудников и отделов.
        /// </summary>
        private async void LoadInformationAsync()
        {
            await Task.Run(() => LoadEmloyee());
            await Task.Run(() => LoadDepartents());
        }
        private void LoadEmloyee() => Employees = Context.Employees.ToList();
        private void LoadDepartents() => Departments = Context.Departments.ToList();


        /// <summary>
        /// Создаёт экземпляр окна для создания сотрудника и показывает его.
        /// </summary>
        private void WinCreateEmployee()
        {
            ClearAllFields();
            WinEmployee = new WindowEmployee(this);
            WinEmployee.Show();
        }

        /// <summary>
        /// Создаёт окно для редактирования выбраного сотрудника.
        /// </summary>
        private void WinEditEmployee()
        {
            if(SelectedEmployee is null)
            {
                MessageBox.Show("Сотрудник не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            FirstName = SelectedEmployee.FirstName;
            LastName = SelectedEmployee.LastName;
            Patronymic = SelectedEmployee.Patronymic;
            DateBirthday = SelectedEmployee.DateBirthday;
            About = SelectedEmployee.About;
            Department = SelectedEmployee.Department;

            WinEmployee = new WindowEmployee(this);
            WinEmployee.Show();
        }

        /// <summary>
        /// Удаляет выбраного сотрудника.
        /// </summary>
        private void DeleteSelectedEmployee()
        {
            if (SelectedEmployee is null)
            {
                MessageBox.Show("Сотрудник не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show("Потвердите удаление сотрудника.", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.No)
                return;

            Context.Employees.Remove(SelectedEmployee);
            Context.SaveChanges();

            LoadEmloyee();

            ClearAllFields();
        }

        /// <summary>
        /// Создаёт нового сотрудника или редактирует сохраняет его в БД.
        /// </summary>
        private void BtnOkWinEmployee()
        {
            //Проверяет во всех полях есть ли значение.
            if (!Checker.IsCorrectField(FirstName, LastName, Patronymic, About))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Department == null)
            {
                MessageBox.Show("Отдел не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Если сотрудник не выбран, то создаётся, иначе редактируется.
            if(SelectedEmployee is null)
            {
                Employee employee = new Employee();
                employee.FirstName = FirstName;
                employee.LastName = LastName;
                employee.Patronymic = Patronymic;
                employee.DateBirthday = DateBirthday;
                employee.About = About;
                employee.Department = Department;
                employee.IdDepartment = Department.Id;

                Context.Employees.Add(employee);
                Context.SaveChanges();

                WinEmployee.Close();
            }
            else
            {
                SelectedEmployee.FirstName = FirstName;
                SelectedEmployee.LastName = LastName;
                SelectedEmployee.Patronymic = Patronymic;
                SelectedEmployee.DateBirthday = DateBirthday;
                SelectedEmployee.About = About;
                SelectedEmployee.Department = Department;
                SelectedEmployee.IdDepartment = Department.Id;

                Context.SaveChanges();

                WinEmployee.Close();

                ClearAllFields();
            }

            LoadEmloyee();
        }

        /// <summary>
        /// Закрытие окна создания нового сотрудника.
        /// </summary>
        private void BtnCancelWinEmployee() => WinEmployee.Close();

        /// <summary>
        /// Отчищает все поля.
        /// </summary>
        private void ClearAllFields()
        {
            FirstName = null;
            LastName = null;
            Patronymic = null;
            DateBirthday = DateTime.Now;
            About = null;
            Department = null;
            SelectedEmployee = null;
        }
    }
}
