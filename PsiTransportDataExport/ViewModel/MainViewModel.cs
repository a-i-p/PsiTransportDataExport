using GalaSoft.MvvmLight;
using PsiTransportDataExport.Model;
using System.Collections.ObjectModel;

namespace PsiTransportDataExport.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>See http://www.mvvmlight.net</para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INsiClassesDataServiсe _nsiClassesDataService;

        private ObservableCollection<NsiClass> _markedClassList;
        private ObservableCollection<NsiClass> _sourceClassList;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INsiClassesDataServiсe nsiClassesDataService)
        {
            _nsiClassesDataService = nsiClassesDataService;
            _nsiClassesDataService.GetClassList(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    SourceClassList = new ObservableCollection<NsiClass>(item);
                });
            _markedClassList = new ObservableCollection<NsiClass>();
        }

        /// <summary>
        /// Sets and gets the ClassList property. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
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

        /// <summary>
        /// Sets and gets the ClassList property. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
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
