using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ActionAtaDistance1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ActionAtaDistance1.Common;

namespace ActionAtaDistance1.ViewModel
{
    public class MysteryBooksViewModel : ViewModelBase
    {
        public List<MysteryBook> MysteryBooks { get; set; }

        public ICommand SaveCommand { get; private set; }

        //private int previousID;

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

        private string errorTextBlock;
        public String ErrorTextBlock
        {
            get { return errorTextBlock; }
            set
            {
                if (errorTextBlock != value)
                {
                    errorTextBlock = value;
                    RaisePropertyChanged();
                }
            }
        }

        public MysteryBooksViewModel()
        {
            try
            {
                using (var ctx = new AuthorsModel())
                {
                    MysteryBooks = ctx.MysteryBooks.Include("Author").Include("MysteryGenre").OrderBy(m => m.BookTitle).ToList();
                }
            }
            catch (Exception ex)
            {
                var errMessage = ErrorMessage.ReturnErrorMessage(ex, "");
                ErrorTextBlock = errMessage;
            }

            //previousID = 0;

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
