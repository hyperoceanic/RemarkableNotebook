using Notebook.Covers;
using Notebook.Pages;
using Notebook.TableOfContents;
using YamlDotNet.Serialization;

namespace Notebook;

public enum Orientation
{
    Portrait,
    Landscape
}

public record PageDimensions(int Height, int Width);

public class Spec
{
    const string Revision = "a";
    public String Color { get; set; }
    public int PageCount { get; set; } = 100;
    public Device? Device { get; set; }

    public Cover? Cover { get; set; }
    public TOCSpec? TOC { get; set; }
    public PagesSpec? Pages { get; set; }

    [YamlIgnore]
    public string FileName =>
        $"{Enum.GetName(Device.SKU)}_{Enum.GetName(Device.Orientation)}_{Enum.GetName(Device.Handedness)}_{Revision}.pdf";
}