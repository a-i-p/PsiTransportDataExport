using System;
using System.Collections.Generic;

namespace PsiTransportDataExport.Model
{
    public interface INsiClassesDataServise
    {
        void FilterClassList(string filter, Action<IEnumerable<NsiClass>, Exception> callback);

        void GetClassList(Action<IEnumerable<NsiClass>, Exception> callback);
    }
}
