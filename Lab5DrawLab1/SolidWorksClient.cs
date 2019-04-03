using System;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Lab5DrawLab1
{
    public sealed class SolidWorksClient
    {
        private static readonly Lazy<SolidWorksClient> LAZY = new Lazy<SolidWorksClient>(() => new SolidWorksClient());

        private SolidWorksClient()
        {
            SetSwApp();
            ActiveDocValidate();
            SwModel = (ModelDoc2)SwApp.ActiveDoc;
            SwSketchManager = SwModel.SketchManager;
            SwSelMgr = (SelectionMgr)SwModel.SelectionManager;
            DocTypeValidate();
        }

        public SldWorks SwApp { get; private set; }

        public ModelDoc2 SwModel { get; private set; }

        public SketchManager SwSketchManager { get; private set; }

        public SelectionMgr SwSelMgr { get; private set; }

        public static SolidWorksClient GetInstance()
        {
            return LAZY.Value;
        }

        private void SetSwApp()
        {
            try
            {
                SwApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            }
            catch (COMException e)
            {
                throw new SolidWorksNotRunningException("Не удалось найти запущенный Solidworks!", e);
            }
        }

        private void ActiveDocValidate()
        {
            if (SwApp.ActiveDoc == null)
            {
                throw new SolidWorksDocumentNotOpenException("Надо открыть документ перед использованием");
            }
        }

        private void DocTypeValidate()
        {
            if (SwModel.GetType() != (int)swDocumentTypes_e.swDocDRAWING)
            {
                throw new SolidWorksInappropriateDocumentTypeException("Открытый документ должен быть типа чертёж");
            }
        }
    }
}
