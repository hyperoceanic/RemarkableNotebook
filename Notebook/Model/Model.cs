namespace Notebook;

public enum Orientation
{
    Portrait,
    Landscape
}

public record PageDimensions (int Height, int Width);

public class Spec
{
    public Device? Device { get; set; }
}