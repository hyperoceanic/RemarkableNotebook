using Notebook;
using System.Diagnostics;


Console.WriteLine("Remarkable Notebook Builder");

if (args.Length == 0)
{
    Console.WriteLine("Usage: Notebook.exe sample.ymal");
    Console.WriteLine("Please provide the name of a config file (eg 'sample.yaml').");
    Console.WriteLine("If the file does not exist, it will be created for you with some default values.");
    return;
}

var configFileName = args[0];

if (!File.Exists(configFileName))
{
    Console.WriteLine($"Creating sample - {configFileName}.");
    var sample = ModelPersister.CreateSample();
    ModelPersister.Save(sample, configFileName);
    Console.WriteLine(sample);
}


Spec spec = ModelPersister.Load(configFileName);


NotebookBuilder.Build(spec);