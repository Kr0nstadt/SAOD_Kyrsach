using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach
{
    internal class Book : IComparable<Book>
    {
        private string author;
        private string title;
        private string publisher;
        private int yearCreation;
        private int numPages;
         public Book(string author, string title, string publisher, int yearCreation, int numPages)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.yearCreation = yearCreation;
            this.numPages = numPages;
        }

        public override string ToString()
        {
            return $"{author}\t{title}\t{publisher}\t{yearCreation}\t{numPages}";
        }

        public int CompareTo(Book other)
        {
            string[] arrayOther = other.title.Split(" ") ;
            string[] arrayThis = this.title.Split(" ") ;
            char []otherVal = arrayOther[2].ToCharArray() ;
            char[]thisVal = arrayThis[2].ToCharArray();
            if (thisVal[0] < otherVal[0]) { return -1 ; }
            else if (thisVal[0] > otherVal[0]) { return 1 ; }
            else
            {
                if (thisVal[1] < otherVal[1]) { return -1; }
                else if (thisVal[1] > otherVal[1]) { return 1; }
                else
                {
                    if (thisVal[2] < otherVal[2]) { return -1; }
                    else if (thisVal[2] > otherVal[2]) { return 1; }
                    else { return 0; }
                }
            }
        }
    }
}
