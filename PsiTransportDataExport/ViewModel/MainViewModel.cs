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

        private ObservableCollection<NsiClass> _classList;
        private ObservableCollection<NsiClass> _selectedClassList;

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

                    ClassList = new ObservableCollection<NsiClass>(item);
                });
            _selectedClassList = new ObservableCollection<NsiClass>();
        }

        /// <summary>
        /// Sets and gets the ClassList property. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        public ObservableCollection<NsiClass> ClassList
        {
            get
            {
                return _classList;
            }
            set
            {
                Set(nameof(ClassList), ref _classList, value);
            }
        }

        /// <summary>
        /// Sets and gets the ClassList property. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        public ObservableCollection<NsiClass> SelectedClassList
        {
            get
            {
                return _selectedClassList;
            }
            set
            {
                Set(nameof(SelectedClassList), ref _selectedClassList, value);
            }
        }
    }
}
