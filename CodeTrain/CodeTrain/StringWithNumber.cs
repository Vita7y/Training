using System;
using System.Linq;

namespace CodeTrain
{
    public class StringWithNumber
    {
        public static string Incrace(string str)
        {
            var s = "";
            return Incrace(str, ref s);
        }

        private static string Incrace(string str, ref string num)
        {
            if (string.IsNullOrEmpty(str) || !IsNumber(str.Last()))
                return str + IncraseNumString(num);

            num += str.Last();
            return Incrace(str.Substring(0, str.Length - 1), ref num);
        }

        private static string IncraseNumString(string num)
        {
            var resNum = num.ToCharArray();

            for (var i = 0; i < resNum.Length; i++)
            {
                var ii = int.Parse(resNum[i].ToString());
                ii++;
                if (ii > 9)
                {
                    resNum[i] = '0';
                }
                else
                {
                    resNum[i] = Convert.ToChar(ii.ToString());
                    break;
                }
            }

            return new string(resNum.Reverse().ToArray());
        }

        public static bool IsNumber(char ch)
        {
            switch (ch)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                default:
                    return false;
            }
        }
    }
}