namespace PDFNote.Remarkable;

using PDFNote.Model;

public enum DeviceSKU
{
    Remarkable2,
    RemarkablePaperPro
}

public static class DeviceUtils
{
    /// <summary>
    /// returns pixels.
    /// </summary>
    /// <param name="sku"></param>
    /// <param name="orientation"></param>
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

