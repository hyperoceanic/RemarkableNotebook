using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Covers;

/// <summary>
///     Creates a blank front page. No text, no colours.
/// </summary>
public class PlainCover : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device.Width, state.Spec.Device.Height);

            page.PageColor(Colors.White);

            page.Margin(50);

            page.Header().Height(100).Background(Colors.Grey.Lighten1);
            page.Content().Background(Colors.Grey.Lighten3);
            page.Footer().Height(50).Background(Colors.Grey.Lighten1);
        });
        return state;
    }
}