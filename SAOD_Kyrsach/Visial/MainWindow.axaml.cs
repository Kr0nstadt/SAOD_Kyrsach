using Avalonia.Controls;
using Avalonia.Interactivity;
using SAOD_Kyrsach;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using SAOD_Kyrsach.Tree;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SAOD_Kyrsach.BookRecord;
using SAOD_Kyrsach.DigitalSort;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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
                SearchRes.Text = "Вы не ввели фамилию не замечательного человека";
            }

            else 
            {
                Info info = new Info();
                SearchRes.Text =  new Search(info.ListBef,SearchBox.Text).ToString();
            }
        }
        public void ButtonSearch2(object source, RoutedEventArgs args)
        {
            string pattern = @"^\d+$";

            if (SearchBox2.Text == null)
            {
                SearchRes2.Text = "Вы не ввели фамилию не замечательного человека";
            }
            else
            {
                Info info = new Info();
                var search = new Search(info.ListAft, SearchBox2.Text);
                SearchRes2.Text = search.ToString();
                SearchSortList = search.SearchList;
            }
        }
        private IList<BookRecordAdapterGetLastNameByte> SearchSortList = new List<BookRecordAdapterGetLastNameByte>();
        public void ButtonTree(object source, RoutedEventArgs args)
        {
                var treelist = new TreeStr();
                treelist.Add(SearchSortList);
                treelist.InOrderTraversalLeftString();
                TextBlockTree.Text = treelist.InOrderTraversal + "____________________________________________________________________________________________________________";
        }

        public void ButtonTree2(object source, RoutedEventArgs args)
        {
            string pattern = @"^\d+$";

            if (SearchBox2.Text == null)
            {
                TreeSearchRes.Text = "Вы не ввели фамилию замечательного человека";
            }
            if (!Regex.IsMatch(TreeTextBox2.Text, pattern))
            {
                TreeSearchRes.Text = "Можно вводить только цифорки";
            }
            else
            {
                TreeStr tree = new TreeStr();
                tree.Add(SearchSortList);
                var res = tree.Search(TreeTextBox2.Text.ToString());
                TreeSearchRes.Text = tree.ToString() + "\n____________________________________________________________________________________________________________";


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