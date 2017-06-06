using PsiTransportDataExport.Model;
using System;
using System.Collections.Generic;

namespace PsiTransportDataExport.Design
{
    public class DesignNsiClassesDataServiсe : INsiClassesDataServiсe
    {
        public void FilterClassList(string filter, Action<IEnumerable<NsiClass>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetClassList(Action<IEnumerable<NsiClass>, Exception> callback)
        {
            var list = new List<NsiClass>
            {
                new NsiClass { Id = "1", Name = "111", ShortName="11" },
                new NsiClass { Id = "2", Name = "222", ShortName="22" },
                new NsiClass { Id = "3", Name = "333", ShortName="33" },
                new NsiClass { Id = "4", Name = "444", ShortName="44" },
                new NsiClass { Id = "5", Name = "555", ShortName="55" },
            };

            callback(list, null);
        }
    }
}
