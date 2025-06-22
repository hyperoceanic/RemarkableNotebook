using Notebook.Covers;
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
    public string FileName =>
        $"{Enum.GetName(Device.SKU)}_{Enum.GetName(Device.Orientation)}_{Enum.GetName(Device.Handedness)}_{revision}.pdf";
}