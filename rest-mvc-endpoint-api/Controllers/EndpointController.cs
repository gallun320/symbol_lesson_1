using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace rest_mvc_endpoint_api.Controllers
{
    public class EndpointController : Controller
    {
        private List<int> _nums = new List<int>();

        // GET: /Endpoint/
        public string Index()
        {
            return "Hello, World!";
        }

        // GET: /Endpoint/Get/num?
        public string Get(int? num)
        {
            if(num == null)
            {
                return "Пустой номер: ошибка";
            }
            else
            {
                var numRes = _nums.IndexOf(num.Value);
                if (numRes == -1)
                {
                    return "Неверный номер";
                }
                else
                {
                    return $"То что вы ищите действительно под номером {numRes}";
                }
            }
        }

        // POST: /Endpoint/Post/num
        public string Post(int num)
        {
            _nums.Add(num);
            return "Сохранил номер";
        }
    }
}
