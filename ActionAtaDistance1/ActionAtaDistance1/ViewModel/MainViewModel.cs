using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using ActionAtaDistance1.Common;

namespace ActionAtaDistance1.ViewModel
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
        public ICommand ViewAuthorsCommand { get; private set; }
        public ICommand ViewMysteryBooksCommand { get; private set; }
        internal MainDbContext mainDbContext { get; private set; }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            ViewAuthorsCommand = new RelayCommand(ExecuteViewAuthorsCommand);
            ViewMysteryBooksCommand = new RelayCommand(ExecuteViewMysteryBooksCommand);

            //TODO: Research what has to be done here to creete the global DbContext of the
            // in-memory database.
        }

        private void ExecuteViewMysteryBooksCommand()
        {
            var mystery = new View.MysteryBooks();
            mystery.Show();
        }

        private void ExecuteViewAuthorsCommand()
        {
            var author = new View.Authors();
            author.Show();
        }
    }
}