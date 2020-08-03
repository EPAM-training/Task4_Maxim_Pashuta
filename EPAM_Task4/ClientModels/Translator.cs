using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EPAM_Task4.ClientModels
{
    /// <summary>
    /// Class for translating messages.
    /// </summary>
    public static class Translator
    {
        /// <summary>
        /// Dictionary for storing Russian letters and their translation into English.
        /// </summary>
        private static Dictionary<string, string> _translatorToEnglish = new Dictionary<string, string>
        {
            {"а", "a"},
            {"б", "b"},
            {"в", "v"},
            {"г", "g"},
            {"д", "d"},
            {"е", "e"},
            {"ж", "zh"},
            {"з", "z"},
            {"и", "i"},
            {"й", "i"},
            {"к", "k"},
            {"л", "l"},
            {"м", "m"},
            {"н", "n"},
            {"о", "o"},
            {"п", "p"},
            {"р", "r"},
            {"с", "s"},
            {"т", "t"},
            {"у", "u"},
            {"ф", "f"},
            {"х", "h"},
            {"ц", "c"},
            {"ч", "ch"},
            {"ш", "sh"},
            {"щ", "sh"},
            {"ъ", ""},
            {"ы", "i"},
            {"ь", ""},
            {"э", "e"},
            {"ю", "yu"},
            {"я", "ia"}
        };

        /// <summary>
        /// Dictionary for storing English letters and their translation into Russian.
        /// </summary>
        private static Dictionary<string, string> _translatorToRussian = new Dictionary<string, string>
        {
            {"a", "а"},
            {"b", "б"},
            {"c", "ц"},
            {"d", "д"},
            {"e", "е"},
            {"f", "ф"},
            {"g", "г"},
            {"h", "х"},
            {"i", "и"},
            {"j", "дж"},
            {"k", "к"},
            {"l", "л"},
            {"m", "м"},
            {"n", "н"},
            {"o", "о"},
            {"p", "п"},
            {"q", "кв"},
            {"r", "р"},
            {"s", "с"},
            {"t", "т"},
            {"u", "у"},
            {"v", "в"},
            {"w", "в"},
            {"x", "кс"},
            {"y", "и"},
            {"z", "з"},
        };

        /// <summary>
        /// The method translates the message into English or Russian and returns it.
        /// </summary>
        /// <param name="message">Message for translation</param>
        /// <returns></returns>
        public static string TranslateMessage(string message)
        {
            message = message.ToLower();

            if (!Regex.IsMatch(message, @"\P{IsCyrillic}"))
            {
                foreach (string letter in _translatorToEnglish.Keys)
                {
                    message = message.Replace(letter, _translatorToEnglish[letter]);
                }
            }
            else
            {
                foreach (string letter in _translatorToRussian.Keys)
                {
                    message = message.Replace(letter, _translatorToRussian[letter]);
                }
            }

            return message;
        }
    }
}
