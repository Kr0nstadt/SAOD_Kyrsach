using SAOD_Kyrsach.BookRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual
{
    internal class Search
    {
        public Search(IList<BookRecordAdapterGetLastNameByte> list, string key)
        {
            _list = list;
            _key = key;
        }

        public override string ToString()
        {
            string txt = $"{"Автор",-12} | {"Название",-32} | {"Издательство",-16} | {"Год",-5} | {"Количество страниц",-5}\n" +
                        $"-----------------------------------------------------------------------------------------------\n";
            for(int i = 0; i < _list.Count; i++)
            {
                string temp = _list[i].ToString();
                if (_list[i].Title == _key)
                {
                    txt += temp + "\n";
                    SearchList.Add(_list[i]);
                }
            }
            return txt;
        }
        public IList<BookRecordAdapterGetLastNameByte> SearchList = new List<BookRecordAdapterGetLastNameByte>();
        private IList<BookRecordAdapterGetLastNameByte> _list;
        private string _key;
    }
}
