using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Telegram.Bot.Types;

namespace Task11Bot.Utilities
{
    public static class WorkWithString
    {
        public static string SumIntInString(string message)
        {
            // Очищаем введенную строку от лишних пробелов:
            string cleanMessage = RemoveExtraSpaces(message);

            // Переводим строку в массив
            string[] intArray = cleanMessage.Split(' ');

            // Проверяем, что массив содержит только числа, подсчитываем сумму чисел
            bool parseError = false;
            int number = 0;
            int sum = 0;
            // Проверка на переполнение (больше IntMax, меньше IntMin) 
            foreach (string str in intArray)
            {
                if (int.TryParse(str, out number) == false)
                {
                    parseError = true;
                }
                else
                {
                    sum = sum + number;
                }
            }

            // Выводим результат
            if (parseError == true)
            {
                return "Введенная строка содержить не только цифры, либо введено число, выходящее из диапозона для типа Int.";
            }
            else
            {
                return sum.ToString();
            }
  

        }
        /// <summary>
        /// Метод, для удаление лишних пробелов из переданной строки, возвращает очищенную строку
        /// </summary>
        /// <param name="input">Очищаемая строка</param>
        /// <returns>Очищенная строка</returns>
        public static string RemoveExtraSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return Regex.Replace(input.Trim(), @"\s+", " ");
        }
    }
}
