namespace Notebook.Pages;

public enum PageStyle
{
    None,
    Blank,
    Lined,
    Dotted
}

public enum LineSpacing
{
    Narrow,
    Medium,
    Wide
}

public class PagesSpec
{
    public PageStyle Style { get; set; } = PageStyle.Blank;
    public LineSpacing LineSpacing { get; set; } = LineSpacing.Medium;
}