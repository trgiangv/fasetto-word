﻿using System;
using System.Windows;

namespace _3_TreeViewsSimpleViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new DirectoryStructureViewModel();
            
        }

        #endregion
    }
}