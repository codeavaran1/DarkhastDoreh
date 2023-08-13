using Microsoft.AspNetCore.Mvc;

namespace Request_Course.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<object> charting()
        {
            List<object> data = new List<object>();
            List<string> labels = new List<string>();
            labels.Add("Nooveber");
            labels.Add("desumber");
            labels.Add("juli");
            labels.Add("april");

            List<int> total = new List<int>();
            total.Add(30);
            total.Add(12);
            total.Add(21);
            total.Add(16);

            data.Add(labels);
            data.Add(total);
            return data;


        }




    }
}
