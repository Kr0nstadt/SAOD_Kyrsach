using SAOD_Kyrsach.BookRecord;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.Tree
{
    public class TreeStr
    {
        public NodeTree Root;

        private IList<NodeTree> PointCounter(IList<BookRecordAdapterGetLastNameByte> listBook)
        {
            IList<NodeTree> nodeTrees = new List<NodeTree>();
            IList<BookRecordAdapterGetLastNameByte> DistList = listBook;
            Random rnd = new Random();
            foreach(var list in DistList)
            {
                nodeTrees.Add(new NodeTree(list, rnd.Next(1, 99)));
            }
            return nodeTrees;
        }


        public void Add(IList<BookRecordAdapterGetLastNameByte> listBook)
        {
            IList<NodeTree> nodes = PointCounter(listBook);
            for (int i = 0; i < nodes.Count; i++)
            {
                Root = AddToTree(Root, nodes[i]);
            }
        }

        private NodeTree AddToTree(NodeTree node, NodeTree value)
        {
            if (node == null)
                return value;
            else
            {
                if (value.Compare(value,node) == 1 || value.Compare(node,value) == 0)
                    node.Right = AddToTree(node.Right, value);
                else
                    node.Left = AddToTree(node.Left, value);
            }

            return node;
        }

       public NodeTree Search( string key)
        {
            Search(Root,key);
            return Root;
        }
        private IList<NodeTree> searchRes = new List<NodeTree>();
        private void Search(NodeTree node, string key)
        {
            if (node == null) return;
            if (node.Value.YearPublisher == int.Parse(key))
            {
                searchRes.Add(node);
            }
            Search(node.Left, key);
            Search(node.Right, key);
            
        }
    
        public void InOrderTraversalLeftString()
        {
            InOrderTraversalRecursiveString(Root);
        }

        private void InOrderTraversalRecursiveString(NodeTree node)
        {
            if (node != null)
            {

                InOrderTraversalRecursiveString(node.Left);
                _obh += node.Value.ToString()+ "\n";
                InOrderTraversalRecursiveString(node.Right);
            }
        }
        public override string ToString()
        {
            var txt = "";
            foreach(NodeTree val in searchRes)
            {
                txt += val.ToString()+"\n";
            }
            return txt;
        }

        private string _obh = "";
 
        private string ResSearch = "";
        public string InOrderTraversal => $"{"Автор",-12} | {"Название",-32} | {"Издательство",-16} | {"Год",-5} | {"Количество страниц",-5}\n" +
                        $"-----------------------------------------------------------------------------------------------\n"  + _obh;
    }
}
