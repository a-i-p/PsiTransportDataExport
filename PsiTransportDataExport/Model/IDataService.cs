﻿using System;

namespace PsiTransportDataExport.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
