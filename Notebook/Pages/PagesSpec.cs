namespace Notebook.Pages;

public enum PageStyle
{
    None,
    Blank,
    Lined,
    Dotted
}

public class PagesSpec
{
    public PageStyle Style { get; set; } = PageStyle.Blank;
}