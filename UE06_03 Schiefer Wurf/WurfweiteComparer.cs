using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE06_03_Schiefer_Wurf
{
    class WurfweiteComparer : IComparer<SchieferWurf>
    {
        public int Compare(SchieferWurf x, SchieferWurf y)
        {
            return x.BerechneWurfweite().CompareTo(y.BerechneWurfweite());
        }
    }
}
