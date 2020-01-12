using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rest_mvc_endpoint_api.Controllers
{
    [Area("Area")]
    public class AreaHomeController : Controller
    {
        public string Index()
        {
            return "Hello, Area!";
        }
    }
}