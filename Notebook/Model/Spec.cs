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
    public Device? Device { get; set; }
    public BlankCover? blankCover { get; set; }

    [YamlIgnore]
    public string FileName => $"{nameof(this.Device.sku)}.pdf";
}