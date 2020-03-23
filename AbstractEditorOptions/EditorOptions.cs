namespace AbstractEditorOptions
{
    /// <summary>
    ///     Интерфейс сущности "настройки редактора"
    /// </summary>
    public interface IEditorOptions
    {
        int FontSize { get; }
        string FontFamily { get; }
        int TabSize { get; }
        bool RenderWhitespace { get; }
        string CursorStyle { get; }
        bool InsertSpaces { get; }
        bool WordWrap { get; }
        int WordWrapColumn { get; }
    }

    /// <summary>
    ///     Реализация сущности "настройки редактора файлов C#"
    /// </summary>
    internal class CSharpEditorOptions : IEditorOptions
    {
        public CSharpEditorOptions()
        {
            FontSize = 14;
            FontFamily = "Consolas";
            TabSize = 4;
            RenderWhitespace = false;
            CursorStyle = "line";
            InsertSpaces = true;
            WordWrap = false;
            WordWrapColumn = 0;
        }

        public int FontSize { get; }
        public string FontFamily { get; }
        public int TabSize { get; }
        public bool RenderWhitespace { get; }
        public string CursorStyle { get; }
        public bool InsertSpaces { get; }
        public bool WordWrap { get; }
        public int WordWrapColumn { get; }
    }

    /// <summary>
    ///     Реализация сущности "настройки редактора файлов SQL"
    /// </summary>
    internal class SqlEditorOptions : IEditorOptions
    {
        public SqlEditorOptions()
        {
            FontSize = 16;
            FontFamily = "Consolas";
            TabSize = 4;
            RenderWhitespace = false;
            CursorStyle = "line";
            InsertSpaces = false;
            WordWrap = true;
            WordWrapColumn = 80;
        }

        public int FontSize { get; }
        public string FontFamily { get; }
        public int TabSize { get; }
        public bool RenderWhitespace { get; }
        public string CursorStyle { get; }
        public bool InsertSpaces { get; }
        public bool WordWrap { get; }
        public int WordWrapColumn { get; }
    }

    /// <summary>
    ///     Реализация сущности "настройки редактора файлов HTML"
    /// </summary>
    internal class HtmlEditorOptions : IEditorOptions
    {
        public HtmlEditorOptions()
        {
            FontSize = 12;
            FontFamily = "Consolas";
            TabSize = 2;
            RenderWhitespace = false;
            CursorStyle = "line";
            InsertSpaces = true;
            WordWrap = false;
            WordWrapColumn = 0;
        }

        public int FontSize { get; }
        public string FontFamily { get; }
        public int TabSize { get; }
        public bool RenderWhitespace { get; }
        public string CursorStyle { get; }
        public bool InsertSpaces { get; }
        public bool WordWrap { get; }
        public int WordWrapColumn { get; }
    }
}
