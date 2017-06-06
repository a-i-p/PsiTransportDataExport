using GalaSoft.MvvmLight;

namespace PsiTransportDataExport.Model
{
    public class NsiClass : ObservableObject
    {
        private string _name;
        private string _shortName;

        public string Id { get; set; }

        /// <summary>
        /// Sets and gets the Name property. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(nameof(Name), ref _name, value);
            }
        }

        /// <summary>
        /// Sets and gets the ShortName property. Changes to that property's value raise the
        /// PropertyChanged event.
        /// </summary>
        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                Set(nameof(ShortName), ref _shortName, value);
            }
        }
    }
}
