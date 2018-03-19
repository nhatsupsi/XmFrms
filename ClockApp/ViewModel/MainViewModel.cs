using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace ClockApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="ClickCount" /> property's name.
        /// </summary>
        public const string ClickCountPropertyName = "ClickCount";

        private int _clickCount;

        /// <summary>
        /// Sets and gets the ClickCount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ClickCount
        {
            get
            {
                return _clickCount;
            }
            set
            {
                if (Set(() => ClickCount, ref _clickCount, value))
                {
                    RaisePropertyChanged(() => ClickCountFormatted);
                }
            }
        }

        public string ClickCountFormatted
        {
            get
            {
                return string.Format("The button was clicked {0} time(s)", ClickCount);
            }
        }

        private RelayCommand _incrementCommand;

        /// <summary>
        /// Gets the IncrementCommand.
        /// </summary>
        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        ClickCount++;
                    }));
            }
        }
    }
}