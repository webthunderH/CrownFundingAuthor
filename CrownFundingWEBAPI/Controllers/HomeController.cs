using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrownFundingWEBAPI.Controllers
{
    public class HomeController : ApiController
    {
        public ActionResult Index()
        {
            return View();
        }

	}
}
