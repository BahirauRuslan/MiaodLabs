using SolidWorks.Interop.sldworks;

namespace Lab5DrawLab1
{
    public static class Lab1Drawing
    {
        private static readonly double StartPointX = 0.056;
        private static readonly double StartPointY = 0.134;

        public static void Draw(SolidWorksClient client)
        {
            var extStartLine =
            client.SwSketchManager.CreateLine(
                StartPointX, StartPointY, 0, StartPointX, StartPointY + 0.015, 0);
            var bottomLine =
            client.SwSketchManager.CreateLine(
                StartPointX, StartPointY, 0, StartPointX + 0.015, StartPointY, 0);
            var innerStartLine =
            client.SwSketchManager.CreateLine(
                StartPointX + 0.015, StartPointY, 0, StartPointX + 0.015, StartPointY + 0.015, 0);

            var innerEndLine =
            client.SwSketchManager.CreateLine(
                StartPointX + 0.095, StartPointY, 0, StartPointX + 0.095, StartPointY + 0.015, 0);
            innerEndLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.085, StartPointY + 0.0075, 0);
            innerEndLine.DeSelect();

            client.SwSketchManager.CreateLine(
                StartPointX + 0.095, StartPointY, 0, StartPointX + 0.110, StartPointY, 0);

            var extEndLine =
            client.SwSketchManager.CreateLine(
                StartPointX + 0.110, StartPointY, 0, StartPointX + 0.110, StartPointY + 0.015, 0);

            extStartLine.Select(true);
            extEndLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.055, StartPointY - 0.030, 0);
            extStartLine.DeSelect();
            extEndLine.DeSelect();

            innerStartLine.Select(true);
            innerEndLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.055, StartPointY - 0.020, 0);
            innerStartLine.DeSelect();
            innerEndLine.DeSelect();

            var mainCenterLine =
            client.SwSketchManager.CreateCenterLine(
                StartPointX + 0.055, StartPointY - 0.005, 0, StartPointX + 0.055, StartPointY + 0.060, 0);
            client.SwSketchManager.CreateCenterLine(
                StartPointX - 0.005, StartPointY + 0.015, 0, StartPointX + 0.115, StartPointY + 0.015, 0);

            var topLine =
            client.SwSketchManager.CreateLine(
                StartPointX + 0.020, StartPointY + 0.100, 0, StartPointX + 0.070, StartPointY + 0.100, 0);
            topLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.045, StartPointY + 0.120, 0);
            topLine.DeSelect();

            bottomLine.Select(true);
            topLine.Select(true);
            client.SwModel.AddDimension2(StartPointX - 0.010, StartPointY + 0.050, 0);
            bottomLine.DeSelect();
            topLine.DeSelect();

            client.SwSketchManager.CreateCenterLine(
                StartPointX + 0.040, StartPointY + 0.065, 0, StartPointX + 0.040, StartPointY + 0.095, 0);
            client.SwSketchManager.CreateCenterLine(
                StartPointX + 0.025, StartPointY + 0.080, 0, StartPointX + 0.055, StartPointY + 0.080, 0);

            var softLine =
            client.SwSketchManager.CreateLine(
                StartPointX + 0.070, StartPointY + 0.100, 0, StartPointX + 0.10283344275, StartPointY + 0.04214703951, 0);

            var circle =
            client.SwSketchManager.CreateCircleByRadius(
                StartPointX + 0.040, StartPointY + 0.080, 0, 0.010) as SketchSegment;
            circle.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.007, StartPointY + 0.065, 0);
            circle.DeSelect();

            circle.Select(true);
            topLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.095, StartPointY + 0.090, 0);
            circle.DeSelect();
            topLine.DeSelect();

            client.SwSketchManager.CreateArc(
                StartPointX + 0.055,
                StartPointY + 0.015,
                0,
                StartPointX,
                StartPointY + 0.015,
                0,
                StartPointX + 0.020,
                StartPointY + 0.05742640687,
                0,
                -1);

            var verticalTopLine =
            client.SwSketchManager.CreateLine(
                StartPointX + 0.020, StartPointY + 0.05742640687, 0, StartPointX + 0.020, StartPointY + 0.100, 0);

            mainCenterLine.Select(true);
            verticalTopLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.037, StartPointY - 0.010, 0);
            mainCenterLine.DeSelect();
            verticalTopLine.DeSelect();

            circle.Select(true);
            verticalTopLine.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.030, StartPointY + 0.110, 0);
            circle.DeSelect();
            verticalTopLine.DeSelect();

            var extArc =
            client.SwSketchManager.CreateArc(
                StartPointX + 0.055,
                StartPointY + 0.015,
                0,
                StartPointX + 0.110,
                StartPointY + 0.015,
                0,
                StartPointX + 0.10283344275,
                StartPointY + 0.04214703951,
                0,
                1);
            extArc.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.075, StartPointY + 0.025, 0);
            extArc.DeSelect();

            softLine.Select(true);
            extArc.Select(true);
            client.SwModel.SketchAddConstraints("sgTANGENT");
            softLine.DeSelect();
            extArc.DeSelect();

            var innerArc =
            client.SwSketchManager.CreateArc(
                StartPointX + 0.055,
                StartPointY + 0.015,
                0,
                StartPointX + 0.095,
                StartPointY + 0.015,
                0,
                StartPointX + 0.015,
                StartPointY + 0.015,
                0,
                1);
            innerArc.Select(true);
            client.SwModel.AddDimension2(StartPointX + 0.030, StartPointY + 0.028, 0);
            innerArc.DeSelect();
        }
    }
}
