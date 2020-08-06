using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorLibrary.Models
{
    public static class Translator
    {
        /// <summary>
        /// Dictionary to translate one word to another
        /// </summary>
        static Dictionary<char, string> rusToEng = new Dictionary<char, string>();
        static Translator()
        {
            //Filling dictionary
            rusToEng.Add('а', "a");
            rusToEng.Add('б', "b");
            rusToEng.Add('в', "v");
            rusToEng.Add('г', "g");
            rusToEng.Add('д', "d");
            rusToEng.Add('е', "e");
            rusToEng.Add('ё', "yo");
            rusToEng.Add('ж', "zh");
            rusToEng.Add('з', "z");
            rusToEng.Add('и', "i");
            rusToEng.Add('й', "j");
            rusToEng.Add('к', "k");
            rusToEng.Add('л', "l");
            rusToEng.Add('м', "m");
            rusToEng.Add('н', "n");
            rusToEng.Add('о', "o");
            rusToEng.Add('п', "p");
            rusToEng.Add('р', "r");
            rusToEng.Add('с', "s");
            rusToEng.Add('т', "t");
            rusToEng.Add('у', "u");
            rusToEng.Add('ф', "f");
            rusToEng.Add('х', "h");
            rusToEng.Add('ц', "c");
            rusToEng.Add('ч', "ch");
            rusToEng.Add('ш', "sh");
            rusToEng.Add('щ', "sch");
            rusToEng.Add('ъ', "j");
            rusToEng.Add('ы', "i");
            rusToEng.Add('ь', "j");
            rusToEng.Add('э', "e");
            rusToEng.Add('ю', "yu");
            rusToEng.Add('я', "ya");
            rusToEng.Add('А', "A");
            rusToEng.Add('Б', "B");
            rusToEng.Add('В', "V");
            rusToEng.Add('Г', "G");
            rusToEng.Add('Д', "D");
            rusToEng.Add('Е', "E");
            rusToEng.Add('Ё', "Yo");
            rusToEng.Add('Ж', "Zh");
            rusToEng.Add('З', "Z");
            rusToEng.Add('И', "I");
            rusToEng.Add('Й', "J");
            rusToEng.Add('К', "K");
            rusToEng.Add('Л', "L");
            rusToEng.Add('М', "M");
            rusToEng.Add('Н', "N");
            rusToEng.Add('О', "O");
            rusToEng.Add('П', "P");
            rusToEng.Add('Р', "R");
            rusToEng.Add('С', "S");
            rusToEng.Add('Т', "T");
            rusToEng.Add('У', "U");
            rusToEng.Add('Ф', "F");
            rusToEng.Add('Х', "H");
            rusToEng.Add('Ц', "C");
            rusToEng.Add('Ч', "Ch");
            rusToEng.Add('Ш', "Sh");
            rusToEng.Add('Щ', "Sch");
            rusToEng.Add('Ъ', "J");
            rusToEng.Add('Ы', "I");
            rusToEng.Add('Ь', "J");
            rusToEng.Add('Э', "E");
            rusToEng.Add('Ю', "Yu");
            rusToEng.Add('Я', "Ya");
        }
        /// <summary>
        /// Translate one word to another method
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Translate(string message)
        {
            StringBuilder translateMessage = new StringBuilder(message);
            int i = 0;
            foreach (KeyValuePair<char, string> item in rusToEng)
            {
                if ((translateMessage[i] > 'a' && translateMessage[i] < 'z') || (translateMessage[i] > 'A' && translateMessage[i] < 'Z'))
                    translateMessage.Replace(item.Value, item.Key.ToString());
                else
                    translateMessage.Replace(item.Key.ToString(), item.Value);
            }
            return translateMessage.ToString();
        }
    }
}
