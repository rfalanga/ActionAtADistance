using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ActionAtaDistance1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System;

namespace ActionAtaDistance1.ViewModel
{
    public class AuthorsViewModel : ViewModelBase
    {
        public List<Author> Authors { get; set; }

        public ICommand SaveCommand { get; private set; }

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
                    RaisePropertyChanged();
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
                    RaisePropertyChanged();
                }
            }
        }

        public AuthorsViewModel()
        {
            using (var ctx = new AuthorsModel())
            {
                Authors = ctx.Authors.OrderBy(a => a.LastName).ToList();
            }

            previousID = 0;

            //SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
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
            throw new NotImplementedException();
        }
    }
}
