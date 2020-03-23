namespace AbstractEditorOptions
{
    /// <summary>
    ///     Абстрактная фабрика настроек
    /// </summary>
    public interface IOptionsFactory
    {
        IFileOptions CreateFileOptions();
        IEditorOptions CreateEditorOptions();
    }

    /// <summary>
    ///     Фабрика настроек для редактора файлов C#
    /// </summary>
    class CSharpOptionsFactory : IOptionsFactory
    {
        public IFileOptions CreateFileOptions()
        {
            return new CSharpFileOptions();
        }

        public IEditorOptions CreateEditorOptions()
        {
            return new CSharpEditorOptions();
        }
    }

    /// <summary>
    ///     Фабрика настроек для редактора файлов SQL
    /// </summary>
    class SqlOptionsFactory : IOptionsFactory
    {
        public IFileOptions CreateFileOptions()
        {
            return new SqlFileOptions();
        }

        public IEditorOptions CreateEditorOptions()
        {
            return new SqlEditorOptions();
        }
    }

    /// <summary>
    ///     Фабрика настроек для редактора файлов HTML
    /// </summary>
    class HtmlOptionsFactory : IOptionsFactory
    {
        public IFileOptions CreateFileOptions()
        {
            return new HtmlFileOptions();
        }

        public IEditorOptions CreateEditorOptions()
        {
            return new HtmlEditorOptions();
        }
    }
}
