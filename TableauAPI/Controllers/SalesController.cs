using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TableauAPI.Controllers
{
    public class SalesController : ApiController
    {
        DataContext db = new DataContext();
        public string dummy = "[{\"Date add\":\"2013-01-01\",\"Order Date\":\"2009-01-01\",\"Region\":\"East\",\"State\":\"Pennsylvania\",\"Sales\":\"180.36\"},{\"Date add\":\"2013-01-01\",\"Order Date\":\"2009-01-01\",\"Region\":\"East\",\"State\":\"Maryland\",\"Sales\":\"872.48\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"1239.06\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"614.8\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"4083.19\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"137.63\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"Central\",\"State\":\"Minnesota\",\"Sales\":\"124.81\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"4902.38\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Alabama\",\"Sales\":\"698\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"West\",\"State\":\"Utah\",\"Sales\":\"262.76\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Alabama\",\"Sales\":\"172.51\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"West\",\"State\":\"Oregon\",\"Sales\":\"122.23\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"Central\",\"State\":\"Nebraska\",\"Sales\":\"85.56\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"West\",\"State\":\"Utah\",\"Sales\":\"896.49\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"522.49\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"Central\",\"State\":\"Nebraska\",\"Sales\":\"754.6555\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"123.76\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"28359.4\"},{\"Date add\":\"2013-01-04\",\"Order Date\":\"2009-01-04\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"1039.56\"},{\"Date add\":\"2013-01-04\",\"Order Date\":\"2009-01-04\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"63.34\"},{\"Date add\":\"2013-01-04\",\"Order Date\":\"2009-01-04\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"151.35\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"12635.75\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"2750.107\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Iowa\",\"Sales\":\"1244.19\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"240.3\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"78.08\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Oklahoma\",\"Sales\":\"8958.46\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"South\",\"State\":\"Florida\",\"Sales\":\"257.41\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"East\",\"State\":\"New York\",\"Sales\":\"188.73\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Iowa\",\"Sales\":\"165.75\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"653.54\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Oklahoma\",\"Sales\":\"4201.08\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"725.43\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Illinois\",\"Sales\":\"700.73\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Oklahoma\",\"Sales\":\"4913.7\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Iowa\",\"Sales\":\"2021.1470000000002\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"East\",\"State\":\"Connecticut\",\"Sales\":\"2357.45\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"Central\",\"State\":\"Illinois\",\"Sales\":\"26133.39\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Virginia\",\"Sales\":\"37.06\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"South Carolina\",\"Sales\":\"61.7185\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Virginia\",\"Sales\":\"46.86\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"South Carolina\",\"Sales\":\"3674.08\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Florida\",\"Sales\":\"129.84\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Florida\",\"Sales\":\"22.13\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"South Carolina\",\"Sales\":\"1413.89\"}]";
        public class SalesData
        {
            public decimal Sales { get; set; }
            public string State { get; set; }
            public string Region { get; set; }
            public int Date { get; set; }
        }


        [HttpPost]
        //[Route("api/sales/openDashboard")]
        public HttpResponseMessage OpenDashboard()
        {
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("https://tableauapi-dev.us-east-2.elasticbeanstalk.com/home/salesdashboard");
            return response;
            //var url = "https://tableauapi-dev.us-east-2.elasticbeanstalk.com/home/salesdashboard";
            //var url = this.Url.Link("Default", new { Controller = "Home", Action = "SalesDashboard" });
            //return url;

        }

        public JArray Get()
        {
            var apiData = db.SalesSkill.ToList();
            var maxId = apiData.Select(x => x.Id).Max();
            var data = apiData.Where(x => x.Id == maxId).Select(x => x.DashboardData).SingleOrDefault();
            var formattedData = JArray.Parse(data);
            return formattedData;
        }

        // GET: api/Sales
        public HttpResponseMessage Get(string page)
        {
           return OpenDashboard();
        }

        [HttpGet]
        [Route("api/sales/getSalesAmount")]
        public decimal GetSalesAmount(int year, string place, string region, string type)
        {
            decimal answer = 0;
            var data =  Get();//JArray.Parse(dummy);//
            List<SalesData> listedData = new List<SalesData>();

            foreach (JObject parsedObject in data.Children<JObject>())
            {
                JObject salesData = (JObject)parsedObject;
                var _newData = new SalesData();
                _newData.Date = Convert.ToDateTime(salesData["Order Date"]).Year;
                _newData.Region = salesData["Region"].ToString();
                _newData.State = salesData["State"].ToString();
                _newData.Sales = Convert.ToDecimal(salesData["Sales"]);
                listedData.Add(_newData);

            }

            if ((region == null || region == "null") && (place == null || place == "null") && (year == 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region == null || region == "null") && (place == null || place == "null") && (year == 0) && (type != null || type != "null"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var maxSales = listedData.GroupBy(x => x.State).Select(y => new
                    {
                        State = y.Key,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = maxSales.Max(x => x.Sales);
                    answer = Math.Round(d, 2);
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var minSales = listedData.GroupBy(x => x.State).Select(y => new
                    {
                        State = y.Key,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = minSales.Min(x => x.Sales);
                    answer = Math.Round(d, 2);
                }
                else if (type == "average")
                {
                    var totalSales = listedData.Select(x => x.Sales).Average();
                    answer = Math.Round(totalSales, 2);
                }
            }
            else if ((region == null || region == "null") && (place == null || place == "null") && (year != 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.Date == year).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region != null || region != "null") && (place == null || place == "null") && (year == 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.Region.ToLower() == region).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region == null || region == "null") && (place != null || place != "null") && (year == 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.State.ToLower() == place).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region != null || region != "null") && (place != null || place != "null") && (year == 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.Region.ToLower() == region && x.State.ToLower() == place).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region == null || region == "null") && (place != null || place != "null") && (year != 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.Date == year && x.State.ToLower() == place).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region != null || region != "null") && (place == null || place == "null") && (year != 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.Region.ToLower() == region && x.Date == year).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region != null || region != "null") && (place != null || place != "null") && (year != 0) && (type == null || type == "null"))
            {
                var totalSales = listedData.Where(x => x.Region.ToLower() == region && x.Date == year && x.State.ToLower() == place).Sum(x => x.Sales);
                answer = Math.Round(totalSales, 2);
            }
            else if ((region == null || region == "null") && (place == null || place == "null") && (year != 0) && (type != null || type != "null"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var totalSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Max();
                    answer = Math.Round(totalSales, 2);
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var totalSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Min();
                    answer = Math.Round(totalSales, 2);
                }
                else if (type == "average")
                {
                    var totalSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Average();
                    answer = Math.Round(totalSales, 2);
                }
            }
            else if ((region == null || region == "null") && (place != null || place != "null") && (year == 0) && (type != null || type != "null"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var totalSales = listedData.Where(x => x.State.ToLower() == place.ToLower()).Select(x => x.Sales).Max();
                    answer = Math.Round(totalSales, 2);
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var totalSales = listedData.Where(x => x.State.ToLower() == place.ToLower()).Select(x => x.Sales).Min();
                    answer = Math.Round(totalSales, 2);
                }
                else if (type == "average")
                {
                    var totalSales = listedData.Where(x => x.State.ToLower() == place.ToLower()).Select(x => x.Sales).Average();
                    answer = Math.Round(totalSales, 2);
                }
            }
            else if ((region != null || region != "null") && (place == null || place == "null") && (year == 0) && (type != null || type != "null"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var totalSales = listedData.Where(x => x.Region.ToLower() == region.ToLower()).Select(x => x.Sales).Max();
                    answer = Math.Round(totalSales, 2);
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var totalSales = listedData.Where(x => x.Region.ToLower() == region.ToLower()).Select(x => x.Sales).Min();
                    answer = Math.Round(totalSales, 2);
                }
                else if (type == "average")
                {
                    var totalSales = listedData.Where(x => x.Region.ToLower() == region.ToLower()).Select(x => x.Sales).Average();
                    answer = Math.Round(totalSales, 2);
                }
            }

            else
            {
                answer = 0;
            }
            return answer;
        }

        [HttpGet]
        [Route("api/sales/GetData")]
        public string GetData(int year, string queryType, string type)
        {
            string answer = "No Matching Result";
            var data = Get(); //JArray.Parse(dummy);// Get();
            List<SalesData> listedData = new List<SalesData>();

            foreach (JObject parsedObject in data.Children<JObject>())
            {
                JObject salesData = (JObject)parsedObject;
                var _newData = new SalesData();
                _newData.Date = Convert.ToDateTime(salesData["Date add"]).Year;
                _newData.Region = salesData["Region"].ToString();
                _newData.State = salesData["State"].ToString();
                _newData.Sales = Convert.ToDecimal(salesData["Sales"]);
                listedData.Add(_newData);

            }

            if (year == 0 && (queryType == "region" || queryType == "area"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {

                    var maxSales = listedData.GroupBy(x => x.Region).Select(y => new
                    {
                        Region = y.Key,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = maxSales.Max(x => x.Sales);
                    var result = maxSales.Where(x => x.Sales == d).Select(x => x.Region).FirstOrDefault();
                    answer = result;
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var minSales = listedData.GroupBy(x => x.Region).Select(y => new
                    {
                        Region = y.Key,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = minSales.Min(x => x.Sales);
                    var result = minSales.Where(x => x.Sales == d).Select(x => x.Region).FirstOrDefault();
                    answer = result;
                }
        
            }
            else if (year != 0 && (queryType == "region" || queryType == "area"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var maxSales = listedData.GroupBy(x => x.Date).Select(y => new
                    {
                        Year = y.Key,
                        Region = y.First().Region,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = maxSales.Max(x => x.Sales);
                    var result = maxSales.Where(x => x.Sales == d).Select(x => x.Region).FirstOrDefault();
                    answer = result;

                    //var maxSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Max();
                    //var result = listedData.Where(x => x.Sales == maxSales).Select(x => x.Region).FirstOrDefault();
                    //answer = result;
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var minSales = listedData.GroupBy(x => x.Date).Select(y => new
                    {
                        Year = y.Key,
                        Region = y.First().Region,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = minSales.Min(x => x.Sales);
                    var result = minSales.Where(x => x.Sales == d).Select(x => x.Region).FirstOrDefault();
                    answer = result;
                    //var minSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Min();
                    //var result = listedData.Where(x => x.Sales == minSales).Select(x => x.Region).FirstOrDefault();
                    //answer = result;
                }
                //else if (type == "average")
                //{
                //    var avgSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Average();
                //    var result = listedData.Where(x => x.Sales == avgSales).Select(x => x.Region).FirstOrDefault();
                //    answer = result;
                //}

            }
            else if (year == 0 && (queryType == "state" || queryType == "us state"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var maxSales = listedData.GroupBy(x => x.State).Select(y => new
                    {
                        State = y.Key,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = maxSales.Max(x => x.Sales);
                    var result = maxSales.Where(x => x.Sales == d).Select(x => x.State).FirstOrDefault();
                    answer = result;
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var minSales = listedData.GroupBy(x => x.State).Select(y => new
                    {
                        State = y.Key,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = minSales.Min(x => x.Sales);
                    var result = minSales.Where(x => x.Sales == d).Select(x => x.State).FirstOrDefault();
                    answer = result;
                }
                else if (type == "average")
                {
                    var avgSales = listedData.Select(x => x.Sales).Average();
                    var result = listedData.Where(x => x.Sales == avgSales).Select(x => x.State).FirstOrDefault();
                    answer = result;
                }

            }
            else if (year != 0 && (queryType == "state" || queryType == "us state"))
            {
                if (type == "maximum" || type == "highest" || type == "largest" || type == "most")
                {
                    var maxSales = listedData.GroupBy(x => x.Date).Select(y => new
                    {
                        Year = y.Key,
                        State=y.First().State,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = maxSales.Max(x => x.Sales);
                    var result = maxSales.Where(x => x.Sales == d).Select(x => x.State).FirstOrDefault();
                    answer = result;

                    //var maxSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Max();
                    //var result = listedData.Where(x => x.Sales == maxSales).Select(x => x.State).FirstOrDefault();
                    //answer = result;
                }
                else if (type == "minimum" || type == "lowest" || type == "smallest" || type == "least")
                {
                    var minSales = listedData.GroupBy(x => x.Date).Select(y => new
                    {
                        year = y.Key,
                        State = y.First().State,
                        Sales = y.Sum(z => z.Sales)
                    }).ToList();
                    var d = minSales.Min(x => x.Sales);
                    var result = minSales.Where(x => x.Sales == d).Select(x => x.State).FirstOrDefault();
                    answer = result;
                    //var minSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Min();
                    //var result = listedData.Where(x => x.Sales == minSales).Select(x => x.State).FirstOrDefault();
                    //answer = result;
                }
                else if (type == "average")
                {
                    var avgSales = listedData.Where(x => x.Date == year).Select(x => x.Sales).Average();
                    var result = listedData.Where(x => x.Sales == avgSales).Select(x => x.State).FirstOrDefault();
                    answer = result;
                }

            }

            return answer;
        }

        // PUT: api/Sales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sales/5
        public void Delete(int id)
        {
        }
    }
}
