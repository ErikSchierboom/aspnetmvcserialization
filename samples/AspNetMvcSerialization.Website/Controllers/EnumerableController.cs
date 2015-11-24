namespace AspNetMvcSerialization.Website.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class EnumerableController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Index(EnumerableModel model)
        {
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Hidden()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Hidden(EnumerableModel model)
        {
            return this.View(model);
        }

        private static EnumerableModel CreateModel()
        {
            return new EnumerableModel
            {
                Enumerable = new []
                {
                    "Steven Spielberg",
                    "Christopher Nolan",
                    "David Fincher",
                }
            };
        }
    }
}