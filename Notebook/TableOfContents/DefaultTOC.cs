namespace Notebook.TableOfContents;

using QuestPDF.Fluent;
using QuestPDF.Helpers;

/// <summary>
/// Creates a default table of Contents
/// </summary>
public class DefaultTOC : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
            page.PageColor(Colors.White);

            var fontFamily = Fonts.TimesNewRoman;
            var fontColor = Colors.Black;

            var header = page.Header()
                .PaddingTop(80F)
                .PaddingBottom(20F)
                .PaddingLeft(20F);

            header
                .Text("Contents")
                .AlignCenter()
                .FontSize(96)
                .FontFamily(fontFamily)
                .FontColor(fontColor);
        });
        return state;
    }
}