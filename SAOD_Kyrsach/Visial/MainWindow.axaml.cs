using Avalonia.Controls;
using Avalonia.Interactivity;
using SAOD_Kyrsach;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using SAOD_Kyrsach.Tree;

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
            string pattern = @"^\d+$";
            
            if(SearchBox.Text == null)
            {
                SearchRes.Text = "Вы не ввели номер записи";
            }
            if (Regex.IsMatch(SearchBox.Text, pattern) == false)
            {
                SearchRes.Text = "Не корректные входные значения";
                
            }
            else 
            {
                Info info = new Info();
                SearchRes.Text = new TextInfo(info.ListBef, ((Int32.Parse(SearchBox.Text) / 20) + 1) * 20, Int32.Parse(SearchBox.Text)-1).ToString();//будет пятая снизу запись
                //SearchRes.Text =  info.ListBef[Int32.Parse(SearchBox.Text) + 1].ToString();
            }
        }
        public void ButtonSearch2(object source, RoutedEventArgs args)
        {
            string pattern = @"^\d+$";

            if (SearchBox.Text == null)
            {
                SearchRes2.Text = "Вы не ввели номер записи";
            }
            if (Regex.IsMatch(SearchBox2.Text, pattern) == false)
            {
                SearchRes2.Text = "Не корректные входные значения";

            }
            else
            {
                Info info = new Info();
                SearchRes2.Text = new TextInfo(info.ListAft, ((Int32.Parse(SearchBox2.Text) / 20 ) + 1)*20 , Int32.Parse(SearchBox2.Text) - 1).ToString();//будет пятая снизу запись
                //SearchRes.Text =  info.ListBef[Int32.Parse(SearchBox.Text) + 1].ToString();
            }
        }

        public void ButtonTree(object source, RoutedEventArgs args)
        {
            string pattern = @"^\d+$";

            if (SearchBox.Text == null)
            {
                TreeSearchRes.Text = "Вы не фамилию не замечательного человека";
            }
            if (Regex.IsMatch(TreeTextBox.Text, pattern) == true)
            {
                TreeSearchRes.Text = "Не корректные входные значения";

            }
            else
            {
                Info info = new Info();
                TreeStr tree = info.TreeStr;
                var res = tree.Search(TreeTextBox.Text.ToString());
                TreeSearchRes.Text = tree.ToString() + "____________________________________________________________________________________________________________";


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