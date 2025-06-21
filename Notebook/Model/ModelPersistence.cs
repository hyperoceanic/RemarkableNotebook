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

        result.Device = new Device();
        result.Device.sku = DeviceSKU.RemarkablePaperPro;
        result.Device.orientation = Orientation.Portrait;
        result.Device.handedness = Handedness.Right;

        return result;
    }

}