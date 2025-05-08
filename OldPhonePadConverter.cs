using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadApp
{
    public class OldPhonePadConverter
    {
        public static string OldPhonePad(string input)
        {
            Dictionary<char, string> keyMap = new Dictionary<char, string>()
        {
            { '1', "&'(" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " } // assume 0 returns a space
        };

            StringBuilder result = new StringBuilder();
            StringBuilder buffer = new StringBuilder();
            char lastChar = '\0';

            foreach (char c in input)
            {
                if (c == '#') break;

                if (c == '*')
                {
                    if (result.Length > 0)
                        result.Remove(result.Length - 1, 1);
                    buffer.Clear();
                }
                else if (c == ' ')
                {
                    // Confirm previous buffer
                    CommitBuffer(result, buffer, keyMap);
                    buffer.Clear();
                    lastChar = '\0';
                }
                else if (char.IsDigit(c))
                {
                    if (lastChar == c || buffer.Length == 0)
                    {
                        buffer.Append(c);
                    }
                    else
                    {
                        // new digit after different one
                        CommitBuffer(result, buffer, keyMap);
                        buffer.Clear();
                        buffer.Append(c);
                    }

                    lastChar = c;
                }
            }

            // Final commit if needed
            CommitBuffer(result, buffer, keyMap);

            return result.ToString();
        }

        private static void CommitBuffer(StringBuilder result, StringBuilder buffer, Dictionary<char, string> keyMap)
        {
            if (buffer.Length == 0) return;

            char key = buffer[0];
            int count = buffer.Length;

            if (keyMap.ContainsKey(key))
            {
                string letters = keyMap[key];
                int index = (count - 1) % letters.Length;
                result.Append(letters[index]);
            }
        }
    }
}