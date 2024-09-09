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
        private static int CountLineBef = 20;
        private static int CountLineAft = 20;
        public void ButtonClickedBef(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            CountLineBef += 20;
            TextBlockBefSort.Text = new TextInfo(info.ListBef,CountLineBef).ToString();
            if (CountLineBef > info.ListBef.Count)
            {
                CountLineBef = 20;
            }
        }
        public void ButtonClickedAft(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            CountLineAft += 20;
            TextBlockAftSort.Text = new TextInfo(info.ListAft, CountLineAft).ToString();
            if (CountLineAft > info.ListAft.Count)
            {
                CountLineAft = 20;
            }
        }
        public void ButtonSearch(object source, RoutedEventArgs args)
        {
            if(SearchBox == null)
            {
                SearchRes.Text = "Вы не ввели номер записи";
            }
            else
            {
                Info info = new Info();
                SearchRes.Text = new TextInfo(info.ListAft, Int32.Parse(SearchBox.Text) + 1, Int32.Parse(SearchBox.Text) + 1).ToString();
                //SearchRes.Text =  info.ListBef[Int32.Parse(SearchBox.Text) + 1].ToString();
            }
        }



        public void ButtonClickedAllBef(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            TextBlockBefSort.Text = new TextInfo(info.ListBef, info.ListBef.Count).ToString();
            CountLineBef = 20;
        }
        public void ButtonClickedAllAft(object source, RoutedEventArgs args)
        {
            Info info = new Info();
            TextBlockAftSort.Text = new TextInfo(info.ListAft, info.ListAft.Count).ToString();
            CountLineAft = 20;
        }
    }
}