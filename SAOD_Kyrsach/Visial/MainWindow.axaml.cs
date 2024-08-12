using Avalonia.Controls;
using Avalonia.Interactivity;
using SAOD_Kyrsach;
using System;
using System.Linq;

namespace Visual
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonClicked(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            TextBlockBefSort.Text = new TextInfo(info.ListBef,info.CountLine = 20).ToString();
        }
    }
}