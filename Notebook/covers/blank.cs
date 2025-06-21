using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Notebook;

/// <summary>
/// Creates a blank front page. No text, no colours.
/// </summary>
public class BlankCover : IPageSetWriter
{
    public DocState WriteBody(DocState state)
    {
        state.container.Page(page =>
        {
            page.Size(state.spec.Device.Height, state.spec.Device.Width);
            page.PageColor(Colors.White);
        });
        return state;
    }
}