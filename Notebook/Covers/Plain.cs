namespace Notebook.Covers;

using QuestPDF.Fluent;
using QuestPDF.Helpers;

/// <summary>
/// Creates a blank front page. No text, with a border in the specified colour.,
/// </summary>
public class PlainCover : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
            page.PageColor(DeviceUtils.GetColor(state.Spec.BackgroundColor));

            page.Margin(50);
            page.Content().Background(Colors.Grey.Lighten3);
        });
        return state;
    }
}