using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class TypesViewComponent: ViewComponent
    {
        private IBookstore repo { get; set; }
        public TypesViewComponent (IBookstore temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData.Values["bookCategory"];
            
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
