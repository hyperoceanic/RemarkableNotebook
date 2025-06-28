namespace Notebook;

public class Device
{
    public DeviceSKU SKU { get; set; }
    public Orientation Orientation { get; set; }
    public Handedness Handedness { get; set; }

    internal int Height => DeviceUtils.GetDeviceDimensions(SKU, Orientation).Height;

    internal int Width => DeviceUtils.GetDeviceDimensions(SKU, Orientation).Width;

    internal int DPi => DeviceUtils.DPI(SKU);
}

/// <summary>
/// The model of device to generate the PDF for.
/// </summary>
public enum DeviceSKU
{
    Remarkable2,
    RemarkablePaperPro
}

/// <summary>
/// Whether to render the documnent margin items like page numbers for left or right-handed users.
/// </summary>
public enum Handedness
{
    Left,
    Right
}

public enum RemarkableColor
{
    Black,
    Gray,
    White,
    Blue,
    Red,
    Green,
    Yellow,
    Cyan,
    Magenta,
    YellowHighlight,
    BlueHighlight,
    PinkHighlight,
    OrangeHighlight,
    GreenHighlight,
    GreyHighlight
}

public static class DeviceUtils
{
    /// <summary>
    /// Returns dimension of device screen in pixels.
    /// </summary>
    /// <param name="sku">Model of device to generate PDF For</param>
    /// <param name="orientation">Portrait or Landscape</param>
    /// <returns></returns>
    public static PageDimensions GetDeviceDimensions(DeviceSKU sku, Orientation orientation) =>
        (sku, orientation) switch
        {
            (DeviceSKU.RemarkablePaperPro, Orientation.Portrait) => new PageDimensions(2160, 1620),
            (DeviceSKU.RemarkablePaperPro, Orientation.Landscape) => new PageDimensions(1620, 2160),
            (DeviceSKU.Remarkable2, Orientation.Portrait) => new PageDimensions(1872, 1404),
            (DeviceSKU.Remarkable2, Orientation.Landscape) => new PageDimensions(1404, 1872),
            (_, _) => new PageDimensions(0, 0)
        };

    public static int DPI(DeviceSKU sku) => sku switch
    {
        DeviceSKU.RemarkablePaperPro => 229,
        DeviceSKU.Remarkable2 => 226,
        _ => 229
    };

    public static QuestPDF.Infrastructure.Color GetColorFromHexValue(string colorHex) =>
        string.IsNullOrEmpty(colorHex)
            ? QuestPDF.Helpers.Colors.White
            : QuestPDF.Infrastructure.Color.FromHex(colorHex);

    public static QuestPDF.Infrastructure.Color GetColor(RemarkableColor color) => color switch
    {
        RemarkableColor.Black => QuestPDF.Helpers.Colors.Black,
        RemarkableColor.Gray => QuestPDF.Helpers.Colors.Grey.Medium,
        RemarkableColor.White => QuestPDF.Helpers.Colors.White,
        RemarkableColor.Blue => QuestPDF.Helpers.Colors.Blue.Medium,
        RemarkableColor.Red => QuestPDF.Helpers.Colors.Red.Medium,
        RemarkableColor.Green => QuestPDF.Helpers.Colors.Green.Medium,
        RemarkableColor.Yellow => QuestPDF.Helpers.Colors.Yellow.Medium,
        RemarkableColor.Cyan => QuestPDF.Helpers.Colors.Cyan.Medium,
        RemarkableColor.Magenta => QuestPDF.Helpers.Colors.Purple.Medium,
        RemarkableColor.YellowHighlight => QuestPDF.Helpers.Colors.Yellow.Lighten2,
        RemarkableColor.BlueHighlight => QuestPDF.Helpers.Colors.Blue.Lighten2,
        RemarkableColor.PinkHighlight => QuestPDF.Helpers.Colors.Pink.Lighten2,
        RemarkableColor.OrangeHighlight => QuestPDF.Helpers.Colors.Orange.Lighten2,
        RemarkableColor.GreenHighlight => QuestPDF.Helpers.Colors.Green.Lighten2,
        RemarkableColor.GreyHighlight => QuestPDF.Helpers.Colors.Grey.Lighten2
    };
}