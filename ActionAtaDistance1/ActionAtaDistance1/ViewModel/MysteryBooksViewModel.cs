using GalaSoft.MvvmLight;
using ActionAtaDistance1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAtaDistance1.ViewModel
{
    public class MysteryBooksViewModel : ViewModelBase
    {
        public List<MysteryBook> MysteryBooks { get; set; }

        private MysteryBook selectedMysteryBook;
        public MysteryBook SelectedMysteryBook 
        { 
            get { return selectedMysteryBook; }
            set
            {
                if (selectedMysteryBook != value)
                {
                    selectedMysteryBook = value;
                    RaisePropertyChanged();
                }
            }
        }

        public MysteryBooksViewModel()
        {
            using (var ctx = new AuthorsModel())
            {
                MysteryBooks = ctx.MysteryBooks.Include("Author").Include("MysteryGenre").OrderBy(m => m.BookTitle).ToList();
            }
        }
    }
}
