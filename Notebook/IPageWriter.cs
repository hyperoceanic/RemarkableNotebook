using QuestPDF.Infrastructure;

namespace Notebook;

public class DocState
{
    public DocState(Spec spec, IDocumentContainer container)
    {
        Spec = spec;
        Container = container;
    }

    public required IDocumentContainer Container { get; init; }
    public required Spec Spec { get; init; }
}

public interface IPagesWriter
{
    /// <summary>
    /// Create the main page for this writer
    /// </summary>
    /// <param name="state">The current state of the document</param>
    /// <returns></returns>
    DocState WriteBody(DocState state);
}