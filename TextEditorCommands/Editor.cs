using System.Collections.Generic;

namespace TextEditorCommands
{
    /// <summary>
    /// Реализация сущности "текстовый редактор"
    /// </summary>
    public class Editor
    {
        public string Text;
        public string Clipboard;

        private readonly Stack<Command> _history = new Stack<Command>();

        /// <summary>
        /// Отменить последнее действие
        /// </summary>
        public void Undo()
        {
            if (_history.Count == 0) return;

            var command = _history.Pop();
            command?.Undo();
        }

        /// <summary>
        /// Копировать текст из текстового поля
        /// </summary>
        public void Copy()
        {
            Execute(new CopyCommand(this));
        }

        /// <summary>
        /// Вставить текст из буфера обмена
        /// </summary>
        public void Paste()
        {
            Execute(new PasteCommand(this));
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        private void Execute(Command command)
        {
            if (command.Execute()) _history.Push(command);
        }
    }
}
