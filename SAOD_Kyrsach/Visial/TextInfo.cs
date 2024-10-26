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
using SAOD_Kyrsach.Tree;

namespace Visual
{
    internal class TextInfo
    {
        public TextInfo(IList<BookRecordAdapterGetLastNameByte> listBook, int countPage)
        {
            _countPage = countPage;
            _listBook = listBook;
            _key = -1;
        }
        public TextInfo(IList<BookRecordAdapterGetLastNameByte> listBook, int countPage, int key)
        {
            _countPage = countPage;
            _listBook = listBook;
            _key = key;
        }
   

        public override string ToString()
        {
            string txt = $"{"Автор",-12} | {"Название",-32} | {"Издательство",-16} | {"Год",-5} | {"Количество страниц",-5}\n" +
                         $"-----------------------------------------------------------------------------------------------\n";
            if (_countPage > _listBook.Count)
            {
                _countPage = _listBook.Count;
            }
            if(_countPage < 20)
            {
                _countPage = 20;
            }
            for(int i = _countPage - 20; i < _countPage; i++)
            {
                if (i == _key)
                {
                    txt += "-->";
                }   
                txt += i.ToString() + _listBook[i].ToString() + "\n";
               
            }
            return txt;
        }
        private int _key;
        private int _countPage;
        private IList<BookRecordAdapterGetLastNameByte> _listBook;
    }
}
