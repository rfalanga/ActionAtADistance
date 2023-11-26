using ActionAtaDistance1.Model;
using System.Collections.Generic;
using System.Windows.Input;

namespace ActionAtaDistance1.ViewModel
{
    public interface IAuthorsViewModel
    {
        List<Author> Authors { get; set; }
        ICommand CancelCommand { get; }
        string ErrorTextBlock { get; set; }
        ICommand SaveCommand { get; }
        Author SelectedAuthor { get; set; }
        bool ShowDate { get; set; }
    }
}