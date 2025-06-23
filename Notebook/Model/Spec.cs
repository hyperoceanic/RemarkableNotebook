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
    public String ColorHex { get; set; }
    public String ColorName { get; set; } = "Blue";

    public int PageCount { get; set; } = 100;
    public Device? Device { get; set; }

    public Cover? Cover { get; set; }
    public TOCSpec? TOC { get; set; }
    public PagesSpec? Pages { get; set; }

    [YamlIgnore]
    public string FileName =>
        $"{Enum.GetName(Device.SKU)}" +
        $"/{Enum.GetName(Device.Handedness)}" +
        $"/{Enum.GetName(Pages.Style)}_{ColorName}_{Enum.GetName(Device.Orientation)}_{Revision}.pdf";
}