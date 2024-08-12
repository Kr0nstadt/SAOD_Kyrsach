using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SAOD_Kyrsach;
using SAOD_Kyrsach.BookRecord;
using SAOD_Kyrsach.DigitalSort;
using System.Threading.Tasks;
using Avalonia.Controls;
using System.IO;

namespace Visual
{
    internal class TextInfo
    {
        public TextInfo(IList<IByteGetter> listBook, int countPage)
        {
            _countPage = countPage;
            _listBook = listBook;
        }

        public override string ToString()
        {
            string txt = "";
            for(int i = 0; i < _countPage; i++)
            {
                txt += _listBook[i].ToString() + "\n";
            }
            return txt;
        }
        private int _countPage;
        private IList<IByteGetter> _listBook;
    }
}
