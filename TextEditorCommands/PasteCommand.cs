namespace TextEditorCommands
{
    /// <summary>
    /// Реализация сущности "команда копирования"
    /// </summary>
    internal class PasteCommand : Command
    {
        /// <summary>
        /// Конструктор, привязывающий действие к определенному редактору для дальнейшего использования
        /// </summary>
        /// <param name="editor">Используемый редактор</param>
        public PasteCommand(Editor editor) : base(editor) {}

        /// <summary>
        /// Выполняет вставку из буфера обмена в текстовое поле редактора
        /// </summary>
        /// <returns>Возвращает true, если произошло изменение текстового поля редактора, иначе false</returns>
        public override bool Execute()
        {
            if (string.IsNullOrEmpty(Editor.Clipboard))
            {
                return false;
            }

            Backup();
            Editor.Text = Editor.Clipboard;

            return true;
        }
    }
}
