using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ActionAtaDistance1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ActionAtaDistance1.Common;
using Microsoft.EntityFrameworkCore;

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
                // TODO: in order to illustrate a global dependence upon Action at a Distance, might want to create a static class, with a AuthorModel in it
                //using (var ctx = new AuthorsModel(new DbContextOptions<AuthorsModel>()))
                //{
                //    MysteryBooks = ctx.MysteryBooks.Include("Author").Include("MysteryGenre").OrderBy(m => m.BookTitle).ToList();
                //}

                App.MainDataContext.Database.EnsureCreated();   //this makes sure that the Seed() method in AuthorsModel is run, if it hasn't been already.

                //This is using the global MainDataContext - i.e.: Action at a Distance anti-pattern
                MysteryBooks = App.MainDataContext.MysteryBooks.OrderBy(m => m.BookTitle).ToList();
            }
            catch (Exception ex)
            {
                var errMessage = ErrorMessage.ReturnErrorMessage(ex, "");
                ErrorTextBlock = errMessage;
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
            //TODO: Commenting out this code for now, may remove this routine entirely.

            //var changedEntities = App.MainDataContext.ChangeTracker.Entries()
            //    .Where(x => x.State != EntityState.Unchanged).ToList();

            //foreach (var entry in changedEntities.Where(x => x.State == EntityState.Modified))
            //{
            //    entry.CurrentValues.SetValues(entry.OriginalValues);
            //    entry.State = EntityState.Unchanged;
            //}

            //foreach (var entry in changedEntities.Where(x => x.State == EntityState.Added))
            //{
            //    entry.State = EntityState.Detached;
            //}

            //foreach (var entry in changedEntities.Where(x => x.State == EntityState.Deleted))
            //{
            //    entry.State = EntityState.Unchanged;
            //}
        }
    }
}
