using SAOD_Kyrsach.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual
{
    internal class CodeText
    {
        public CodeText(Dictionary<char, double> Symbol, Dictionary<char,string> codes,GilbertMoore gilbert)
        {
            _codes = codes;
            _symbol = Symbol;
            _gilbert = gilbert;
        }
        public override string ToString()
        {
            string txt = $"n-------------------------------------------------\n" +
                $"| Символ | Вероятность | Кодовое слово | Длинна |\n" +
                $"-------------------------------------------------\n";
            foreach (var code in _codes)
            {
                txt += $"|   {code.Key,-4} | {((double)(_symbol[code.Key])),-15:F9} |{code.Value,-16} |   {code.Value.Length,-2}   |\n";
            }
            txt += $"\n\n\nКоличество символов : {_gilbert.codes.Count}\n" +
                $"Энтопия источника : {_gilbert.entopia}\n" +
                $"Средняя длина : {_gilbert.srLength}\n" +
                $"Избыточность : {Math.Abs(_gilbert.entopia - _gilbert.srLength)} ";
            return txt ;    
        }
        private Dictionary<char, double> _symbol;
        private Dictionary<char, string> _codes;
        private GilbertMoore _gilbert;

    }
}
