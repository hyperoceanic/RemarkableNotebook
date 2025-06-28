namespace Notebook.Covers;

using QuestPDF.Fluent;
using QuestPDF.Helpers;

public class ExerciseBook : IPagesWriter
{
    public DocState WriteBody(DocState state)
    {
        state.Container.Page(page =>
        {
            page.Size(state.Spec.Device!.Width, state.Spec.Device.Height);

            var c = DeviceUtils.GetColor(state.Spec.BackgroundColor);

            page.PageColor(c);

            var svg = GetPageSVG(state);

            page.Content()
                .PaddingVertical(5)
                .PaddingHorizontal(5)
                .Svg(size => { return svg; });
        });

        return state;
    }

    int RectHeight(OvalStyle style) => style switch
    {
        OvalStyle.Short => 200,
        OvalStyle.Medium => 300,
        OvalStyle.Tall => 430,
        _ => 0
    };

    int VOffset(OvalStyle style) => style switch
    {
        OvalStyle.Short => 100,
        OvalStyle.Medium => 50,
        OvalStyle.Tall => 0,
        _ => 0
    };

    string Rect(Spec spec, OvalStyle ovalStyle, int y)
    {
        return
            $"""
             <rect
                 x="{200}"
                 y="{y + VOffset(ovalStyle)}"
                 rx ="10" ry="10"
                 width ="{spec.Device.Width - 400}"
                 height="{RectHeight(ovalStyle)}"
                 stroke="black" fill="white" stroke-width="5"/>
             """;
    }

    string Toprect(Spec spec) => spec.Cover.TopOval == OvalStyle.None
        ? ""
        : Rect(spec, spec.Cover.TopOval.Value, 210);

    string Midrect(Spec spec) => spec.Cover.MidOval == OvalStyle.None
        ? ""
        : Rect(spec, spec.Cover.MidOval.Value, 910);

    string Lowrect(Spec spec) => spec.Cover.LowOval == OvalStyle.None
        ? ""
        : Rect(spec, spec.Cover.LowOval.Value, 1610);

    private string GetPageSVG(DocState state)
    {
        return
            $"""
             <svg width="{state.Spec.Device.Width}" height="{state.Spec.Device.Height}" xmlns="http://www.w3.org/2000/svg">
             {Toprect(state.Spec)}
             {Midrect(state.Spec)}
             {Lowrect(state.Spec)}
             </svg>
             """;
    }
}