using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Notebook.Covers;

public class ExerciseBook : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device!.Width, state.Spec.Device.Height);

            page.PageColor(Colors.White);

            page.Margin(50);
        });

        return state;
    }
}