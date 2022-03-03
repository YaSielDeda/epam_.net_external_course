using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3._3._2._SUPER_STRING
{
    public class StringMethods
    {
        private readonly string _str;
        public StringMethods(string str)
        {
            _str = new string(str);
        }
        public StringType DetectTypeOfString()
        {
            if (string.IsNullOrWhiteSpace(_str))
                return StringType.None;

            int stringType = (int)StringType.None;

            if (Regex.IsMatch(_str, "^[а-яА-Я]+$"))
                stringType += (int)StringType.Russian;

            if (Regex.IsMatch(_str, "^[a-zA-Z]+$"))
                stringType += (int)StringType.English;

            if (Regex.IsMatch(_str, "/d"))
                stringType += (int)StringType.Number;

            if (Regex.IsMatch(_str, "[.,/!?;:()_+=]"))
                stringType += (int)StringType.Mixed;

            if (((StringType)stringType) == StringType.Russian)
                return StringType.Russian;

            else if (((StringType)stringType) == StringType.English)
                return StringType.English;

            else if (((StringType)stringType) == StringType.Number)
                return StringType.Number;

            else return StringType.Mixed;
        }
    }
}
