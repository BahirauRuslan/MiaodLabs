using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using Lab5DrawLab1;

namespace Lab5DrawLab3
{
    public static class Lab3Drawing
    {
        public static void Draw(SolidWorksClient client)
        {
            var prefToggle = (int)swUserPreferenceToggle_e.swInputDimValOnCreate;
            client.SwApp.SetUserPreferenceToggle(prefToggle, false);
            var paral1 = DrawMainBox(client, 0.158, 0.078, 0.036);
            var paral2 = DrawMainBox(client, 0.076, 0.078, 0.052);
            var paral3 = DrawMainBox(client, 0.054, 0.078, 0.078);
            DrawBoxCut(client, paral2);
            DrawFrontBoxCut(client, paral1);
            var paral4 = DrawCircleCut(client, paral1);
            Reflect(client, paral4);
        }

        private static Feature DrawMainBox(SolidWorksClient client, double sizeX, double sizeY, double depth)
        {
            var x = 0;
            var y = 0;
            var z = 0;

            client.SwModel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0); 
            client.SwSketchManager.InsertSketch(true);

            var rectBig = client.SwSketchManager.CreateCenterRectangle(0, 0, 0, sizeX / 2, sizeY / 2, 0);
            client.SwModel.ClearSelection2(true);

            var el = rectBig[0] as SketchSegment;
            el.Select(true);
            client.SwModel.AddDimension2(x, y, -sizeY / 2 - 0.010);
            el.DeSelect();

            el = rectBig[1] as SketchSegment;
            el.Select(true);
            client.SwModel.AddDimension2(-sizeX / 2 - 0.010, y, z);
            el.DeSelect();

            var paral1 = client.SwFM.FeatureExtrusion2(true, false, false, 0, 0, depth, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            client.SwSketchManager.InsertSketch(true); 
            client.SwModel.ClearSelection2(true);

            return paral1;
        }

        private static void DrawBoxCut(SolidWorksClient client, Feature paral)
        {
            var sizeX = 0.054;
            var sizeY = 0.018;
            var depth = 0.076;

            var facesPar1 = paral.GetFaces();
            var ent = facesPar1[2] as Entity;
            ent.Select(true);
            client.SwSketchManager.InsertSketch(true);

            var quad = client.SwSketchManager.CreateCenterRectangle(0, 0.054, 0, sizeX / 2, (sizeY / 2 + 0.054), 0);
            client.SwModel.ClearSelection2(true);

            var el = quad[0] as SketchSegment;
            el.Select(true);
            client.SwModel.AddDimension2(0, (-sizeY / 2 + 0.054 - 0.010), 0);
            el.DeSelect();

            el = quad[1] as SketchSegment;
            el.Select(true);
            client.SwModel.AddDimension2(0, 0.054, (-sizeX / 2 - 0.010));
            el.DeSelect();

            var mode = swEndConditions_e.swEndCondBlind;
            var paral4 = client.SwFM.FeatureCut2(true, false, false, (int)mode, (int)mode,
               depth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
               false, false, false, false, false);
            client.SwSketchManager.InsertSketch(true);
            client.SwModel.ClearSelection2(true);
        }

        private static void DrawFrontBoxCut(SolidWorksClient client, Feature paral)
        {
            var sizeX = 0.025;
            var sizeY = 0.018;
            var depth = 0.078;

            var facesPar1 = paral.GetFaces();
            var ent = facesPar1[3] as Entity;
            ent.Select(true);
            client.SwSketchManager.InsertSketch(true);

            var quad = client.SwSketchManager.CreateCenterRectangle(0, sizeY / 2, 0, sizeX / 2, (sizeY / 2 + 0.009), 0);
            client.SwModel.ClearSelection2(true);

            var el = quad[0] as SketchSegment;
            el.Select(true);
            client.SwModel.AddDimension2(-sizeX / 2 - 0.010, sizeY / 2, 0);
            el.DeSelect();

            el = quad[1] as SketchSegment;
            el.Select(true);
            client.SwModel.AddDimension2(sizeX / 2, -sizeY / 2 - 0.010, 0);
            el.DeSelect();

            var mode = swEndConditions_e.swEndCondBlind;
            var paral4 = client.SwFM.FeatureCut2(true, false, false, (int)mode, (int)mode,
               depth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
               false, false, false, false, false);
            client.SwSketchManager.InsertSketch(true);
            client.SwModel.ClearSelection2(true);
        }

        private static Feature DrawCircleCut(SolidWorksClient client, Feature paral)
        {
            var radius = 0.015;
            var depth = 0.078;

            var facesPar1 = paral.GetFaces();
            var ent = facesPar1[0] as Entity;
            ent.Select(true);
            client.SwSketchManager.InsertSketch(true);

            var circle = client.SwSketchManager.CreateCircleByRadius(-0.079, 0, 0, radius);
            client.SwModel.AddRadialDimension(0, 0.15, 0.05);
            client.SwModel.ClearSelection2(true);

            var mode = swEndConditions_e.swEndCondBlind;
            var paral4 = client.SwFM.FeatureCut2(true, false, false, (int)mode, (int)mode,
               depth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
               false, false, false, false, false);
            client.SwSketchManager.InsertSketch(true);
            client.SwModel.ClearSelection2(true);

            return paral4;
        }

        private static void Reflect(SolidWorksClient client, Feature paral)
        {
            client.SwModel.Extension.SelectByID2("Справа", "PLANE", 0, 0, 0, false, 0, null, 0);
            var res = paral.SelectByMark(true, 1);
            client.SwFM.InsertMirrorFeature(false, false, false, false);
            client.SwSketchManager.InsertSketch(true);
            client.SwModel.ClearSelection();
        }
    }
}
