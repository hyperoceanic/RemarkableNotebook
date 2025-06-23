using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Pages;

public class DefaultPage
{
    protected void PageInit(DocState state, PageDescriptor page, int index)
    {
        page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
        page.PageColor(Colors.White);
    }

    protected void PageHeader(DocState state, PageDescriptor page, int index)
    {
        page.Header()
            .Section($"NumberedPages-{index}")
            .Height(100F);
    }

    protected virtual void PageBody(DocState state, PageDescriptor page, int index)
    {
    }

    protected void PageFooter(DocState state, PageDescriptor page, int index)
    {
        page.Footer()
            .PaddingTop(10F)
            .PaddingBottom(80F)
            .AlignCenter()
            .SectionLink($"NumberedPagesContent-{index}")
            .Text($"Page {index + 1} ↩")
            .AlignCenter()
            .FontSize(40)
            .FontFamily(Fonts.TimesNewRoman)
            .FontColor(Colors.Black);
    }
}