using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemographicFileOperations
{
    /// <summary>
    /// Класс для проверки строки на число
    /// </summary>
    public class Checker
    {
        string _toCheck;


        /// <summary>
        /// Задает новую строку для проверки.
        /// </summary>
        /// <param name="newCheck">Новая строка для проверки.</param>
        public void ChangeCheck(string newCheck)
        {
            _toCheck = newCheck;
        }

        /// <summary>
        /// Проверка, ялвяется ли строка double числом.
        /// </summary>
        public bool DoubleCheck()
        {
            bool res = true;
            bool dot = false;
            for (int i = 0; i < _toCheck.Length; i++)
            {
                if (Char.IsNumber(_toCheck[i]) || (dot == false && _toCheck[i] == '.') || _toCheck[i] == ' ')
                {
                    if (_toCheck[i] == '.')
                        dot = true;
                }
                else
                    res = false;
            }
            return res;
        }

        /// <summary>
        /// Проверка, является ли строка целым числом.
        /// </summary>
        public bool IntCheck()
        {
            bool res = true;
            for (int i = 0; i < _toCheck.Length; i++)
            {
                if (!Char.IsNumber(_toCheck[i]) && _toCheck[i] != ' ')
                {
                    res = false;
                }
            }
            return res;
        }
    }
}
