using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Pages;

public class LinedPage : DefaultPage, IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        for (var x = 0; x < state.Spec.PageCount; x++)
        {
            state.Container.Page(page => { OnePage(state, page, x); });
        }

        return state;
    }

    protected override void PageBody(DocState state, PageDescriptor page, int index)
    {
        var bh = BodyHeight(state);
        var linesCount = LinesCount(state);
        var spacing = LineSpacingValue(state.Spec.Pages.LineSpacing);

        // Console.WriteLine($"Body Height: {bh}, Lines count: {linesCount}, Spacing: {spacing}");

        var content = page.Content();

        content
            //.DebugArea()
            .Column(col =>
            {
                for (var x = 0; x < linesCount; x++)
                    col.Item()
                        //.DebugArea($"Line {x}",Colors.Green.Medium)
                        .PaddingVertical(spacing)
                        .AlignBottom()
                        .LineHorizontal(2)
                        .LineColor(Colors.Grey.Lighten1);
            });
    }

    private void OnePage(DocState state, PageDescriptor page, int index)
    {
        PageInit(state, page, index);
        PageHeader(state, page, index);
        PageBody(state, page, index);
        PageFooter(state, page, index);
    }

    private int LineSpacingValue(LineSpacing spacing) => spacing switch
    {
        LineSpacing.Narrow => 20,
        LineSpacing.Medium => 30,
        LineSpacing.Wide => 40,
        _ => 0
    };

    private int LinesCount(DocState state) =>
        // padding applies above AND below
        BodyHeight(state) / (2 * LineSpacingValue(state.Spec.Pages.LineSpacing));
}