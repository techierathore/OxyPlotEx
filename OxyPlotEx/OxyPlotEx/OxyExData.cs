using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace OxyPlotEx
{
    public class OxyExData
    {
        public PlotModel PieModel { get; set; }
        public PlotModel AreaModel { get; set; }
        public PlotModel BarModel { get; set; }
        public PlotModel StackedBarModel { get; set; }

        public OxyExData()
        {
            PieModel = CreatePieChart();
            AreaModel = CreateAreaChart();
            StackedBarModel = CreateBarChart(true, "Stacked Bar Chart");
            BarModel = CreateBarChart(false, "Comparison Bar Chart");
        }
        private PlotModel CreatePieChart()
        {
            var model = new PlotModel { Title = "Pie Chart" };

            var ps = new PieSeries
            {
                StrokeThickness = .25,
                InsideLabelPosition = .25,
                AngleSpan = 360,
                StartAngle = 0
            };

            // http://www.nationsonline.org/oneworld/world_population.htm
            // http://en.wikipedia.org/wiki/Continent
            ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Asia", 4157));
            ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = false });
            model.Series.Add(ps);
            return model;
        }

        public PlotModel CreateAreaChart()
        {
            var plotModel1 = new PlotModel { Title = "Area Series with crossing lines" };
            var areaSeries1 = new AreaSeries();
            areaSeries1.Points.Add(new DataPoint(0, 50));
            areaSeries1.Points.Add(new DataPoint(10, 140));
            areaSeries1.Points.Add(new DataPoint(20, 60));
            areaSeries1.Points2.Add(new DataPoint(0, 60));
            areaSeries1.Points2.Add(new DataPoint(5, 80));
            areaSeries1.Points2.Add(new DataPoint(20, 70));
            plotModel1.Series.Add(areaSeries1);
            return plotModel1;
        }

        private PlotModel CreateBarChart(bool stacked, string title)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Series 1", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s1.Items.Add(new BarItem { Value = 25 });
            s1.Items.Add(new BarItem { Value = 137 });
            s1.Items.Add(new BarItem { Value = 18 });
            s1.Items.Add(new BarItem { Value = 40 });

            var s2 = new BarSeries { Title = "Series 2", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s2.Items.Add(new BarItem { Value = 12 });
            s2.Items.Add(new BarItem { Value = 14 });
            s2.Items.Add(new BarItem { Value = 120 });
            s2.Items.Add(new BarItem { Value = 26 });

            var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };
            categoryAxis.Labels.Add("Category A");
            categoryAxis.Labels.Add("Category B");
            categoryAxis.Labels.Add("Category C");
            categoryAxis.Labels.Add("Category D");
            var valueAxis = new LinearAxis { Position = ValueAxisPosition(), MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private AxisPosition CategoryAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Bottom;
            }

            return AxisPosition.Left;
        }

        private AxisPosition ValueAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Left;
            }

            return AxisPosition.Bottom;
        }

    }
}
