using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_Kyrsach.DigitalSort;

namespace SAOD_Kyrsach.BookRecord
{
    internal class BookRecordAdapterGetLastNameByte : IByteGetter
    {
        public BookRecordAdapterGetLastNameByte(BookRecord bookRecord)
        {
            _bookRecord = bookRecord;

            int count = 0;
            for (int i = 0; i < _bookRecord.Title.Length; ++i)
            {
                if (_bookRecord.Title[i] == 0x20) // 0x20 - код пробела 
                {
                    ++count;
                    if (count == 2)
                    {
                        _indexLastName = i + 1;
                    }
                }
            }
        }
        public byte GetByte(int index)
        {
            if (_indexLastName + index >= _bookRecord.Title.Length)
            {
                return 0;
            }
            return _bookRecord.Title[_indexLastName + index];
        }

        public int CountByte => _bookRecord.Title.Length - _indexLastName;

        public override string ToString()
        {
            return _bookRecord.ToString();
        }

        private BookRecord _bookRecord;
        private int _indexLastName = 0;
    }
}
