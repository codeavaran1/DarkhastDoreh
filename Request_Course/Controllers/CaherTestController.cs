
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace Request_Course.Controllers
{
    public class CaherTestController : Controller
    {
		// GET: Home
		public IActionResult Index()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("USA", 121));
			dataPoints.Add(new DataPoint("Great Britain", 67));
			dataPoints.Add(new DataPoint("China", 70));
			dataPoints.Add(new DataPoint("Russia", 56));
			dataPoints.Add(new DataPoint("Germany", 42));
			dataPoints.Add(new DataPoint("Japan", 41));
			dataPoints.Add(new DataPoint("France", 42));
			dataPoints.Add(new DataPoint("South Korea", 21));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}
		[DataContract]
		public class DataPoint
		{
			public DataPoint(string label, double y)
			{
				this.Label = label;
				this.Y = y;
			}

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "label")]
			public string Label = "";

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "y")]
			public Nullable<double> Y = null;
		}



		public ActionResult Index2()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("Fruit", 26));
			dataPoints.Add(new DataPoint("Protein", 20));
			dataPoints.Add(new DataPoint("Vegetables", 5));
			dataPoints.Add(new DataPoint("Dairy", 3));
			dataPoints.Add(new DataPoint("Grains", 7));
			dataPoints.Add(new DataPoint("Others", 17));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

		[DataContract]
		public class DataPoint1
		{
			public DataPoint1(string name, double y)
			{
				this.Name = name;
				this.Y = y;
			}

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "name")]
			public string Name = "";

			//Explicitly setting the name to be used while serializing to JSON.
			[DataMember(Name = "y")]
			public Nullable<double> Y = null;
		}
	}
}
