using System;
using System.Windows.Forms;
using SomeProject.Library;
using SomeProject.Library.TcpClient;

namespace SomeProject.TcpClient
{
    public partial class ClientMainWindow : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ClientMainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отправки сообщения
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void OnMsgBtnClick(object sender, EventArgs e)
        {
            var client = new Client();

            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Сообщение не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            
            var res = client.SendMessageToServer(textBox.Text);
            
            textBox.Text = "";
            labelRes.Text = res.Message;

            if (res.Result == Result.OK)
            {
                textBox.Text = "";
            }

            timer.Interval = 2000;
            timer.Start();
        }

        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            labelRes.Text = "";
            timer.Stop();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отправки файла
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void OnSendFileButtonClick(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            
            var client = new Client();
            var res = client.SendFileToServer(fileDialog.FileName);

            labelRes.Text = res.Message;

            timer.Interval = 2000;
            timer.Start();
        }
    }
}
