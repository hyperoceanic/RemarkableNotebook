using Notebook.Covers;
using Notebook.Pages;
using Notebook.TableOfContents;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Notebook;

public static class ModelPersister
{
    public static Spec Load(string filename)
    {
        var yaml = File.ReadAllText(filename);

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();

        try
        {
            var result = deserializer.Deserialize<Spec>(yaml);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException?.Message);
            throw;
        }
    }

    public static void Save(Spec spec, string filename)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();

        var yaml = serializer.Serialize(spec);

        File.WriteAllText(filename, yaml);
    }

    public static Spec CreateSample()
    {
        var result = new Spec();

        result.Color = "01579B";

        result.Device = new Device();
        result.Device.SKU = DeviceSKU.RemarkablePaperPro;
        result.Device.Orientation = Orientation.Portrait;
        result.Device.Handedness = Handedness.Right;

        result.Cover = new Cover();
        result.Cover.Style = CoverStyle.Exercise;
        result.Cover.TopOval = OvalStyle.Tall;
        result.Cover.LowOval = OvalStyle.Short;

        result.TOC = new TOCSpec();
        result.TOC.Style = TOCStyle.Default;

        result.Pages = new PagesSpec();
        result.Pages.Style = PageStyle.Blank;

        return result;
    }
}