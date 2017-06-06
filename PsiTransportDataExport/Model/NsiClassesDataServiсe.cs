using System;
using System.Collections.Generic;

namespace PsiTransportDataExport.Model
{
    public class NsiClassesDataServiсe : INsiClassesDataServiсe
    {
        public void FilterClassList(string filter, Action<IEnumerable<NsiClass>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetClassList(Action<IEnumerable<NsiClass>, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}
