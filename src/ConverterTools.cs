using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicodeAsciiConverter;

namespace UnicodeToBijoyBanglaTextConverter
{
    class ConverterTools
    {
        public static string GetAsciiBengaliFromUnicodeText(string text)
        {
            Converter c = new Converter();
            string result = c.Convert(text);

            //Debug.Log($"Bengali text: {text}, {result}");

            if (result.Contains("h়"))
            {
                result = result.Replace("h়", "q");
            }

            if (result.Contains("“"))
            {
                result = result.Replace("“", "æ");
            }

            if (result.Contains("­"))
            {
                result = result.Replace("­", "ø");
            }

            if (result.Contains("š—"))
            {
                result = result.Replace("š—", "šÍ");
            }

            if (result.Contains("«"))
            {
                result = result.Replace("«", "Ö");
            }

            if (result.Contains("¯—"))
            {
                result = result.Replace("¯—", "¯Í");
            }

            if (result.Contains("vÊ"))
            {
                result = result.Replace("vÊ", "vÐ");
            }

            // if (result.Contains("UÖ"))
            // {
            //     result = result.Replace("UÖ", "Uª");
            // }

            if (result.Contains("Ö"))
            {
                result = result.Replace("Ö", "ª");
            }

            if (result.Contains("PÊ"))
            {
                result = result.Replace("PÊ", "PÐ");
            }

            if (result.Contains("e‡liÖ"))
            {
                result = result.Replace("e‡liÖ", "e‡l©i");
            }

            if (result.Contains("h়"))
            {
                result = result.Replace("h়", "q");
            }

            if (result.Contains("DW‡়v"))
            {
                result = result.Replace("DW‡়v", "D‡ov");
            }

            if (result.Contains("h‡়"))
            {
                result = result.Replace("h‡়", "‡q");
            }

            if (result.Contains("dª"))
            {
                result = result.Replace("dª", "d«");
            }

            string[] words = result.Split(" ");
            List<string> listOfWords = new List<string>();


            foreach (string word in words)
            {
                string newWord = word;

                if (word.Length > 0)
                {
                    if (word.StartsWith("‡"))
                    {
                        newWord = $"†{word.Substring(1, word.Length - 1)}";
                    }
                }

                listOfWords.Add(newWord);
            }

            string newOutput = "";

            foreach (string word in listOfWords)
            {
                newOutput += $"{word} ";
            }

            newOutput = newOutput.Trim();

            if (newOutput.Contains("¨~"))
            {
                newOutput = newOutput.replace("¨~", "~¨");
            }

            if (newOutput.Contains("¨y"))
            {
                newOutput = newOutput.replace("¨y", "y¨");
            }

            if (text.Contains("(র্)"))
            {
                newOutput = text;
            }

            return newOutput;
        }

        public static bool IsBengali(string text)
        {
            string[] bengaliCharacters = {
                "অ", "আ", "ই", "ঈ", "উ", "ঊ", "ঋ", "ৠ", "ঌ", "ৡ", "এ", "ঐ", "ও", "ঔ", "ক", "খ", "গ", "ঘ", "ঙ", "চ", "ছ", "জ", "ঝ", "ঞ", "ট", "ঠ", "ড", "ঢ", "ণ", "ত", "থ", "দ", "ধ", "ন", "প", "ফ", "ব", "ভ", "ম", "য", "য়", "র", "ল", "ৱ", "শ", "ষ",  "স", "হ", "ক্ষ", "জ্ঞ", "ৎ"
            };

            bool isBengali = false;

            if (!string.IsNullOrEmpty(text))
            {
                foreach (string bengaliCharacter in bengaliCharacters)
                {
                    if (text.Contains(bengaliCharacter))
                    {
                        isBengali = true;
                        break;
                    }
                }
            }

            return isBengali;
        }

        public static bool IsEnglish(string text)
        {
            string[] characters = {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            bool isEnglish = false;

            if (!string.IsNullOrEmpty(text))
            {
                foreach (string englishCharacter in characters)
                {
                    if (text.Contains(englishCharacter))
                    {
                        isEnglish = true;
                        break;
                    }
                }
            }

            return isEnglish;
        }
    }
}
