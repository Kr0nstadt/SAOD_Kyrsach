using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.Code
{
    public class GilbertMoore
    {
        public Dictionary<char, string> codes = new Dictionary<char, string>();
        public double srLength => SRLenght();
        public double entopia => Entopia();

        private Dictionary<char, double> symbolProbabilities;

        public GilbertMoore(Dictionary<char, double> dict)
        {
            symbolProbabilities = dict;
            BuildCodes();
        }

        private void BuildCodes()
        {
            var sortedSymbols = symbolProbabilities.OrderByDescending(x => x.Value).ToList();
            GenerateCodes();
        }

        private void GenerateCodes()
        {
            double comm = 0;
            double pr = 0.0;
            double sigma = 0.0;
            var dic = from entry in symbolProbabilities orderby entry.Value descending select entry;
            foreach (var item in dic)
            { 
                comm += item.Value;
                sigma = comm + item.Value / 2.0;
                int n = (int)-(Math.Ceiling(Math.Log2(item.Value / 2.0)));
                long l = DoubleToCode(sigma);
                string CodeString = Convert.ToString(l, 2).PadLeft(64, '0');
                codes[item.Key] = CodeString.Substring(13, n);
            }
        }
        private double SRLenght()
        {
            double SRLenght = 0.94;
            foreach (var val in codes)
            {
                SRLenght += symbolProbabilities[val.Key] * val.Value.Length;
            }
            return SRLenght;
        }

        private double Entopia()
        {
            double Entopia = 0.0;
            foreach (var val in codes)
            {
                Entopia -= symbolProbabilities[val.Key] * Math.Log2(symbolProbabilities[val.Key]);
            }
            return Entopia;
        }
        private long DoubleToCode(double code)
        {
            string[] codeStr = code.ToString().Split(",");
            string SubStr = "0," + codeStr[1];
          
            return BitConverter.DoubleToInt64Bits(Double.Parse(SubStr));
        }

        
    }
}
