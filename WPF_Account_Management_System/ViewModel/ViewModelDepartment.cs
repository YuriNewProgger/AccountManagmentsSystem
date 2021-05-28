using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Account_Management_System.Helpers;
using WPF_Account_Management_System.Models;
using WPF_Account_Management_System.View;

namespace WPF_Account_Management_System.ViewModel
{
    public class ViewModelDepartment : BindableBase
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private OfficeEntities Context { get; set; }

        /// <summary>
        /// Делегаты управления созданием нового отдела и редактированием.
        /// </summary>
        public DelegateCommand WinCreateNewDepartment { get; set; }
        public DelegateCommand WinEditSelectedDepartment { get; set; }
        public DelegateCommand DelSelectedDepartment { get; set; }
        public DelegateCommand OKWinDepartment { get; set; }
        public DelegateCommand CancelWinDepartment { get; set; }

        /// <summary>
        /// Окно создания или редактирования отдела.
        /// </summary>
        private WindowDepartment WinDepartment { get; set; }

        public ViewModelDepartment()
        {
            Context = new OfficeEntities();

            LoadInformationAsync();

            WinCreateNewDepartment = new DelegateCommand(() => this.WinCreateDepartment());
            WinEditSelectedDepartment = new DelegateCommand(() => this.WinEditSelectedDepartmen());
            DelSelectedDepartment = new DelegateCommand(() => this.DeleteSelectedDepartment());
            OKWinDepartment = new DelegateCommand(() => this.BtnOkWinDepartment());
            CancelWinDepartment = new DelegateCommand(() => this.BtnCancelWinDepartment());
        }

        #region Св-ва зависимостей
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private List<Department> departments;
        public List<Department> Departments
        {
            get => departments;
            set => SetProperty(ref departments, value);
        }

        private Department selectedDepartment;
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set => SetProperty(ref selectedDepartment, value);
        }
        #endregion

        /// <summary>
        /// Асинхроный метод загрузки сотрудников и отделов.
        /// </summary>
        private async void LoadInformationAsync()
        {
            //await Task.Run(() => LoadEmloyee());
            await Task.Run(() => LoadDepartents());
        }
        //private void LoadEmloyee() => Employees = Context.Employees.ToList();
        private void LoadDepartents() => Departments = Context.Departments.ToList();

        /// <summary>
        /// Создаёт окно создания нового отдела.
        /// </summary>
        private void WinCreateDepartment()
        {
            Title = null;
            SelectedDepartment = null;
            WinDepartment = new WindowDepartment(this);
            WinDepartment.Show();
        }

        /// <summary>
        /// Создаёт окно редактирования выбраного отдела.
        /// </summary>
        private void WinEditSelectedDepartmen()
        {
            if (SelectedDepartment is null)
            {
                MessageBox.Show("Отдел не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Title = SelectedDepartment.Title;

            WinDepartment = new WindowDepartment(this);
            WinDepartment.Show();
        }

        /// <summary>
        /// Удаляет выбраный отдел.
        /// </summary>
        private void DeleteSelectedDepartment()
        {
            if (SelectedDepartment is null)
            {
                MessageBox.Show("Отдел не выбран не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (SelectedDepartment.Employees.Count > 0)
            {
                MessageBox.Show("Нельзя удалить отдел пока в нём числятся сотрудники. Переведите сотрудников в другой отдел.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show("Потвердите удаление отдела.", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.No)
                return;

            Context.Departments.Remove(SelectedDepartment);
            Context.SaveChanges();

            LoadDepartents();
        }

        /// <summary>
        /// Создаёт новый отдел или редактирует и сохраняет его в БД.
        /// </summary>
        private void BtnOkWinDepartment()
        {
            //Проверяет во всех полях есть ли значение.
            if (!Checker.IsCorrectField(Title))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Если отдел не выбран, то создаётся, иначе редактируется.
            if (SelectedDepartment is null)
            {
                Department department = new Department();
                department.Title = Title;

                Context.Departments.Add(department);

                Context.SaveChanges();

                WinDepartment.Close();
            }
            else
            {
                SelectedDepartment.Title = Title;

                Context.SaveChanges();

                WinDepartment.Close();

                SelectedDepartment = null;
                Title = null;
            }

            LoadDepartents();
        }

        /// <summary>
        /// Закрывает окно создания или редактирования отделов.
        /// </summary>
        private void BtnCancelWinDepartment() => WinDepartment.Close();
    }
}
