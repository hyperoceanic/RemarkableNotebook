namespace Notebook;

public class Device
{
    public DeviceSKU SKU { get; set; }
    public Orientation Orientation { get; set; }
    public Handedness Handedness { get; set; }

    internal int Height => DeviceUtils.GetDeviceDimensions(SKU, Orientation).Height;

    internal int Width => DeviceUtils.GetDeviceDimensions(SKU, Orientation).Width;

    internal int DPi => DeviceUtils.DPI(SKU);

    internal string FileName => $"{Enum.GetName(SKU)}_{Enum.GetName(Orientation)}_{Enum.GetName(Handedness)}";
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
}