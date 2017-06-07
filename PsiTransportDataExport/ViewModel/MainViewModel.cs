using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PsiTransportDataExport.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PsiTransportDataExport.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INsiClassesDataServiсe _nsiClassesDataService;

        private RelayCommand _markAllNsiClassesCommand;
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

        public RelayCommand MarkAllNsiClassesCommand
        {
            get
            {
                return _markAllNsiClassesCommand
                    ?? (_markAllNsiClassesCommand = new RelayCommand(
                    () =>
                    {
                        MarkNsiClassesCommand.Execute(SourceClassList);
                    }));
            }
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
                        if (p != null)
                        {
                            MarkedClassList = new ObservableCollection<NsiClass>(
                                MarkedClassList.Union(p.Cast<NsiClass>(), new ByIdNsiClassEqualityComparer()));
                        }
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

    /// <summary>
    /// Сравнивает объекты по идентификатору.
    /// </summary>
    internal class ByIdNsiClassEqualityComparer : IEqualityComparer<NsiClass>
    {
        public bool Equals(NsiClass x, NsiClass y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x.Id == y.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(NsiClass obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else if (obj.Id == null)
            {
                return 0;
            }
            else
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
