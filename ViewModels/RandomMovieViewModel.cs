using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using first_lesson.Models;

namespace first_lesson.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}