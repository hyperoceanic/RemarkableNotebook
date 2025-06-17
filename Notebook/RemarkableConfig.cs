namespace PDFNote.Remarkable;

using PDFNote.Model;

public enum DeviceSKU
{
    Remarkable2,
    RemarkablePaperPro
}

public static class DeviceUtils
{
    public static PageDimensions GetDeviceDimensions(DeviceSKU sku, PDFNote.Model.Orientation orientation) =>
    (sku, orientation) switch
    {
        (DeviceSKU.Remarkable2, Orientation.Portrait) => new (100, 60),
        (_, _) => new (0, 0)
    };

}

