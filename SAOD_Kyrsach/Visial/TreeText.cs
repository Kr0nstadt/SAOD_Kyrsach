using SAOD_Kyrsach.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual
{
    internal class TreeText
    {
        public TreeText(TreeStr tree)
        {
            _tree = tree;
            _key = "-1";
        }
        public TreeText(TreeStr tree, string key)
        {
            _tree = (TreeStr)tree;
            _key = key;
        }
        public override string ToString()
        {
            string txt = $"{"Автор",-12} | {"Название",-32} | {"Издательство",-16} | {"Год",-5} | {"Количество страниц",-5}\n" +
                        $"-----------------------------------------------------------------------------------------------\n";
            if(_key == "-1"){ txt += _tree.InOrderTraversal; return txt; }
            else
            {
                string res = "";
                return txt;
            }
        }
        private TreeStr _tree;
        private string _key;
    }
}
