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
        private int CountLineBef = 20;
        private int CountLineAft = 20;
        public void ButtonClickedBef(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            CountLineBef += 20;
            TextBlockBefSort.Text = new TextInfo(info.ListBef,CountLineBef).ToString();
        }
        public void ButtonClickedAft(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            CountLineAft += 20;
            TextBlockAftSort.Text = new TextInfo(info.ListAft, CountLineAft).ToString();
        }
    }
}