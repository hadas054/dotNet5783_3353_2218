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
using System.Windows;

namespace PL.manager
{
    /// <summary>
    /// Interaction logic for MainManager.xaml
    /// </summary>
    public partial class MainManager : Window
    {
        public MainManager()
        {
            InitializeComponent();
        }

        private void OrderWindow(object sender, MouseButtonEventArgs e)
        {
            new OrderMain().Show();
        }

        private void ProductWindow(object sender, MouseButtonEventArgs e)
        {
            new ProductMain().Show();
        }
    }
}