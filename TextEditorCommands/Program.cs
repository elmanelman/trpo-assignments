using System;

namespace TextEditorCommands
{
    internal class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        private static void Main()
        {
            var editor = new Editor { Text = "Hello, World!" };

            PrintEditorState(editor);

            Console.WriteLine("Performing copy... ");
            editor.Copy();

            PrintEditorState(editor);

            Console.WriteLine("Changing editor.Text... ");
            editor.Text = "Hello, Modified World!";

            PrintEditorState(editor);

            Console.WriteLine("Performing paste... ");
            editor.Paste();

            PrintEditorState(editor);

            Console.WriteLine("Undoing last action... ");
            editor.Undo();

            PrintEditorState(editor);
        }

        /// <summary>
        /// Печатает состояние редактора в консоль
        /// </summary>
        /// <param name="editor">Редактор, из которого берется состояние</param>
        private static void PrintEditorState(Editor editor)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Editor state:");
            Console.WriteLine($"\tCurrent editor.Text:\t\t{editor.Text}");
            Console.WriteLine($"\tCurrent editor.Clipboard:\t{editor.Clipboard}");
            
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
