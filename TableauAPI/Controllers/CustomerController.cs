using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using static TableauAPI.Controllers.SalesController;

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
            public string OpportunutyStage { get; set; }
            public string Product { get; set; }
            public string Segment { get; set; }
            public int ActiveUsers { get; set; }
            public double AnnualRevenue { get; set; }
            public double ARPU { get; set; }
            public double ChurnByQtr { get; set; }
            public double ChurnPercent { get; set; }
            public double Churned { get; set; }
            public int CustomerEngagement { get; set; }
            public double CustomerWiseRevenue { get; set; }
            public double FiscalGrowth { get; set; }
            public double Sales { get; set; }
            public double TotalAmount { get; set; }
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
                _newData.AnnualRevenue = Math.Round(Convert.ToDouble(custData["Annual Revenue"]),2);
                _newData.ARPU = Convert.ToDouble(custData["ARPU"]);
                //_newData.ChurnByQtr = Math.Round(Convert.ToDouble(custData["Churn By Quarter"]));
                //_newData.ChurnPercent = Math.Round(Convert.ToDouble(custData["Churn Percent"]));
                //_newData.Churned = Math.Round(Convert.ToDouble(custData["Churned"]));
                _newData.CustomerWiseRevenue = Math.Round(Convert.ToDouble(custData["customer wise revenue"]));
                _newData.Sales = Math.Round(Convert.ToDouble(custData["Sales"]));
                _newData.TotalAmount = Math.Round(Convert.ToDouble(custData["Total Amount"]));
                listedData.Add(_newData);

            }

            CustomerData cData = listedData.Where(x => x.CustomerName.ToLower() == custName.ToLower()).FirstOrDefault();

            string alexaResponse = "Customer " + custName + " is under account " + cData.AccountName + " and segment " + cData.Segment + " and " + cData.Industry + " industry. " +
                "The product listed under this customer is " + cData.Product + ". The annual revenue of this customer is " + cData.AnnualRevenue;
           
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
                _newData.AnnualRevenue = Math.Round(Convert.ToDouble(custData["Annual Revenue"]), 2);
                _newData.ARPU = Convert.ToDouble(custData["ARPU"]);
                //_newData.ChurnByQtr = Math.Round(Convert.ToDouble(custData["Churn By Quarter"]));
                //_newData.ChurnPercent = Math.Round(Convert.ToDouble(custData["Churn Percent"]));
                //_newData.Churned = Math.Round(Convert.ToDouble(custData["Churned"]));
                _newData.CustomerWiseRevenue = Math.Round(Convert.ToDouble(custData["customer wise revenue"]));
                _newData.Sales = Math.Round(Convert.ToDouble(custData["Sales"]));
                _newData.TotalAmount = Math.Round(Convert.ToDouble(custData["Total Amount"]));
                listedData.Add(_newData);

            }
            CustomerData cData = listedData.Where(x => x.CustomerName.ToLower() == custName.ToLower()).FirstOrDefault();
            if(parameter.ToLower() == "annual revenue")
            {
                 alexaResponse = "The annual revenue of this customer is " + cData.AnnualRevenue;
            }
            else if (parameter.ToLower().Contains("sales"))
            {
                alexaResponse = "The sales for this customer is " + cData.Sales;
            }
            else if (parameter.ToLower() == "total amount")
            {
                alexaResponse = "The total amount for this customer is " + cData.TotalAmount;
            }
            else if (parameter.ToLower() == "ARPU")
            {
                alexaResponse = "The ARPU for this customer is " + cData.ARPU;
            }
            else if (parameter.ToLower() == "customer wise revenue")
            {
                alexaResponse = "The customer wise revenue for this customer is " + cData.CustomerWiseRevenue;
            }
            else if (parameter.ToLower() == "segment")
            {
                alexaResponse = "The segment for this customer is " + cData.Segment;
            }
            else if (parameter.ToLower() == "industry")
            {
                alexaResponse = "The industry for this customer is " + cData.Industry;
            }
            else if (parameter.ToLower() == "product")
            {
                alexaResponse = "The product for this customer is " + cData.Product;
            }
            else if (parameter.ToLower().Contains("account"))
            {
                alexaResponse = "The account for this customer is " + cData.AccountName;
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
