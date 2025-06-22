namespace Notebook.TableOfContents;

public enum TOCStyle
{
    None,
    Default
}

public class TOCSpec
{
    public TOCStyle Style { get; set; } = TOCStyle.Default;
}