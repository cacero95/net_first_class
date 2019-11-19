using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using first_lesson.Models;
using first_lesson.ViewModels;

namespace first_lesson.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movies() { Name = "Sherk" };
            var customer = new List<Customer>
            {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = customer,
                Movie = movie
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        public ActionResult Index(int? page, string sortBy)
        {
            if (!page.HasValue)
            {
                page = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("page={0}&sortBy={1}", page, sortBy));
        }
        // gracias al regex aun cuando se haga un request con 02 en el front va salir 2
        // en otras palabras va evitar problemas de logica, mientras que el range
        // solo va admitir meses del 1-12
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}