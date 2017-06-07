using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PsiTransportDataExport.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PsiTransportDataExport.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INsiClassesDataServiсe _nsiClassesDataService;

        private ObservableCollection<NsiClass> _markedClassList;
        private RelayCommand<IEnumerable<object>> _markNsiClassesCommand;
        private ObservableCollection<NsiClass> _sourceClassList;

        public MainViewModel(INsiClassesDataServiсe nsiClassesDataService)
        {
            _nsiClassesDataService = nsiClassesDataService;
            _nsiClassesDataService.GetClassList(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // DOTO: Report error here
                        return;
                    }

                    SourceClassList = new ObservableCollection<NsiClass>(item);
                });
            _markedClassList = new ObservableCollection<NsiClass>();
        }

        public ObservableCollection<NsiClass> MarkedClassList
        {
            get
            {
                return _markedClassList;
            }
            set
            {
                Set(nameof(MarkedClassList), ref _markedClassList, value);
            }
        }

        public RelayCommand<IEnumerable<object>> MarkNsiClassesCommand
        {
            get
            {
                return _markNsiClassesCommand
                    ?? (_markNsiClassesCommand = new RelayCommand<IEnumerable<object>>(
                    p =>
                    {
                    }));
            }
        }

        public ObservableCollection<NsiClass> SourceClassList
        {
            get
            {
                return _sourceClassList;
            }
            set
            {
                Set(nameof(SourceClassList), ref _sourceClassList, value);
            }
        }
    }
}
