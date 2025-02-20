﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SAOD_Kyrsach;
using SAOD_Kyrsach.BookRecord;
using SAOD_Kyrsach.DigitalSort;
using SAOD_Kyrsach.Code;
using SAOD_Kyrsach.Tree;
using System.Threading.Tasks;
using Avalonia.Controls;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Visual
{
    internal class Info
    {
        public Info()
        {
            using (FileStream fs = new FileStream(@"C:\Users\karpo\OneDrive\Рабочий стол\SAOD_Kyrsach\SAOD_Kyrsach\testBase1.dat",
                   FileMode.Open))
            {
                byte[] author = new byte[12];
                byte[] title = new byte[32];
                byte[] publisher = new byte[16];
                byte[] yearPublishBytes = new byte[4];
                byte[] countPagesBytes = new byte[4];
                short yearPublish = 0;
                short countPages = 0;


                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Read(author) != 0)
                    {
                        int count = fs.Read(title);
                        count = fs.Read(publisher);
                        yearPublish = br.ReadInt16();
                        countPages = br.ReadInt16();
                        BookRecord bookRecord = new BookRecord(author, title, publisher, yearPublish, countPages);
                        _listBook.Add(new BookRecordAdapterGetLastNameByte(bookRecord));
                    }
                }
            }

            for(int i = 0; i < _listBook.Count; i++)
            {
                _listBef.Add((BookRecordAdapterGetLastNameByte)_listBook[i].Clone());
            }
            TextInfo textBefSort = new TextInfo(_listBef, 20);
            _textBefSort = textBefSort;


            for (int i = 0; i < _listBook.Count; i++)
            {
                _listAft.Add((BookRecordAdapterGetLastNameByte)_listBook[i].Clone());
            }

            TextInfo textAftSort = new TextInfo(_listAft, 20);
            _textAftSort = textAftSort;

            if (_listAft is IList<BookRecordAdapterGetLastNameByte> listOfBytesGetter)
            {
                DigitalSort.Sort(listOfBytesGetter);
            }
            byte[] file = File.ReadAllBytes("C:\\Users\\karpo\\OneDrive\\Рабочий стол\\SAOD_Kyrsach\\SAOD_Kyrsach\\testBase1.dat");
            char[] filechar = System.Text.Encoding.GetEncoding(866).GetString(file).ToCharArray();//new char[file.Length];
            


            string BefCode = "";
            foreach(var item in _listBook)
            {
                BefCode += item.ToString();
            }
            LengthChar = BefCode.Length;

            Dictionary<char, double> CharAndDouble = CalculateProbabilities(filechar);
            GilbertMoore gilbert = new GilbertMoore(CharAndDouble);
            foreach (var item in gilbert.codes)
            {
                _textCode += item.Value;
            }

            CodeText codeText = new CodeText( CharAndDouble, gilbert.codes, gilbert);
            _codetext = codeText;
            
        }
        static Dictionary<char, double> CalculateProbabilities(char[] inputArray)
        {
            var frequencyDict = new Dictionary<char, int>();
            int totalCount = inputArray.Length;

            foreach (var c in inputArray)
            {
                if (frequencyDict.ContainsKey(c))
                {
                    frequencyDict[c]++;
                }
                else
                {
                    frequencyDict[c] = 1;
                }
            }

            var probabilityDict = new Dictionary<char, double>();
            foreach (var kvp in frequencyDict)
            {
                probabilityDict[kvp.Key] = (double)kvp.Value / totalCount;
            }

            return probabilityDict;
        }
        public string TextBefSort => _textBefSort.ToString();
        public string TextAftSort => _textAftSort.ToString();
        public string TextTree => "Нужно сделать поиск";
        public string TextCode => _codetext.ToString();
        public IList<BookRecordAdapterGetLastNameByte> ListBef => _listBef;
        public IList<BookRecordAdapterGetLastNameByte> ListAft => _listAft;

        private TextInfo _textAftSort;
        private TextInfo _textBefSort;
        private string _textCode;   
        private int LengthCode = 0;
        private int LengthChar = 0;
        private CodeText _codetext;

        private IList<BookRecordAdapterGetLastNameByte> _listBef = new List<BookRecordAdapterGetLastNameByte>();
        private IList<BookRecordAdapterGetLastNameByte> _listAft = new List<BookRecordAdapterGetLastNameByte>();
        static private List<BookRecordAdapterGetLastNameByte> _listBook = new List<BookRecordAdapterGetLastNameByte>();
    }
}
