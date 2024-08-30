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
        public TextInfo(IList<BookRecordAdapterGetLastNameByte> listBook, int countPage)
        {
            _countPage = countPage;
            _listBook = listBook;
        }

        public override string ToString()
        {
            string txt = $"{"Автор",-12} | {"Название",-32} | {"Издательство",-16} | {"Год",-5} | {"Количество страниц",-5}\n" +
                         $"-----------------------------------------------------------------------------------------------\n";
            if (_countPage > _listBook.Count)
            {
                _countPage = _listBook.Count;
            }
            for(int i = _countPage - 20; i < _countPage; i++)
            {
                txt += _listBook[i].ToString() + "\n";
            }
            return txt;
        }
        private int _countPage;
        private IList<BookRecordAdapterGetLastNameByte> _listBook;
    }
}
