namespace AbstractEditorOptions
{
    /// <summary>
    ///     Интерфейс сущности "файловые настройки"
    /// </summary>
    public interface IFileOptions
    {
        bool AutoSave { get; }
        int AutoSaveDelay { get; }
    }

    /// <summary>
    ///     Реализация сущности "файловые настройки C#"
    /// </summary>
    class CSharpFileOptions : IFileOptions
    {
        public CSharpFileOptions()
        {
            AutoSave = true;
            AutoSaveDelay = 1000;
        }

        public bool AutoSave { get; }
        public int AutoSaveDelay { get; }
    }

    /// <summary>
    ///     Реализация сущности "файловые настройки SQL"
    /// </summary>
    class SqlFileOptions : IFileOptions
    {
        public SqlFileOptions()
        {
            AutoSave = true;
            AutoSaveDelay = 1000;
        }

        public bool AutoSave { get; }
        public int AutoSaveDelay { get; }
    }

    /// <summary>
    ///     Реализация сущности "файловые настройки HTML"
    /// </summary>
    class HtmlFileOptions : IFileOptions
    {
        public HtmlFileOptions()
        {
            AutoSave = true;
            AutoSaveDelay = 500;
        }

        public bool AutoSave { get; }
        public int AutoSaveDelay { get; }
    }
}
