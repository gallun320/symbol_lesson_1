using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rest_api_lesson_1.Controllers
{
    public class MvcController : Controller
    {
        private List<int> _nums = new List<int>();

        // GET: /Mvc/
        public string Index()
        {
            return "Hello, World!";
        }

        // GET: /Mvc/Get/num?
        public string Get(int? num)
        {
            if (num == null)
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

        // POST: /Mvc/Post/num
        public string Post(int num)
        {
            _nums.Add(num);
            return "Сохранил номер";
        }

        public string PostStr(string str)
        {
            return "Correct string";
        }
    }
}