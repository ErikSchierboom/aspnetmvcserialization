namespace AspNetMvcSerialization.Website.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class CollectionController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Index(CollectionModel model)
        {
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Hidden()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Hidden(CollectionModel model)
        {
            return this.View(model);
        }

        private static CollectionModel CreateModel()
        {
            return new CollectionModel
            {
                Collection = new []
                {
                    "Steven Spielberg",
                    "Christopher Nolan",
                    "David Fincher",
                }
            };
        }
    }
}