using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Pages;

public class DefaultPage
{
    const int PaddingAllowance = 100;

    protected int HeaderHeight => 130;

    protected int FooterHeight => 80;

    protected void PageInit(DocState state, PageDescriptor page, int index)
    {
        page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
        page.PageColor(Colors.White);
    }

    protected void PageHeader(DocState state, PageDescriptor page, int index)
    {
        page.Header()
            .Section($"NumberedPages-{index}")
            .Height(HeaderHeight);
    }

    protected virtual void PageBody(DocState state, PageDescriptor page, int index)
    {
    }

    protected void PageFooter(DocState state, PageDescriptor page, int index)
    {
        page.Footer()
            .PaddingTop(10F)
            .PaddingBottom(FooterHeight)
            .AlignCenter()
            .SectionLink($"NumberedPagesContent-{index}")
            .Text($"Page {index + 1} ↩")
            .AlignCenter()
            .FontSize(40)
            .FontFamily(Fonts.TimesNewRoman)
            .FontColor(Colors.Black);
    }

    protected int BodyHeight(DocState state) => state.Spec.Device.Height
                                                - PaddingAllowance
                                                - HeaderHeight
                                                - FooterHeight;
}