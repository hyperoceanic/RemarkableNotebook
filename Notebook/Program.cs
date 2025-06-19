// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using PDFNote.Model;

Console.WriteLine("Hello, World!");

if (args.Length == 0)
{
    Console.WriteLine("Usage: PDFNote.exe sample.ymal");
    Console.WriteLine("Please provide the name of a config file (eg 'sample.yaml').");
    Console.WriteLine("If the file does not exist, it will be created for you with some default values.");
    return;
}

var configFile = args[0];

if (!File.Exists(configFile))
{
    Console.WriteLine($"Creating sample - {configFile}.");
    var sample = ModelPersister.CreateSample();
    ModelPersister.Save(sample, configFile);
    Console.WriteLine(sample);
}

