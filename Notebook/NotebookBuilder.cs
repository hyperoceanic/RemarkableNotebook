using System.ComponentModel;
using System.Net;
using Microsoft.VisualBasic;
using Notebook.Covers;
using Notebook.Pages;
using Notebook.TableOfContents;
using QuestPDF;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Notebook;

public static class NotebookBuilder
{
    private static IList<IPagesWriter> GetPagesWriters(Spec spec)
    {
        var result = new List<IPagesWriter>();

        IPagesWriter? cov = spec.Cover.Style switch
        {
            CoverStyle.Plain => new PlainCover(),
            CoverStyle.Exercise => new ExerciseBook(),
            _ => null
        };

        if (cov != null) result.Add(cov);

        IPagesWriter? toc = spec.TOC.Style switch
        {
            TOCStyle.Default => new DefaultTOC(),
            _ => null
        };

        if (toc != null) result.Add(toc);

        IPagesWriter? pages = spec.Pages.Style switch
        {
            PageStyle.Blank => new BlankPage(),
            PageStyle.Lined => new LinedPage(),
            _ => null
        };

        if (pages != null) result.Add(pages);

        return result;
    }

    public static void BuildMany(Spec spec)
    {
        BuildMany(spec, Handedness.Left, RemarkableColor.Blue);
        BuildMany(spec, Handedness.Right, RemarkableColor.Blue);

        BuildMany(spec, Handedness.Left, RemarkableColor.BlueP);
        BuildMany(spec, Handedness.Right, RemarkableColor.BlueP);

        BuildMany(spec, Handedness.Left, RemarkableColor.Green);
        BuildMany(spec, Handedness.Right, RemarkableColor.Green);

        BuildMany(spec, Handedness.Left, RemarkableColor.Cyan);
        BuildMany(spec, Handedness.Right, RemarkableColor.Cyan);

        BuildMany(spec, Handedness.Left, RemarkableColor.Gray);
        BuildMany(spec, Handedness.Right, RemarkableColor.Gray);
    }

    public static void BuildMany(Spec spec, Handedness handedness, RemarkableColor backgroundColor)
    {
        spec.Device.Handedness = handedness;
        spec.BackgroundColor = backgroundColor;
        Build(spec);
    }

    public static void Build(Spec spec)
    {
        Settings.License = LicenseType.Community;

        Console.WriteLine($"Starting document {spec.FileName}");

        var writers = GetPagesWriters(spec);

        var result = Document.Create(container =>
            {
                var state = new DocState(spec, container)
                {
                    Container = container,
                    Spec = spec
                };

                foreach (var writer in writers) writer.WriteBody(state);
            })
            .WithMetadata(new DocumentMetadata
            {
                Author = "Mark Smith",
                CreationDate = DateTimeOffset.UtcNow,
                Title = spec.FileName
            })
            .WithSettings(new DocumentSettings
            {
                PdfA = false,
                CompressDocument = true,
                ImageRasterDpi = spec.Device.DPi,
                ContentDirection = ContentDirection.LeftToRight
            });

        var filename = $"../../../../../../Projects/blank-notebooks/{spec.FileName}";
        var fi = new FileInfo(filename);
        Directory.CreateDirectory(fi.DirectoryName);
        result.GeneratePdf(filename);
        Console.WriteLine($"Finished document {filename}");
    }
}