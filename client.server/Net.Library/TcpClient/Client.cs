using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SomeProject.Library.TcpClient
{
    /// <summary>
    /// Типы передаваемых данных
    /// </summary>
    public enum DataType
    {
        Message, File
    }

    /// <summary>
    /// Клиент
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Клиент соединения
        /// </summary>
        public System.Net.Sockets.TcpClient TcpClient;

        /// <summary>
        /// Функция для обработки сообщений от сервера
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Результат операции</returns>
        public OperationResult ReceiveMessageFromServer(NetworkStream stream)
        {
            try
            {
                var receivedMessage = new StringBuilder();
                var data = new byte[256];
                var notRead = true;

                while(notRead)
                {
                    if (!stream.DataAvailable) continue;
                    
                    notRead = false;
                    var bytes = stream.Read(data, 0, data.Length);
                    
                    receivedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }

                stream.Close();

                return new OperationResult(Result.OK, receivedMessage.ToString());
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.ToString());
            }
        }

        /// <summary>
        /// Функция для отправки сообщения на сервер
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Результат операции</returns>
        public OperationResult SendMessageToServer(string message)
        {
            try
            {
                using (TcpClient = new System.Net.Sockets.TcpClient("127.0.0.1", 8080))
                {
                    using (var stream = TcpClient.GetStream())
                    {
                        stream.WriteByte((byte)DataType.Message);

                        var data = Encoding.UTF8.GetBytes(message);

                        stream.Write(data, 0, data.Length);

                        return ReceiveMessageFromServer(stream);
                    }
                }
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Функция для отправки файла на сервер
        /// </summary>
        /// <param name="filePath">Путь файла</param>
        /// <returns>Результат операции</returns>
        public OperationResult SendFileToServer(string filePath)
        {
            try
            {
                using (TcpClient = new System.Net.Sockets.TcpClient("127.0.0.1", 8080))
                {
                    using (var networkStream = TcpClient.GetStream())
                    {
                        var extension = Path.GetExtension(filePath);
                        
                        networkStream.WriteByte((byte)DataType.File);
                        networkStream.WriteByte(Convert.ToByte(extension.Length));
                        networkStream.Write(Encoding.UTF8.GetBytes(extension), 0, extension.Length);

                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            var buffer = new byte[4096];
                            var length = 0;

                            do
                            {
                                length = fileStream.Read(buffer, 0, buffer.Length);
                                networkStream.Write(buffer, 0, length);
                            } while (length > 0);
                        }

                        return ReceiveMessageFromServer(networkStream);
                    }
                }
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }
    }
}
