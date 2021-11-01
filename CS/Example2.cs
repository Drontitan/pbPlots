using static pbPlots;
using static SupportLib;

public class Example2{

	public static void Main2(){
	    boolean success;
		RGBABitmapImageReference imageReference = CreateRGBABitmapImageReference();
        StringReference errorMessage = new StringReference;

		ScatterPlotSeries series = GetDefaultScatterPlotSeriesSettings();
		series.xs = new double [] {-2, -1, 0, 1, 2};
		series.ys = new double [] {2, -1, -2, -1, 2};
		series.linearInterpolation = true;
		series.lineType = "dashed".ToCharArray();
		series.lineThickness = 2d;
		series.color = GetGray(0.3);

		ScatterPlotSettings settings = GetDefaultScatterPlotSettings();
		settings.width = 600;
		settings.height = 400;
		settings.autoBoundaries = true;
		settings.autoPadding = true;
		settings.title = "x^2 - 2".ToCharArray();
		settings.xLabel = "X axis".ToCharArray();
		settings.yLabel = "Y axis".ToCharArray();
		settings.scatterPlotSeries = new ScatterPlotSeries [] {series};

		success = DrawScatterPlotFromSettings(imageReference, settings, errorMessage);

		if(success){
            double[] pngdata = ConvertToPNG(imageReference.image);
            WriteToFile(pngdata, "example2.png");
            DeleteImage(imageReference.image);
		}else{
            Console.Error(errorMessage.string);
        }
	}
}
