using QuestPDF.Infrastructure;

namespace  Notebook;

public class DocState
{
    public IDocumentContainer container { get; }
    public Spec spec { get; }

    public DocState(Spec spec, IDocumentContainer container)
    {
        this.spec = spec;
        this.container = container;
    }
}
public interface IPageSetWriter
{
    /// <summary>
    /// Create the main page for this writer
    /// </summary>
    /// <param name="state">The current state of the document</param>
    /// <returns></returns>
    DocState WriteBody(DocState state);
}