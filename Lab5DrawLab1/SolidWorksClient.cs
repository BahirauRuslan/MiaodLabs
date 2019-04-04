using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Lab5DrawLab1
{
    public sealed class SolidWorksClient
    {
        public SolidWorksClient(swDocumentTypes_e docType)
        {
            SetSwApp();
            ActiveDocValidate();
            SwModel = (ModelDoc2)SwApp.ActiveDoc;
            SwSketchManager = SwModel.SketchManager;
            SwSelMgr = (SelectionMgr)SwModel.SelectionManager;
            SwFM = SwModel.FeatureManager;
            DocTypeValidate(docType);
        }

        public SldWorks SwApp { get; private set; }

        public ModelDoc2 SwModel { get; private set; }

        public SketchManager SwSketchManager { get; private set; }

        public SelectionMgr SwSelMgr { get; private set; }

        public FeatureManager SwFM { get; private set; }

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

        private void DocTypeValidate(swDocumentTypes_e docType)
        {
            if (SwModel.GetType() != (int)docType)
            {
                throw new SolidWorksInappropriateDocumentTypeException("Открытый документ должен иметь другой тип");
            }
        }
    }
}
