using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Account_Management_System.Helpers
{
    /// <summary>
    ///  Статический помощник.
    /// </summary>
    static class Checker
    {
        /// <summary>
        /// Проверка на заполнение поля.
        /// </summary>
        /// <param name="text">Текст из поля.</param>
        /// <returns>Заполнен или нет.</returns>
        public static bool IsCorrectField(params string[] texts)
        {
            foreach (string item in texts)
            {
                if (string.IsNullOrEmpty(item))
                    return false;
            }

            return true;
        }

    }
}
