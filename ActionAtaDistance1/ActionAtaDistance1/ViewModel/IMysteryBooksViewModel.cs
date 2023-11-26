using ActionAtaDistance1.Model;
using System.Collections.Generic;
using System.Windows.Input;

namespace ActionAtaDistance1.ViewModel
{
    public interface IMysteryBooksViewModel
    {
        ICommand CancelCommand { get; }
        string ErrorTextBlock { get; set; }
        List<MysteryBook> MysteryBooks { get; set; }
        ICommand SaveCommand { get; }
        MysteryBook SelectedMysteryBook { get; set; }
    }
}