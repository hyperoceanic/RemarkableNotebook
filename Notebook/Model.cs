namespace PDFNote.Model;

public enum Orientation
{
    Portrait,
    Landscape
}

public record PageDimensions (int Height, int Width);

public class Spec
{
    public Remarkable.Device Device { get; set; }
}