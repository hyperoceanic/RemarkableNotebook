using QuestPDF.Infrastructure;

namespace Notebook.TableOfContents;

using QuestPDF.Fluent;
using QuestPDF.Helpers;

/// <summary>
/// Creates a default table of Contents
/// </summary>
public class DefaultTOC : IPagesWriter
{
    private const string copyright =
        """
        Copyright, usage, attribution etc
        You can use these notebooks in any way you wish with the following restrictions:

        1. The copyright for these PDF files remains with Mark Smith.
        2. You may not distribute them, in any form, blank or filled without obtaining prior written permission.
        3. You may not sell them, in any form, blank or filled in without obtaining prior written permission.
        4. You may not modify or remove any part of them, including any copyright or attribution notices.
        5. You must try to at all times be kind.
        """;

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
                            .Background(DeviceUtils.GetColor(state.Spec.BackgroundColor))
                            .PaddingVertical(8)
                            .PaddingHorizontal(16);
                    }
                });

                // Write out a line in the TOC for every page in the content section of the document.
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

                table.Cell()
                    .Padding(12F)
                    .Text(copyright)
                    .FontSize(22F)
                    ;
            }); // EOF Table
        });
        return state;
    }
}