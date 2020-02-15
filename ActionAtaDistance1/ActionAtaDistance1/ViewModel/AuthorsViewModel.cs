using GalaSoft.MvvmLight;
using ActionAtaDistance1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAtaDistance1.ViewModel
{
    public class AuthorsViewModel : ViewModelBase
    {
        public List<Author> Authors { get; set; }

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
        }
    }
}
