using QuestPDF.Infrastructure;

namespace Notebook.TableOfContents;

using QuestPDF.Fluent;
using QuestPDF.Helpers;

/// <summary>
/// Creates a default table of Contents
/// </summary>
public class DefaultTOC : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device.Width, state.Spec.Device.Height);
            page.PageColor(Colors.White);

            var fontFamily = Fonts.TimesNewRoman;
            var fontColor = Colors.Black;

            var header = page.Header()
                .PaddingTop(80F)
                .PaddingBottom(20F)
                .PaddingLeft(20F);

            header
                .Text("Contents")
                .AlignCenter()
                .FontSize(96)
                .FontFamily(fontFamily)
                .FontColor(fontColor);

            var content = page.Content();

            content.Table(table =>
            {
                table.ColumnsDefinition(columns => { columns.RelativeColumn(); });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle); // Draw line across as table header

                    IContainer CellStyle(IContainer container)
                    {
                        return container
                            .Background(DeviceUtils.GetColor(state.Spec.Color))
                            .PaddingVertical(8)
                            .PaddingHorizontal(16);
                    }
                });

                for (var x = 0; x < state.Spec.PageCount; x++)
                    table.Cell().ColumnSpan(1)
                        .Section($"NumberedPagesContent-{x}") // target for link back
                        .Element(CellStyle)
                        .SectionLink($"NumberedPages-{x}") // link to page
                        .Text($"{x + 1}").FontSize(42F)
                        ;

                IContainer CellStyle(IContainer container)
                {
                    if (state.Spec.Device.Handedness == Handedness.Right)
                        return container
                            .Border(1F)
                            .AlignRight()
                            .Padding(20);
                    return container
                        .Border(1)
                        .AlignLeft()
                        .Padding(10);
                }
            }); // EOF Table
        });
        return state;
    }
}