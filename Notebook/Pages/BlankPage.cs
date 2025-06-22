using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Pages;

public class BlankPage : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        for (var x = 0; x < state.Spec.PageCount; x++)
        {
            state.Container.Page(page => { OnePage(state, page, x); });
        }

        return state;
    }

    private void PageHeader(DocState state, PageDescriptor page, int index)
    {
        page.Header()
            .Section($"NumberedPages-{index}")
            .Height(100F);
    }

    private void PageBody(DocState state, PageDescriptor page, int index)
    {
    }

    private void PageFooter(DocState state, PageDescriptor page, int index)
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

    private void OnePage(DocState state, PageDescriptor page, int index)
    {
        page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
        page.PageColor(Colors.White);
        PageHeader(state, page, index);
        PageBody(state, page, index);
        PageFooter(state, page, index);
    }
}