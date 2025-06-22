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
    public Cover? Cover { get; set; }

    [YamlIgnore]
    public string FileName => $"{nameof(this.Device.sku)}_{nameof(this.Device.orientation)}_{nameof(this.Device.handedness)}_{revision}.pdf";
}