using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BookList.Models;

namespace BookList.Controllers
{
    public class HomeController : Controller
    {
        private BookContext context { get; set; }

        public HomeController(BookContext ctx)
        {
            context = ctx;
        }

          public IActionResult Index()
        {

            var books = context.Books.Include(m=>m.Genre)
                .OrderBy(m => m.Name).ToList();
            return View(books);
        }

    }
}
