﻿using GalaSoft.MvvmLight;
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

        public AuthorsViewModel()
        {
            using (var ctx = new AuthorsModel())
            {
                Authors = ctx.Authors.OrderBy(a => a.LastName).ToList();
            }
        }
    }
}