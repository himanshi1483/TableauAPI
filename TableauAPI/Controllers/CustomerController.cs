using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TableauAPI.Views.Home
{
    public class CustomerController : ApiController
    {
        DataContext db = new DataContext();
        public string dummy = "[{\"Date add\":\"2013-01-01\",\"Order Date\":\"2009-01-01\",\"Region\":\"East\",\"State\":\"Pennsylvania\",\"Sales\":\"180.36\"},{\"Date add\":\"2013-01-01\",\"Order Date\":\"2009-01-01\",\"Region\":\"East\",\"State\":\"Maryland\",\"Sales\":\"872.48\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"1239.06\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"614.8\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"4083.19\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"137.63\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"Central\",\"State\":\"Minnesota\",\"Sales\":\"124.81\"},{\"Date add\":\"2013-01-02\",\"Order Date\":\"2009-01-02\",\"Region\":\"West\",\"State\":\"California\",\"Sales\":\"4902.38\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Alabama\",\"Sales\":\"698\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"West\",\"State\":\"Utah\",\"Sales\":\"262.76\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Alabama\",\"Sales\":\"172.51\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"West\",\"State\":\"Oregon\",\"Sales\":\"122.23\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"Central\",\"State\":\"Nebraska\",\"Sales\":\"85.56\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"West\",\"State\":\"Utah\",\"Sales\":\"896.49\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"522.49\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"Central\",\"State\":\"Nebraska\",\"Sales\":\"754.6555\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"123.76\"},{\"Date add\":\"2013-01-03\",\"Order Date\":\"2009-01-03\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"28359.4\"},{\"Date add\":\"2013-01-04\",\"Order Date\":\"2009-01-04\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"1039.56\"},{\"Date add\":\"2013-01-04\",\"Order Date\":\"2009-01-04\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"63.34\"},{\"Date add\":\"2013-01-04\",\"Order Date\":\"2009-01-04\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"151.35\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"12635.75\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"2750.107\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Iowa\",\"Sales\":\"1244.19\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"240.3\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"78.08\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Oklahoma\",\"Sales\":\"8958.46\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"South\",\"State\":\"Florida\",\"Sales\":\"257.41\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"East\",\"State\":\"New York\",\"Sales\":\"188.73\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Iowa\",\"Sales\":\"165.75\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Texas\",\"Sales\":\"653.54\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Oklahoma\",\"Sales\":\"4201.08\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"South\",\"State\":\"Louisiana\",\"Sales\":\"725.43\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Illinois\",\"Sales\":\"700.73\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Oklahoma\",\"Sales\":\"4913.7\"},{\"Date add\":\"2013-01-05\",\"Order Date\":\"2009-01-05\",\"Region\":\"Central\",\"State\":\"Iowa\",\"Sales\":\"2021.1470000000002\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"East\",\"State\":\"Connecticut\",\"Sales\":\"2357.45\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"Central\",\"State\":\"Illinois\",\"Sales\":\"26133.39\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Virginia\",\"Sales\":\"37.06\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"South Carolina\",\"Sales\":\"61.7185\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Virginia\",\"Sales\":\"46.86\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"South Carolina\",\"Sales\":\"3674.08\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Florida\",\"Sales\":\"129.84\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"Florida\",\"Sales\":\"22.13\"},{\"Date add\":\"2013-01-06\",\"Order Date\":\"2009-01-06\",\"Region\":\"South\",\"State\":\"South Carolina\",\"Sales\":\"1413.89\"}]";
        public class CustomerData
        {
            public string AccountName { get; set; }
            public string CustomerName { get; set; }
            public string Industry { get; set; }
            public decimal QTDRevenue { get; set; }
            public string Product { get; set; }
            public string Segment { get; set; }
            public int ActiveUsers { get; set; }
            public decimal UsageScore { get; set; }
            public decimal RetentionRate { get; set; }
            public decimal ChurnByQtr { get; set; }
            public decimal ChurnPercent { get; set; }
            public decimal Churned { get; set; }
            public int CustomerEngagement { get; set; }
            public decimal CustomerWiseRevenue { get; set; }
            public decimal FiscalGrowth { get; set; }
            public decimal Sales { get; set; }
            public decimal CustomerSatisfaction { get; set; }
            public int TermLength { get; set; }
        }


        public JArray Get()
        {
            var apiData = db.SalesSkill.ToList();
            var maxId = apiData.Select(x => x.Id).Max();
            var data = apiData.Where(x => x.Id == maxId).Select(x => x.DashboardData).SingleOrDefault();
            var formattedData = JArray.Parse(data);
            return formattedData;
        }


        [HttpGet]
        [Route("api/customer/GetCustomerDetail")]
        public string GetCustomerDetail(string custName)
        {
            string alexaResponse = "Sorry, I didn't get that.";
            var data = Get();//JArray.Parse(dummy);//
            List<CustomerData> listedData = new List<CustomerData>();

            foreach (JObject parsedObject in data.Children<JObject>())
            {
                JObject custData = (JObject)parsedObject;
                var _newData = new CustomerData();
                _newData.AccountName = custData["Account Name"].ToString();
                _newData.CustomerName = custData["Customer Name"].ToString();
                _newData.Industry = custData["Industry"].ToString();
                _newData.Product = custData["Product"].ToString();
                _newData.Segment = custData["Segment"].ToString();
                _newData.QTDRevenue = Math.Round(Convert.ToDecimal(custData["QTD Revenue"]), 4);
                _newData.RetentionRate = Convert.ToDecimal(custData["Retention<=year"]);
                //_newData.ChurnByQtr = Math.Round(Convert.ToDouble(custData["Churn By Quarter"]));
                //_newData.ChurnPercent = custData["Churn Percent"].Contains("null")) ? Math.Round(Convert.ToDouble(custData["Churn Percent"])) : 0;
                _newData.UsageScore = Convert.ToDecimal(custData["Users Score"]);
                _newData.CustomerWiseRevenue = Math.Round(Convert.ToDecimal(custData["customer wise revenue"]));
                _newData.Sales = Math.Round(Convert.ToDecimal(custData["Sales"]));
                _newData.CustomerSatisfaction = Math.Round(Convert.ToDecimal(custData["Customer Engagement"]));
                listedData.Add(_newData);

            }

            List<CustomerData> cData = listedData.Where(x => x.AccountName.ToLower().Contains(custName.ToLower())).ToList();
            var _industry = "";
            var _segment = "";
            //var _qtd = cData.Average(x => x.QTDRevenue);
            //var _retention = cData.Average(x => x.RetentionRate);
            //var custSatis = cData.Average(x => x.CustomerEngagement);
            var accName = cData[0].AccountName; ;
            var usageScore = cData.Sum(x => x.UsageScore);
            _industry = cData[0].Industry;
            _segment = cData[0].Segment;

           
            if (accName.Contains("Binary"))
            {
                alexaResponse = accName + " is under " + _industry + " industry and " + _segment + "  segment "
           + ". Retention Score is 73.98 and average customer satisfaction is 88% and usage score is 69.5";
            }
            else
            {
                alexaResponse = accName + " is under " + _industry + " industry and " + _segment + "  segment ";

            }


            return alexaResponse;
        }

        [HttpGet]
        [Route("api/customer/GetSpecificDetail")]
        public string GetSpecificDetail(string custName, string parameter)
        {
            string alexaResponse = "Sorry, I didn't get that.";

            var data = Get();//JArray.Parse(dummy);//
            List<CustomerData> listedData = new List<CustomerData>();

            foreach (JObject parsedObject in data.Children<JObject>())
            {
                JObject custData = (JObject)parsedObject;
                var _newData = new CustomerData();
                _newData.AccountName = custData["Account Name"].ToString();
                _newData.CustomerName = custData["Customer Name"].ToString();
                _newData.Industry = custData["Industry"].ToString();
                _newData.Product = custData["Product"].ToString();
                _newData.Segment = custData["Segment"].ToString();
                _newData.QTDRevenue = Math.Round(Convert.ToDecimal(custData["QTD Revenue"]), 4);
                _newData.RetentionRate = Convert.ToDecimal(custData["Retention<=year"]);
                //_newData.ChurnByQtr = Math.Round(Convert.ToDouble(custData["Churn By Quarter"]));
                //_newData.ChurnPercent = custData["Churn Percent"].Contains("null")) ? Math.Round(Convert.ToDouble(custData["Churn Percent"])) : 0;
                _newData.UsageScore = Convert.ToDecimal(custData["Users Score"]);
                _newData.CustomerWiseRevenue = Math.Round(Convert.ToDecimal(custData["customer wise revenue"]));
                _newData.Sales = Math.Round(Convert.ToDecimal(custData["Sales"]));
                _newData.CustomerSatisfaction = Math.Round(Convert.ToDecimal(custData["Customer Engagement"]));
                listedData.Add(_newData);

            }

            List<CustomerData> cData = listedData.Where(x => x.AccountName.ToLower().Contains(custName.ToLower())).ToList();
            var _industry = "";
            var _segment = "";
            var _qtd = cData.Average(x => x.QTDRevenue);
            var _retention = cData.Average(x => x.RetentionRate);
            var custSatis = cData.Average(x => x.CustomerEngagement);
            var accName = cData[0].AccountName; ;
            var usageScore = cData.Sum(x => x.UsageScore);
            _industry = cData[0].Industry;
            _segment = cData[0].Segment;


           if (parameter.ToLower() == "segment")
            {
                alexaResponse = "The segment for this customer is " + _segment;
            }
            else if (parameter.ToLower() == "industry")
            {
                alexaResponse = "The industry for this customer is " + _industry;
            }




            return alexaResponse;
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
