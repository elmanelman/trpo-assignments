namespace TextEditorCommands
{
    /// <summary>
    /// Реализация сущности "команда копирования"
    /// </summary>
    internal class CopyCommand : Command
    {
        /// <summary>
        /// Конструктор, привязывающий действие к определенному редактору для дальнейшего использования
        /// </summary>
        /// <param name="editor">Используемый редактор</param>
        public CopyCommand(Editor editor) : base(editor) {}

        /// <summary>
        /// Выполняет копирование из текстового поля редактора в буфер обмена
        /// </summary>
        /// <returns>Всегда false, поскольку не меняет текстовое поле редактора</returns>
        public override bool Execute()
        {
            Editor.Clipboard = Editor.Text;

            return false;
        }
    }
}
