using CommunityToolkit.Mvvm;
using ActionAtaDistance1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System;
using ActionAtaDistance1.Common;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ActionAtaDistance1.ViewModel
{
    public class AuthorsViewModel : ObservableObject, IAuthorsViewModel
    {
        public List<Author> Authors { get; set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        private int previousID;

        private Author selectedAuthor;
        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                bool wasSelectedAuthorNull = (selectedAuthor == null);
                if (selectedAuthor != value)
                {
                    selectedAuthor = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool showDate;
        public bool ShowDate
        {
            get { return showDate; }
            set
            {
                if (showDate != value)
                {
                    showDate = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        public AuthorsViewModel()
        {
            try
            {
                App.MainDataContext.Database.EnsureCreated();   //this makes sure that the Seed() method in AuthorsModel is run, if it hasn't been already.

                //This is using the global MainDataContext - i.e.: Action at a Distance anti-pattern
                Authors = App.MainDataContext.Authors.OrderBy(a => a.LastName).ToList();
            }
            catch (Exception ex)
            {
                var errMessage = ErrorMessage.ReturnErrorMessage(ex, "");
                ErrorTextBlock = errMessage;
            }

            previousID = 0;

            SaveCommand = new AsyncRelayCommand(ExecuteSaveCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        private bool CanExecuteSaveCommand()
        {
            if (SelectedAuthor == null)
            {
                return false;
            }

            if (SelectedAuthor.ID != previousID)
            {
                //the selected author has changed
                previousID = SelectedAuthor.ID;
                return false;
            }

            if (SelectedAuthor.DateOfBirth == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteSaveCommand()
        {
            if (!SelectedAuthor.DateOfBirth.HasValue)
            {
                return;
            }

            //retrieve relevant data
            int selectedAuthorID = SelectedAuthor.ID;
            DateTime newDateOfBirth = SelectedAuthor.DateOfBirth.Value;

            var rec = App.MainDataContext.Authors.Where(a => a.ID == selectedAuthorID).FirstOrDefault();
            if (rec != null)
            {
                rec.DateOfBirth = newDateOfBirth;
                App.MainDataContext.SaveChanges();
            }

        }

        private void ExecuteCancelCommand()
        {
            //TODO: Commenting out code, for now. May remove this routine entirely.
        }
    }
}
