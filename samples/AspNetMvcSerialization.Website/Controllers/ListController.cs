namespace AspNetMvcSerialization.Website.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    public class ListController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Index(ListModel model)
        {
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Hidden()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Hidden(ListModel model)
        {
            return this.View(model);
        }

        private static ListModel CreateModel()
        {
            return new ListModel
            {
                List = new List<string>
                {
                    "Steven Spielberg",
                    "Christopher Nolan",
                    "David Fincher",
                }
            };
        }
    }
}