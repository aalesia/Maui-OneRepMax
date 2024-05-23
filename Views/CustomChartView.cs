using SkiaSharp.Views.Maui.Controls;
using Microcharts;
using SkiaSharp.Views.Maui;

namespace MauiApp1;

public class CustomChartView : SKCanvasView
{
    public static readonly BindableProperty ChartProperty = BindableProperty.Create(nameof(Chart), typeof(Chart), typeof(CustomChartView), null, propertyChanged: OnChartChanged);

    public Chart Chart
    {
        get { return (Chart)GetValue(ChartProperty); }
        set { SetValue(ChartProperty, value); }
    }

    private static void OnChartChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((CustomChartView)bindable).InvalidateSurface();
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        if (Chart == null)
        {
            Console.WriteLine("Chart is null");
            return;
        }

        try
        {
            Chart.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to draw chart: {ex}");
        }
    }
}
