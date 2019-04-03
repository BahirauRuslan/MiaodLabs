using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Lab5DrawLab1
{
    public static class Lab1Drawing
    {
        private static readonly double StartPointX = 0.056;
        private static readonly double StartPointY = 0.134;

        public static void Draw(SolidWorksClient client)
        {
            DrawLines(client);
            DrawCircle(client);
            DrawArcs(client);
            client.SwSketchManager.SplitOpenSegment(StartPointX, StartPointY + 0.005, 0);
        }

        private static void DrawCircle(SolidWorksClient client)
        {
            client.SwSketchManager.CreateCircleByRadius(
                StartPointX + 0.040, StartPointY + 0.080, 0, 0.010);
        }

        private static void DrawArcs(SolidWorksClient client)
        {
            client.SwSketchManager.CreateArc(
                StartPointX + 0.055, 
                StartPointY + 0.015, 
                0, 
                StartPointX + 0.110, 
                StartPointY + 0.015, 
                0, 
                StartPointX, 
                StartPointY + 0.015, 
                0, 
                1);
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
        }

        private static void DrawLines(SolidWorksClient client)
        {
            client.SwSketchManager.CreateLine(
                StartPointX, StartPointY, 0, StartPointX, StartPointY + 0.015, 0);
            client.SwSketchManager.CreateLine(
                StartPointX, StartPointY, 0, StartPointX + 0.015, StartPointY, 0);
            client.SwSketchManager.CreateLine(
                StartPointX + 0.015, StartPointY, 0, StartPointX + 0.015, StartPointY + 0.015, 0);

            client.SwSketchManager.CreateLine(
                StartPointX + 0.095, StartPointY, 0, StartPointX + 0.095, StartPointY + 0.015, 0);
            client.SwSketchManager.CreateLine(
                StartPointX + 0.095, StartPointY, 0, StartPointX + 0.110, StartPointY, 0);
            client.SwSketchManager.CreateLine(
                StartPointX + 0.110, StartPointY, 0, StartPointX + 0.110, StartPointY + 0.015, 0);

            client.SwSketchManager.CreateCenterLine(
                StartPointX + 0.055, StartPointY - 0.005, 0, StartPointX + 0.055, StartPointY + 0.060, 0);
            client.SwSketchManager.CreateCenterLine(
                StartPointX - 0.005, StartPointY + 0.015, 0, StartPointX + 0.115, StartPointY + 0.015, 0);

            client.SwSketchManager.CreateLine(
                StartPointX + 0.020, StartPointY + 0.100, 0, StartPointX + 0.070, StartPointY + 0.100, 0);

            client.SwSketchManager.CreateCenterLine(
                StartPointX + 0.040, StartPointY + 0.065, 0, StartPointX + 0.040, StartPointY + 0.095, 0);
            client.SwSketchManager.CreateCenterLine(
                StartPointX + 0.025, StartPointY + 0.080, 0, StartPointX + 0.055, StartPointY + 0.080, 0);
        }
    }
}
