using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SomeProject.Library.TcpClient;

namespace SomeProject.Library.TcpServer
{
    /// <summary>
    /// Сервер
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Максимальное число соединений
        /// </summary>
        private const int MaxConnections = 1;

        /// <summary>
        /// Текущее число соединений
        /// </summary>
        private static int _currentConnections;

        /// <summary>
        /// Счётчик файлов
        /// </summary>
        private static int _fileCounter;

        /// <summary>
        /// Формат даты для именования папки
        /// </summary>
        private const string DateFormatString = "yyyy-MM-dd";

        /// <summary>
        /// Объект для синхронизации
        /// </summary>
        private static readonly object Locker = new object();

        /// <summary>
        /// Слушатель соединений
        /// </summary>
        private readonly TcpListener _listener;

        public Server()
        {
            _listener = new TcpListener(IPAddress.Loopback, 8080);
        }

        ~Server()
        {
            StopListener();
        }

        /// <summary>
        /// Остановка слушателя соединений
        /// </summary>
        /// <returns>Возникла ошибка</returns>
        public bool StopListener()
        {
            try
            {
                _listener?.Stop();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("failed stopping listener: " + e.Message);
                
                return false;
            }
        }

        /// <summary>
        /// Запуск слушателя соединений
        /// </summary>
        public async Task StartListener()
        {
            try
            {
                _listener?.Start();

                ThreadPool.SetMaxThreads(MaxConnections + 1, MaxConnections + 1);
                ThreadPool.SetMinThreads(2, 2);

                Console.WriteLine("waiting for connection...");

                while (true) {
                    bool connectionAvailable;

                    lock (Locker)
                    {
                        connectionAvailable = _currentConnections < MaxConnections;
                    }

                    if (!connectionAvailable) continue;

                    if (_listener == null) continue;

                    var client = _listener.AcceptTcpClient();
                    
                    Console.WriteLine($"connections: {Interlocked.Increment(ref _currentConnections)}");
                    ThreadPool.QueueUserWorkItem(Callback, client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed starting listener: {e.Message}");
            }
        }

        /// <summary>
        /// Обработчик подключения клиента
        /// </summary>
        /// <param name="clientObject">Клиент</param>
        private static void Callback(object clientObject)
        {   
            var client = (System.Net.Sockets.TcpClient)clientObject;

            ReceiveDataFromClient(client).Wait();
            client.Close();
            Console.WriteLine($"connections: {Interlocked.Decrement(ref _currentConnections)}");
        }

        /// <summary>
        /// Процедура для получения информации от клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <returns>Результат операции</returns>
        public static async Task<OperationResult> ReceiveDataFromClient(System.Net.Sockets.TcpClient client)
        {
            try
            {
                var recievedMessage = new StringBuilder();
                var typeByte = new byte[1];

                using (var stream = client.GetStream())
                {
                    await stream.ReadAsync(typeByte, 0, typeByte.Length);

                    //var type = recievedMessage.ToString();

                    switch (typeByte.First())
                    {
                        case (byte)DataType.Message:
                        {
                            var resultMessage = ReceiveMessageFromClient(stream).Message;
                            
                            return SendMessageToClient(stream, resultMessage);
                        }
                        case (byte)DataType.File:
                        {
                            var resultMessage = ReceiveFileFromClient(stream).Message;
                            
                            return SendMessageToClient(stream, resultMessage);
                        }
                        default:
                            return SendMessageToClient(stream, "data type unsupported");
                    }
                }
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Получение сообщения от клиента
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Результат операции</returns>
        private static OperationResult ReceiveMessageFromClient(NetworkStream stream)
        {
            var recievedMessage = new StringBuilder();

            try
            {
                var data = new byte[256];

                while (stream.DataAvailable)
                {
                    var bytes = stream.Read(data, 0, data.Length);
                    recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }

                Console.WriteLine("new message: " + recievedMessage);

                return new OperationResult(Result.OK, "message has been received");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Получение файла от клиента
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Результат операции</returns>
        private static OperationResult ReceiveFileFromClient(NetworkStream stream)
        {
            var extension = GetExtension(stream);
            var directoryName = DateTime.Now.ToString(DateFormatString);
            var data = new byte[1];

            try
            { 
                if (!Directory.Exists(directoryName)) 
                {
                    Directory.CreateDirectory(directoryName);
                }

                var currentNumber = Interlocked.Increment(ref _fileCounter);
                var filepath = $"{directoryName}\\File{currentNumber}{extension}";
                
                using (var fs = new FileStream(filepath, FileMode.Create))
                {
                    do
                    {
                        var bytes = stream.Read(data, 0, data.Length);
                        fs.Write(data, 0, bytes);
                    } while (stream.DataAvailable);
                }

                Console.WriteLine($"received file \"{filepath}\"");

                return new OperationResult(Result.OK, "file has been uploaded successfully");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Функция для получения расширения файла
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Расширение файла</returns>
        private static string GetExtension(Stream stream)
        {
            var extensionLength = stream.ReadByte();
            var extensionBytes = new byte[extensionLength];

            stream.Read(extensionBytes, 0, extensionBytes.Length);

            return Encoding.UTF8.GetString(extensionBytes);
        }

        /// <summary>
        /// Функция для отправки сообщения клиенту
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <param name="message">Сообщение клиенту</param>
        /// <returns>Результат операции</returns>
        private static OperationResult SendMessageToClient(Stream stream, string message)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(message);

                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                stream.Close();
                
                return new OperationResult(Result.Fail, e.Message);
            }

            return new OperationResult(Result.OK, "");
        }
    }
}