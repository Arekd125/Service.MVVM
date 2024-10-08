﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Service.View.Views
{
    /// <summary>
    /// Interaction logic for ToDoListView.xaml
    /// </summary>
    public partial class ToDoListView : UserControl
    {
        public ICommand AddNewToDo
        {
            get { return (ICommand)GetValue(AddNewToDoProperty); }
            set { SetValue(AddNewToDoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddNewToDoProperty =
            DependencyProperty.Register("AddNewToDo", typeof(ICommand), typeof(ToDoListView), new PropertyMetadata(null));

        public ICommand DeleteToDo
        {
            get { return (ICommand)GetValue(DeleteToDoProperty); }
            set { SetValue(DeleteToDoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteToDoCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteToDoProperty =
            DependencyProperty.Register("DeleteToDo", typeof(ICommand), typeof(ToDoListView), new PropertyMetadata(null));

        public ToDoListView()
        {
            InitializeComponent();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (AddNewToDo != null)
            {
                AddNewToDo.Execute(e.Row.DataContext);
            }
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && DeleteToDo != null)
            {
                DeleteToDo.Execute(ToDoDataGrid.SelectedItem);
            }
        }
    }
}