namespace TextEditorCommands
{
    /// <summary>
    /// Абстрактный класс сущности "действие текстового редактора"
    /// </summary>
    public abstract class Command
    {
        public Editor Editor;
        private string _backup;

        /// <summary>
        /// Конструктор, привязывающий действие к определенному редактору для дальнейшего использования
        /// </summary>
        /// <param name="editor">Используемый редактор</param>
        protected Command(Editor editor) => Editor = editor;

        /// <summary>
        /// Сохраняет текст из текстового поля редактора для дальнейшей отмены действия
        /// </summary>
        protected void Backup() => _backup = Editor.Text;

        /// <summary>
        /// Отменяет действие
        /// </summary>
        public void Undo() => Editor.Text = _backup;

        /// <summary>
        /// Выполняет действие
        /// </summary>
        /// <returns>Возвращает true, если произошло изменение текстового поля редактора, иначе false</returns>
        public abstract bool Execute();
    }
}
