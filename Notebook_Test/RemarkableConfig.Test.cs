namespace Notebook_Test;

using FluentAssertions;

using PDFNote.Model;
using PDFNote.Remarkable;

public class RemarkableConfig_Test
{
      [Fact]
    public void DeviceUtils_GetDeviceDimensions_RM2_OK()
    {
        DeviceUtils.GetDeviceDimensions(DeviceSKU.Remarkable2, Orientation.Portrait)
            .Should().Be(new PageDimensions(1872, 1404));

        DeviceUtils.GetDeviceDimensions(DeviceSKU.Remarkable2, Orientation.Landscape)
            .Should().Be(new PageDimensions(1404, 1872));
    }

    [Fact]
    public void DeviceUtils_GetDeviceDimensions_RMPP_OK()
    {
        DeviceUtils.GetDeviceDimensions(DeviceSKU.RemarkablePaperPro, Orientation.Portrait)
            .Should().Be(new PageDimensions(2160, 1620));

        DeviceUtils.GetDeviceDimensions(DeviceSKU.RemarkablePaperPro, Orientation.Landscape)
            .Should().Be(new PageDimensions(1620, 2160));
    }
}