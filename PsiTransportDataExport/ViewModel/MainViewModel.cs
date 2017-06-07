using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PsiTransportDataExport.Model;
using PsiTransportDataExport.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PsiTransportDataExport.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly INsiClassesDataServiсe _nsiClassesDataService;

        private RelayCommand _markAllNsiClassesCommand;
        private ObservableCollection<NsiClass> _markedClassList;
        private RelayCommand<IEnumerable<object>> _markNsiClassesCommand;
        private ObservableCollection<NsiClass> _sourceClassList;

        private RelayCommand _unmarkAllClassCommand;
        private RelayCommand<IEnumerable<object>> _unmarkClassCommand;

        public MainViewModel(INsiClassesDataServiсe nsiClassesDataService, IDialogService dialogService)
        {
            _nsiClassesDataService = nsiClassesDataService;
            _dialogService = dialogService;

            _nsiClassesDataService.GetClassList(
                (item, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowError(error.Message, "Загрузка списка классов НСИ");
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

        public RelayCommand UnmarkAllClassCommand
        {
            get
            {
                return _unmarkAllClassCommand
                    ?? (_unmarkAllClassCommand = new RelayCommand(
                    () =>
                    {
                        MarkedClassList.Clear();
                    }));
            }
        }

        public RelayCommand<IEnumerable<object>> UnmarkClassCommand
        {
            get
            {
                return _unmarkClassCommand
                    ?? (_unmarkClassCommand = new RelayCommand<IEnumerable<object>>(
                    p =>
                    {
                        if (p != null)
                        {
                            MarkedClassList = new ObservableCollection<NsiClass>(
                                MarkedClassList.Except(p.Cast<NsiClass>(), new ByIdNsiClassEqualityComparer()));
                        }
                    }));
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
