namespace Notebook;

public class Device
{

    public DeviceSKU sku { get; set; }
    public Orientation orientation { get; set; }
     public Handedness handedness { get; set; }
    internal int Height { get => DeviceUtils.GetDeviceDimensions(sku, orientation).Height; }
    internal int Width { get => DeviceUtils.GetDeviceDimensions(sku, orientation).Width; }

    internal int DPi { get => DeviceUtils.DPI(sku); }
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
        (DeviceSKU.RemarkablePaperPro, Orientation.Portrait) => new(2160, 1620),
        (DeviceSKU.RemarkablePaperPro, Orientation.Landscape) => new(1620, 2160),
        (DeviceSKU.Remarkable2, Orientation.Portrait) => new(1872, 1404),
        (DeviceSKU.Remarkable2, Orientation.Landscape) => new(1404, 1872),
        (_, _) => new(0, 0)
    };


    public static int DPI(DeviceSKU sku) => sku switch
    {
        DeviceSKU.RemarkablePaperPro => 229,
        DeviceSKU.Remarkable2 => 226,
        _ => 229
    };

}

