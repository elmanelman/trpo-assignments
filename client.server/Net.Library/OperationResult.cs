using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeProject.Library
{
    /// <summary>
    /// Тип результата
    /// </summary>
    public enum Result { OK, Fail };

    /// <summary>
    /// Класс результата с сообщением
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Результат 
        /// </summary>
        public Result Result;

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="result">Результат</param>
        /// <param name="message">Сообщение</param>
        public OperationResult(Result result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}
