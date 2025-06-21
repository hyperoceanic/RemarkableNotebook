using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Notebook;

public static class NotebookBuilder
{
    public static void Build(Spec spec)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var result = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(50);

                page.Header().Height(100).Background(Colors.Grey.Lighten1);
                page.Content().Background(Colors.Grey.Lighten3);
                page.Footer().Height(50).Background(Colors.Grey.Lighten1);
            });


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
    }

}