namespace Notebook.Pages;

public enum PageStyle
{
    None,
    Default
}

public class PagesSpec
{
    public PageStyle Style { get; set; } = PageStyle.Default;
}