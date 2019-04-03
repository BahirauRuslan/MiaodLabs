using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;

namespace Lab5DrawLab1
{
    public class SolidWorksClient
    {
        public SldWorks SwApp { get; private set; }
        public ModelDoc2 SwModel { get; private set; }
        public SketchManager SwSketchManager { get; private set; }
        public SelectionMgr SwSelMgr { get; private set; }
    }
}
