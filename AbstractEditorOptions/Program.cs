using System;
using System.IO;

namespace AbstractEditorOptions
{
    internal class Program
    {
        /// <summary>
        ///     Точка входа в приложение.
        /// </summary>
        private static void Main()
        {
            // read file name
            Console.Write("Enter file name: ");
            var fileName = Console.ReadLine();

            // extract file extension
            string extension;

            try
            {
                extension = Path.GetExtension(fileName);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return;
            }

            // use appropriate factory to get desired options
            IOptionsFactory optionsFactory;
            switch (extension)
            {
                case ".cs":
                    optionsFactory = new CSharpOptionsFactory();
                    break;
                case ".sql":
                    optionsFactory = new SqlOptionsFactory();
                    break;
                case ".html":
                case ".htm":
                    optionsFactory = new HtmlOptionsFactory();
                    break;
                default:
                    Console.WriteLine("Invalid extension: " + extension + ", exiting...");
                    return;
            }

            var fileOptions = optionsFactory.CreateFileOptions();
            var editorOptions = optionsFactory.CreateEditorOptions();

            PrettyPrintOptions(fileOptions, editorOptions);
        }

        /// <summary>
        ///     Печатает в консоль настройки редактора.
        /// </summary>
        /// <param name="fileOptions">Файловые настройки</param>
        /// <param name="editorOptions">Настройки редактора текста</param>
        private static void PrettyPrintOptions(IFileOptions fileOptions, IEditorOptions editorOptions)
        {
            Console.WriteLine($"Auto save file?\t\t{fileOptions.AutoSave}");
            Console.WriteLine($"Auto save delay (ms):\t{fileOptions.AutoSaveDelay}");
            Console.WriteLine($"Font size:\t\t{editorOptions.FontSize}");
            Console.WriteLine($"Font family:\t\t{editorOptions.FontFamily}");
            Console.WriteLine($"Tab size (spaces):\t{editorOptions.TabSize}");
            Console.WriteLine($"Render whitespace?\t{editorOptions.RenderWhitespace}");
            Console.WriteLine($"Cursor style:\t\t{editorOptions.CursorStyle}");
            Console.WriteLine($"Insert spaces?\t\t{editorOptions.InsertSpaces}");
            Console.WriteLine($"Wrap words?\t\t{editorOptions.WordWrap}");
            Console.WriteLine($"Word wrap column width:\t{editorOptions.WordWrapColumn}");
        }
    }
}
