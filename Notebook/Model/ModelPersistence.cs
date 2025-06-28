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

    public static Spec CreateSample() =>
        new()
        {
            BackgroundColor = RemarkableColor.Blue,
            PageCount = 100,
            Device = new Device
            {
                SKU = DeviceSKU.Remarkable2,
                Orientation = Orientation.Portrait,
                Handedness = Handedness.Left
            },
            Cover = new Cover
            {
                Style = CoverStyle.Exercise,
                TopOval = OvalStyle.Tall,
                LowOval = OvalStyle.Short
            },
            TOC = new TOCSpec
            {
                Style = TOCStyle.Default
            },
            Pages = new PagesSpec
            {
                Style = PageStyle.Lined
            }
        };
}