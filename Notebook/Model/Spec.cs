using Notebook.Covers;
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
    const string revision = "a";
    public Device? Device { get; set; }

    public String Color { get; set; }

    public Cover? Cover { get; set; }
    public TOCSpec? TOC { get; set; }

    [YamlIgnore]
    public string FileName =>
        $"{Enum.GetName(Device.SKU)}_{Enum.GetName(Device.Orientation)}_{Enum.GetName(Device.Handedness)}_{revision}.pdf";
}