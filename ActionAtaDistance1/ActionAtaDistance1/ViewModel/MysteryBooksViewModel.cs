using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ActionAtaDistance1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ActionAtaDistance1.ViewModel
{
    public class MysteryBooksViewModel : ViewModelBase
    {
        public List<MysteryBook> MysteryBooks { get; set; }

        public ICommand SaveCommand { get; private set; }

        private int previousID;

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

            previousID = 0;

            SaveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand()
        {
            if (! SelectedMysteryBook.PublishDate.HasValue)
            {
                return;
            }

            //retrieve relevant data
            int selectedMysteryBookID = SelectedMysteryBook.ID;
            DateTime newPublishDate = SelectedMysteryBook.PublishDate.Value;

            using (var ctx = new AuthorsModel())
            {
                var rec = ctx.MysteryBooks.Where(mb => mb.ID == selectedMysteryBookID).FirstOrDefault();
                if (rec != null)
                {
                    rec.PublishDate = newPublishDate;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
