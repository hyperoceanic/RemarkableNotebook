namespace Notebook.Covers;

public enum CoverStyle
{
    None,
    Blank,
    Plain,
    Exercise
}

public enum OvalStyle
{
    None,
    Short,
    Medium,
    Tall
}

public class Cover
{
    public CoverStyle Style { get; set; }
    public OvalStyle? TopOval { get; set; }
    public OvalStyle? MidOval { get; set; }
    public OvalStyle? LowOval { get; set; }
}