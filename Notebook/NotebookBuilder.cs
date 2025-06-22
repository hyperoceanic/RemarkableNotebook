using Notebook.Covers;
using Notebook.TableOfContents;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Notebook;

public static class NotebookBuilder
{
    private static IList<IPagesWriter> GetPagesWriters(Spec spec)
    {
        var result = new List<IPagesWriter>();

        var x = false;

        var w = x switch
        {
            true => "blue",
            false => "green"
        };

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

        return result;
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
            .WithSettings(new DocumentSettings
            {
                PdfA = false,
                CompressDocument = true,
                ImageCompressionQuality = ImageCompressionQuality.High,
                ImageRasterDpi = spec.Device.DPi,
                ContentDirection = ContentDirection.LeftToRight
            });

        result.GeneratePdf(spec.FileName);
        Console.WriteLine($"Finished document {spec.FileName}");
    }
}