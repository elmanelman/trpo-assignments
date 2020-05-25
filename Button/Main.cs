using System;
using System.Drawing;
using System.Windows.Forms;

namespace Button
{
    public partial class Main : Form
    {
        /// <summary>
		/// Перечисление направлений движения мыши
		/// </summary>
        private enum MouseDirection
        {
            Top, Bottom, Left, Right, NotMoving
        }

        private Point _lastPosition;
        private double _lastDistance;
        private Size _lastWindowSize;

        private bool _hasLeft = true;


        private Point Center => new Point(button.Location.X + button.Width / 2, button.Location.Y + button.Height / 2);

        public Main()
        {
            InitializeComponent();
            button.Left = (ClientSize.Width - button.Width) / 2;
            button.Top = (ClientSize.Height - button.Height) / 2;
            _lastWindowSize = ClientSize;
        }

        /// <summary>
		/// Нажатие на кнопку и вывод диалогового окна
		/// </summary>
        private void button_Click(object sender, EventArgs e) 
        {
            MessageBox.Show(
                "Вы нажали на кнопку!", 
                "Сообщение", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information, 
                MessageBoxDefaultButton.Button1, 
                MessageBoxOptions.DefaultDesktopOnly);
        }

        /// <summary>
        /// Обработчик движения мыши
		/// </summary>
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            var currentDistance = distance(e.Location, Center);
            double radius = Math.Max(button.Width, button.Height);

            if (currentDistance < _lastDistance && currentDistance < radius)
            {
                ButtonMoveButton(ButtonGetMouseDirection(e.Location), (int)distance(e.Location, _lastPosition));
            }

            _lastPosition = e.Location;
            _lastDistance = currentDistance;
        }

        /// <summary>
		/// Передвижение кнопки
		/// </summary>
		/// <param name="direction">Направление движения курсора</param>
		/// <param name="distance">Расстояние от курсора до центра кнопки</param>
        private void ButtonMoveButton(MouseDirection direction, int distance)
        {
            var mouseSpeed = (SystemInformation.MouseSpeed / 10 + 1) * distance;

            switch (direction)
            {
                case MouseDirection.Top:
                    if (button.Top > 0)
                        button.Top -= button.Top - mouseSpeed < 0
                            ? button.Top
                            : mouseSpeed;
                    break;
                case MouseDirection.Left:
                    if (button.Location.X > 0)
                        button.Left -= button.Left - mouseSpeed < 0
                            ? button.Left
                            : mouseSpeed;
                    break;
                case MouseDirection.Right:
                    if (button.Left + button.Width < ClientSize.Width)
                        button.Left += button.Left + button.Width + mouseSpeed < ClientSize.Width
                            ? mouseSpeed
                            : ClientSize.Width - button.Left - button.Width;
                    break;
                case MouseDirection.Bottom:
                    if (button.Top + button.Height < ClientSize.Height)
                        button.Top += button.Top + button.Height + mouseSpeed < ClientSize.Height
                            ? mouseSpeed
                            : ClientSize.Height - button.Top - button.Height;
                    break;
                case MouseDirection.NotMoving:
                    break;
            }
        }

        /// <summary>
		/// Расстояние между двумя точками
		/// </summary>
		/// <param name="first"> Первая точка </param>
		/// <param name="second"> Вторая точка </param>
		/// <returns> Расстояние между точками </returns>
        private double distance(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        /// <summary>
		/// Мышка вышла за пределы окна
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Main_MouseLeave(object sender, EventArgs e)
        {
            _hasLeft = true;
        }

        /// <summary>
		/// Определение направления движения мыши
		/// </summary>
		/// <param name="currentMousePosition"> Текущая позиция мыши</param>
		/// <returns> Направление движения </returns>
        private MouseDirection ButtonGetMouseDirection(Point currentMousePosition)
        {
            if (_hasLeft)
            {
                _hasLeft = false;
                return MouseDirection.NotMoving;
            }

            double diffX = _lastPosition.X - currentMousePosition.X;
            double diffY = _lastPosition.Y - currentMousePosition.Y;

            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                return diffX < 0 ? MouseDirection.Right : MouseDirection.Left;
            }
            else
            {
                return diffY < 0 ? MouseDirection.Bottom : MouseDirection.Top;
            }
        }

        /// <summary>
		/// Обработка изменения размера окна (чтобы кнопка всегда была видна)
		/// </summary>
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            var diffWidth = (ClientSize.Width - _lastWindowSize.Width) / 2;
            var diffHeight = (ClientSize.Height - _lastWindowSize.Height) / 2;

            if (button.Left + diffWidth < 0)
            {
                button.Left = 0;
            }
            else
            {
                button.Left += diffWidth;
            }

            if (button.Left + button.Width > ClientSize.Width)
            {
                button.Left = ClientSize.Width - button.Width;
            }
            else
            {
                button.Left = button.Left;
            }

            if (button.Top + diffHeight < 0)
            {
                button.Top = 0;
            }
            else
            {
                button.Top += diffHeight;
            }

            if (button.Top + button.Height > ClientSize.Height)
            {
                button.Top = ClientSize.Height - button.Height;
            }
            else
            {
                button.Top = button.Top;
            }

            _lastWindowSize = ClientSize;
        }
    }
}
