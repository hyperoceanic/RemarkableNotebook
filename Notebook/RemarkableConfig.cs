namespace PDFNote.Remarkable;

using PDFNote.Model;

public record Device(DeviceSKU SKU, Orientation Orientation, Handedness Handedness)
{
    public int Height { get => DeviceUtils.GetDeviceDimensions(SKU, Orientation).Height; }
    public int Width {get => DeviceUtils.GetDeviceDimensions(SKU, Orientation).Width; }
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
    public static PageDimensions GetDeviceDimensions(DeviceSKU sku, PDFNote.Model.Orientation orientation) =>
    (sku, orientation) switch
    {
        (DeviceSKU.RemarkablePaperPro, Orientation.Portrait) => new(2160, 1620),
        (DeviceSKU.RemarkablePaperPro, Orientation.Landscape) => new(1620, 2160),
        (DeviceSKU.Remarkable2, Orientation.Portrait) => new(1872, 1404),
        (DeviceSKU.Remarkable2, Orientation.Landscape) => new(1404, 1872),
        (_, _) => new(0, 0)
    };

}

