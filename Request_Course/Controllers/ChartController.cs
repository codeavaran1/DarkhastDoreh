using Microsoft.AspNetCore.Mvc;
using Request_Course.Serivces.Interface;

namespace Request_Course.Controllers
{
    public class ChartController : Controller
    {
        private readonly IRepository _services;

        public ChartController(IRepository irepository)
        {
            this._services = irepository;
        }

        public IActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public async  Task<List<object>> charting()
        {
            List<object> data = new List<object>();
            List<string> labels = new List<string>();
            var Result = await _services.GetDorehByMonthForChart();
            foreach (var item in Result.Item1)
            {
                labels.Add(item.ToString()+"ماه ");
            }            
            //labels.Add("Nooveber");
            //labels.Add("desumber");
            //labels.Add("juli");
            //labels.Add("april");
            List<int> total = new List<int>();
            foreach (var item in Result.Item2)
            {
                total.Add(item);
            }
            //total.Add(30);
            //total.Add(12);
            //total.Add(21);
            //total.Add(16);
            data.Add(labels);
            data.Add(total);
            return data;

        }


        [HttpPost]
        public async Task<List<object>> UserChart()
        {
            List<object> data = new List<object>();
            List<string> labels = new List<string>();
            var Result = await _services.GetUserByMonthForChart();
            foreach (var item in Result.Item1)
            {
                labels.Add(item.ToString() + "ماه ");
            }
            List<int> total = new List<int>();
            foreach (var item in Result.Item2)
            {
                if (item==null)
                {
                    total.Add(0);
                }
                else
                {
                    total.Add(item);
                }
            }
            data.Add(labels);
            data.Add(total);
            return data;
        }




    }
}
