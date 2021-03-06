﻿namespace AspNetMvcSerialization.Website.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    public class DictionaryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Index(DictionaryModel model)
        {
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Hidden()
        {
            return this.View(CreateModel());
        }

        [HttpPost]
        public ActionResult Hidden(DictionaryModel model)
        {
            return this.View(model);
        }

        private static DictionaryModel CreateModel()
        {
            return new DictionaryModel
                       {
                           Dictionary = new Dictionary<string, string>
                                            {
                                                { "Id", "1" },
                                                { "Title", "Se7en" },
                                                { "Director", "David Fincher" },
                                            }
                       };
        }
    }
}