using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ActionAtaDistance1.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ActionAtaDistance1.ViewModel
{
    public class MysteryBooksViewModel : ViewModelBase
    {
        public List<MysteryBook> MysteryBooks { get; set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

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

        public MysteryBooksViewModel()
        {
            using (var ctx = new AuthorsModel())
            {
                MysteryBooks = ctx.MysteryBooks.Include("Author").Include("MysteryGenre").OrderBy(m => m.BookTitle).ToList();
            }

            //previousID = 0;

            SaveCommand = new RelayCommand(ExecuteSaveCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
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

            var rec = App.MainDataContext.MysteryBooks.Where(mb => mb.ID == selectedMysteryBookID).FirstOrDefault();
            if (rec != null)
            {
                rec.PublishDate = newPublishDate;
                App.MainDataContext.SaveChanges();
            }
        }

        private void ExecuteCancelCommand()
        {
            var changedEntities = App.MainDataContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntities.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntities.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntities.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }
    }
}
