using System;
using System.Collections.Generic;
using System.Text;

namespace Task11Bot.Utilities
{
    public static class WorkWithString
    {
        public static int StringParseFromUserChose(string message, string userChose)
        {
            switch (userChose)
            {
                case "stringLenght":
                    return message.Length;
                    break;
                case "sumInt":
                    return 123;
                    break;
                default:
                    return 321;
            }

        }
    }
}
