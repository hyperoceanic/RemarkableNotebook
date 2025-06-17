namespace PDFNote.Model;

public enum Orientation
{
    Portrait,
    Landscape
}

public record PageDimensions (int Height, int Width);