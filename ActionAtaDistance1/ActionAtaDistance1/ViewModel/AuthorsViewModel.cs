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

        private Author selectedAuthor;
        public Author SelectedAuthor 
        { 
            get { return selectedAuthor; }
            set
            {
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

            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        }

        private bool CanExecuteSaveCommand()
        {
            throw new NotImplementedException();
        }

        private void ExecuteSaveCommand()
        {
            throw new NotImplementedException();
        }
    }
}
