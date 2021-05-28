﻿using System;
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
using System.Windows.Shapes;
using WPF_Account_Management_System.ViewModel;

namespace WPF_Account_Management_System.View
{
    /// <summary>
    /// Логика взаимодействия для WindowDepartment.xaml
    /// </summary>
    public partial class WindowDepartment : Window
    {
        public WindowDepartment(ViewModelDepartment viewModelDepartment)
        {
            this.DataContext = viewModelDepartment;
            InitializeComponent();
        }
    }
}
