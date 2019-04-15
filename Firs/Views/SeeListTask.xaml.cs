﻿using First.Interface;
using First.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using First;
using First.ViewModel;

namespace First
{
    /// <summary>
    /// Логика взаимодействия для SeeOneTask.xaml
    /// </summary>
    public partial class SeeListTask : Page
    {
        public SeeListTask(ViewModelBase vm)
        {
            InitializeComponent();
           DataContext= new SeeListViewModel((MainWindowViewModel)vm);
            radioButton1.IsChecked = true;
        }

       
    } }


