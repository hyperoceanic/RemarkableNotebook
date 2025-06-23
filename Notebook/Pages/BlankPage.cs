using QuestPDF.Fluent;

namespace Notebook.Pages;

public class BlankPage : DefaultPage, IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        for (var x = 0; x < state.Spec.PageCount; x++)
        {
            state.Container.Page(page => { OnePage(state, page, x); });
        }

        return state;
    }

    private void OnePage(DocState state, PageDescriptor page, int index)
    {
        PageInit(state, page, index);
        PageHeader(state, page, index);
        PageBody(state, page, index);
        PageFooter(state, page, index);
    }
}