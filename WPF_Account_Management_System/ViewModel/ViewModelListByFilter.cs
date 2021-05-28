using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Account_Management_System.Models;

namespace WPF_Account_Management_System.ViewModel
{
    class ViewModelListByFilter : BindableBase
    {
        /// <summary>
        /// Контекст БД.
        /// </summary>
        private OfficeEntities Context { get; set; }

        public DelegateCommand OnShow { get; set; }

        /// <summary>
        /// Вильтры поиска.
        /// </summary>
        public List<string> Filters { get; set; }

        public ViewModelListByFilter()
        {
            Context = new OfficeEntities();

            Filters = new List<string>()
            {
                "По фамилии", "По отделу"
            };

            OnShow = new DelegateCommand(() => this.SearchInBD());
        }

        /// <summary>
        /// Выбраный фильтр.
        /// </summary>
        private string selectedFilter;
        public string SelectedFilter
        {
            get => selectedFilter;
            set => SetProperty(ref selectedFilter, value);
        }

        /// <summary>
        /// Строка запроса.
        /// </summary>
        private string fieldQuery;
        public string FieldQuery
        {
            get => fieldQuery;
            set => SetProperty(ref fieldQuery, value);
        }

        /// <summary>
        /// Найденые совпадения для работников.
        /// </summary>
        private List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }

        /// <summary>
        /// Найденые совпадения для отделов.
        /// </summary>
        private Department department;
        public Department Department
        {
            get => department;
            set => SetProperty(ref department, value);
        }

        /// <summary>
        /// Поиск работников по фильтру.
        /// </summary>
        private void SearchInBD()
        {
            if(string.IsNullOrEmpty(FieldQuery) || string.IsNullOrEmpty(SelectedFilter))
            {
                MessageBox.Show("Фильтр или запрос не задан!", "Ошибка");
                return;
            }

            if (SelectedFilter == "По фамилии")
            {
                Employees = Context.Employees.Where(i => i.LastName == FieldQuery).ToList();
                IsHas(Employees);
                return;
            }

            Department = Context.Departments
                .Where(i => i.Title == FieldQuery)
                .FirstOrDefault();

            Employees = Department.Employees
                .ToList();

            IsHas(Employees);
        }

        private void IsHas(List<Employee> employees)
        {
            if(employees.Count == 0 || employees is null)
                MessageBox.Show("Совпадений не найдено.", "Инфорамция");
        }
    }
}
