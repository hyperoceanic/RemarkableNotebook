using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Covers;

/// <summary>
/// Creates a blank front page. No text, no colours.
/// </summary>
public class BlankCover : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
            page.PageColor(Colors.White);
        });
        return state;
    }
}