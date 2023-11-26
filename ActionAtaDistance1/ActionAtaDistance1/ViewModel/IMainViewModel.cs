using System.Windows.Input;

namespace ActionAtaDistance1.ViewModel
{
    public interface IMainViewModel
    {
        ICommand ViewAuthorsCommand { get; }
        ICommand ViewMysteryBooksCommand { get; }
    }
}