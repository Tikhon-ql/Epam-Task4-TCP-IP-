using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPLibrary.Another
{
    public static class Translator
    {
        static string rusAlf = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        //static string engAlf = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        static Dictionary<string, string> translator = new Dictionary<string, string>();
        static Translator()
        {
            translator.Add("а", "a");
            translator.Add("б", "b");
            translator.Add("в", "v");
            translator.Add("г", "g");
            translator.Add("д", "d");
            translator.Add("е", "e");
            translator.Add("ё", "yo");
            translator.Add("ж", "zh");
            translator.Add("з", "z");
            translator.Add("и", "i");
            translator.Add("й", "j");
            translator.Add("к", "k");
            translator.Add("л", "l");
            translator.Add("м", "m");
            translator.Add("н", "n");
            translator.Add("о", "o");
            translator.Add("п", "p");
            translator.Add("р", "r");
            translator.Add("с", "s");
            translator.Add("т", "t");
            translator.Add("у", "u");
            translator.Add("ф", "f");
            translator.Add("х", "h");
            translator.Add("ц", "c");
            translator.Add("ч", "ch");
            translator.Add("ш", "sh");
            translator.Add("щ", "sch");
            translator.Add("ъ", "j");
            translator.Add("ы", "i");
            translator.Add("ь", "j");
            translator.Add("э", "e");
            translator.Add("ю", "yu");
            translator.Add("я", "ya");
            translator.Add("А", "A");
            translator.Add("Б", "B");
            translator.Add("В", "V");
            translator.Add("Г", "G");
            translator.Add("Д", "D");
            translator.Add("Е", "E");
            translator.Add("Ё", "Yo");
            translator.Add("Ж", "Zh");
            translator.Add("З", "Z");
            translator.Add("И", "I");
            translator.Add("Й", "J");
            translator.Add("К", "K");
            translator.Add("Л", "L");
            translator.Add("М", "M");
            translator.Add("Н", "N");
            translator.Add("О", "O");
            translator.Add("П", "P");
            translator.Add("Р", "R");
            translator.Add("С", "S");
            translator.Add("Т", "T");
            translator.Add("У", "U");
            translator.Add("Ф", "F");
            translator.Add("Х", "H");
            translator.Add("Ц", "C");
            translator.Add("Ч", "Ch");
            translator.Add("Ш", "Sh");
            translator.Add("Щ", "Sch");
            translator.Add("Ъ", "J");
            translator.Add("Ы", "I");
            translator.Add("Ь", "J");
            translator.Add("Э", "E");
            translator.Add("Ю", "Yu");
            translator.Add("Я", "Ya");
        }
        public static string Translate(string str)
        {
            string result = str;
            int i = 0;
            foreach (KeyValuePair<string, string> item in translator) 
            {
                if (rusAlf.Contains(result[i].ToString()))
                    result = result.Replace(item.Key, item.Value);
                else
                    result = result.Replace(item.Value, item.Key);
            }
            return result;
        }
    }
}
