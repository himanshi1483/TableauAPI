using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace TableauAPI.Controllers
{
    public class ValuesController : ApiController
    {
        DataContext db = new DataContext();
        public string dummyData = "[{\"City\":\"Kingston\",\"Country\":\"Jamaica\",\"Hurricane Name\":\"ITEM\",\"ISO time\":\"1951-10-12 06:00:00\",\"ISO time (Month / Day / Year)\":\"19511012\",\"Populated Latitude\":\"15.5\",\"Populated Longitude\":\"-80\",\"Serial Num\":\"1951285N16280\",\"City Latitude\":\"17.9771\",\"City Longitude\":\"-76.7674\",\"City Population\":\"937700\",\"Days of Impact\":\"9\",\"Great Circle Distance (ish)\":\"274.2105602047136\",\"Population\":\"25.92221\",\"Wind(WMO)\":\"30\"},{\"City\":\"Kingston\",\"Country\":\"Jamaica\",\"Hurricane Name\":\"GERDA\",\"ISO time\":\"1961-10-16 00:00:00\",\"ISO time (Month / Day / Year)\":\"19611016\",\"Populated Latitude\":\"17.5\",\"Populated Longitude\":\"-77\",\"Serial Num\":\"1961289N18283\",\"City Latitude\":\"17.9771\",\"City Longitude\":\"-76.7674\",\"City Population\":\"937700\",\"Days of Impact\":\"8\",\"Great Circle Distance (ish)\":\"36.38393434472067\",\"Population\":\"343680.8\",\"Wind(WMO)\":\"30\"},{\"City\":\"Mombasa\",\"Country\":\"Kenya\",\"Hurricane Name\":\"0120022003:ABAIMBA\",\"ISO time\":\"2002-09-07 18:00:00\",\"ISO time (Month / Day / Year)\":\"20020907\",\"Populated Latitude\":\"-4\",\"Populated Longitude\":\"55\",\"Serial Num\":\"2002247S03067\",\"City Latitude\":\"-4.04\",\"City Longitude\":\"39.6899\",\"City Population\":\"882000\",\"Days of Impact\":\"1\",\"Great Circle Distance (ish)\":\"1056.3424069902724\",\"Population\":\"3.549741\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"INDLALA\",\"ISO time\":\"2007-03-16 00:00:00\",\"ISO time (Month / Day / Year)\":\"20070316\",\"Populated Latitude\":\"-16\",\"Populated Longitude\":\"48\",\"Serial Num\":\"2007066S12066\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"5\",\"Great Circle Distance (ish)\":\"204.2387958639783\",\"Population\":\"94933.1\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"IVAN\",\"ISO time\":\"2008-02-18 06:00:00\",\"ISO time (Month / Day / Year)\":\"20080218\",\"Populated Latitude\":\"-18.5\",\"Populated Longitude\":\"46\",\"Serial Num\":\"2008037S10055\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"3\",\"Great Circle Distance (ish)\":\"103.45031671921363\",\"Population\":\"53105.74\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"IVAN\",\"ISO time\":\"2008-02-18 00:00:00\",\"ISO time (Month / Day / Year)\":\"20080218\",\"Populated Latitude\":\"-18\",\"Populated Longitude\":\"47\",\"Serial Num\":\"2008037S10055\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"5\",\"Great Circle Distance (ish)\":\"71.88989569980113\",\"Population\":\"39724.72\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"FANELE\",\"ISO time\":\"2009-01-21 18:00:00\",\"ISO time (Month / Day / Year)\":\"20090121\",\"Populated Latitude\":\"-23\",\"Populated Longitude\":\"46.5\",\"Serial Num\":\"2009017S20043\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"6\",\"Great Circle Distance (ish)\":\"289.96615643470733\",\"Population\":\"73638.39\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"HUBERT\",\"ISO time\":\"2010-03-11 06:00:00\",\"ISO time (Month / Day / Year)\":\"20100311\",\"Populated Latitude\":\"-20.5\",\"Populated Longitude\":\"48\",\"Serial Num\":\"2010066S19050\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"7\",\"Great Circle Distance (ish)\":\"113.9529040715346\",\"Population\":\"142907.7\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"GAFILO\",\"ISO time\":\"2004-03-11 06:00:00\",\"ISO time (Month / Day / Year)\":\"20040311\",\"Populated Latitude\":\"-24\",\"Populated Longitude\":\"45\",\"Serial Num\":\"2004061S12072\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"6\",\"Great Circle Distance (ish)\":\"387.0982380880288\",\"Population\":\"57149.68\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"CHEDZA\",\"ISO time\":\"2015-01-17 06:00:00\",\"ISO time (Month / Day / Year)\":\"20150117\",\"Populated Latitude\":\"-21.5\",\"Populated Longitude\":\"48\",\"Serial Num\":\"2015013S18038\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"5\",\"Great Circle Distance (ish)\":\"181.4204115492649\",\"Population\":\"137146.8\",\"Wind(WMO)\":\"30\"},{\"City\":\"Antananarivo\",\"Country\":\"Madagascar\",\"Hurricane Name\":\"ELITA\",\"ISO time\":\"2004-01-31 18:00:00\",\"ISO time (Month / Day / Year)\":\"20040131\",\"Populated Latitude\":\"-20\",\"Populated Longitude\":\"44.5\",\"Serial Num\":\"2004025S16044\",\"City Latitude\":\"-18.9166\",\"City Longitude\":\"47.5166\",\"City Population\":\"1697000\",\"Days of Impact\":\"10\",\"Great Circle Distance (ish)\":\"210.51543410703215\",\"Population\":\"113177.9\",\"Wind(WMO)\":\"30\"}]";
        // GET api/values
        public JArray Get()
        {
            var apiData = db.AlexaSKill.ToList();
            var maxId = apiData.Select(x=>x.Id).Max();
            var data = apiData.Where(x => x.Id == maxId).Select(x => x.DashboardData).SingleOrDefault();
            var formattedData = JArray.Parse(data);
            //JsonConvert.SerializeObject(data, Formatting.Indented);
            //  var d = SanitizeReceivedJson(formattedData);
            return formattedData;
        }

        private string SanitizeReceivedJson(string uglyJson)
        {
            var sb = new StringBuilder(uglyJson);
            // sb.Replace("\\\t", "\t");
            // sb.Replace("\\\n", "\n");
            //  sb.Replace("\\\r", "\r");
            sb.Replace("\\", "");
            return sb.ToString();
        }
        // GET api/values/5
        [HttpGet]
        [Route("api/values/getKeyword")]
        public string GetKeyword()
        {
            var data = Get();
            var keyword = "";
            foreach (JObject parsedObject in data.Children<JObject>())
            {
                JObject tweet = (JObject)parsedObject;
                 keyword = tweet["Search Query"].ToString();
            }
            return keyword;
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/values/getCount")]
        public int GetCount(string text, string place, string sentiment)
        {
            int answer = 0;
            var data = Get();
            List<dynamic> listedData = new List<dynamic>();

            //Total Retweets
            if (text.StartsWith("retweet") && (place == null || place == "null") && (sentiment == null || sentiment == "null"))
            {
                //foreach (JObject parsedObject in data.Children<JObject>())
                //{
                //    foreach (JProperty parsedProperty in parsedObject.Properties())
                //    {
                //        string propertyName = parsedProperty.Name;
                //        if (propertyName.Equals("Total Retweets"))
                //        {
                //            int propertyValue = (Convert.ToInt32(parsedProperty.Value));
                //            listedData.Add(propertyValue);
                //            Console.WriteLine("Name: {0}, Value: {1}", propertyName, propertyValue);
                //        }
                //    }
                //    answer = listedData.Sum(x=>x);
                //}
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var totalRetweets = Convert.ToInt32(tweet["Total Retweets"]);
                    listedData.Add(totalRetweets);
                }
                answer = listedData.Sum(x => x);
            }
            //Total Tweets
            else if (text.StartsWith("tweet") && (place == null || place == "null") && (sentiment == null || sentiment == "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    // var location = tweet["Location"].ToString();
                    var totalRetweets = Convert.ToInt32(tweet["Total Tweets"]);
                    //  if (location == place)
                    listedData.Add(totalRetweets);

                }
                answer = listedData.Sum(x => x);
            }
            // Total Tweets from a location
            else if (text.StartsWith("tweet") && (place != null || place != "null") && (sentiment == null || sentiment == "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var location = tweet["Location"].ToString().ToLower();
                    var totalRetweets = Convert.ToInt32(tweet["Total Tweets"]);
                    if (location.StartsWith(place.ToLower()))
                    {
                        listedData.Add(totalRetweets);
                    }
                }
                answer = listedData.Sum(x => x);
            }
            // Total Retweets from a location
            else if (text.StartsWith("retweet") && (place != null || place != "null") && (sentiment == null || sentiment == "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var location = tweet["Location"].ToString().ToLower();
                    var totalRetweets = Convert.ToInt32(tweet["Total Retweets"]);
                    if (location.StartsWith(place.ToLower()))
                    {
                        listedData.Add(totalRetweets);
                    }
                }
                answer = listedData.Sum(x => x);
            }
            // Total Tweets with a sentiment
            else if (text.StartsWith("tweet") && (place == null || place == "null") && (sentiment != null || sentiment != "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var _sentiment = tweet["Sentiments_Updated"].ToString().ToLower();
                    var totalRetweets = Convert.ToInt32(tweet["Total Tweets"]);
                    if (_sentiment.ToLower() == sentiment)
                    {
                        listedData.Add(totalRetweets);
                    }
                }
                answer = listedData.Sum(x => x);
            }
            // Total Retweets with a sentiment
            else if (text.StartsWith("retweet") && (place == null || place == "null") && (sentiment != null || sentiment != "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var _sentiment = tweet["Sentiments_Updated"].ToString().ToLower();
                    var totalRetweets = Convert.ToInt32(tweet["Total Retweets"]);
                    if (_sentiment.ToLower() == sentiment)
                    {
                        listedData.Add(totalRetweets);
                    }
                }
                answer = listedData.Sum(x => x);
            }
            // Total Tweets with a sentiment and location
            else if (text.StartsWith("tweet") && (place != null || place != "null") && (sentiment != null || sentiment != "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var _sentiment = tweet["Sentiments_Updated"].ToString().ToLower();
                    var location = tweet["Location"].ToString().ToLower();
                    var totalRetweets = Convert.ToInt32(tweet["Total Tweets"]);
                    if (_sentiment.ToLower() == sentiment && location.StartsWith(place.ToLower()))
                    {
                        listedData.Add(totalRetweets);
                    }
                }
                answer = listedData.Sum(x => x);
            }
            // Total Retweets with a sentiment and location
            else if (text.StartsWith("retweet") && (place != null || place != "null") && (sentiment != null || sentiment != "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var _sentiment = tweet["Sentiments_Updated"].ToString().ToLower();
                    var location = tweet["Location"].ToString().ToLower();
                    var totalRetweets = Convert.ToInt32(tweet["Total Retweets"]);
                    if (_sentiment.ToLower() == sentiment && location.StartsWith(place.ToLower()))
                    {
                        listedData.Add(totalRetweets);
                    }
                }
                answer = listedData.Sum(x => x);
            }
            //  answer = listedData.Max();
            if(answer == null || answer == 0)
            {
                answer = 0;
            }
            return answer;
        }


        [HttpGet]
        [Route("api/values/getSentiment")]
        public string GetSentiment(string text, string place)
        {
            string answer = string.Empty;
            var data = Get();
            List<dynamic> listedData = new List<dynamic>();
            List<dynamic> positive = new List<dynamic>();
            List<dynamic> negative = new List<dynamic>();
            List<dynamic> neutral = new List<dynamic>();
            //Total Retweets
            if (text.StartsWith("retweet") && (place == null || place == "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var totalRetweets = Convert.ToInt32(tweet["Total Retweets"]);

                    var tweetSentiment = tweet["Sentiments_Updated"].ToString().ToLower();

                    if (tweetSentiment == "positive" && totalRetweets > 0)
                    {
                        positive.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "negative" && totalRetweets > 0)
                    {
                        negative.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "neutral" && totalRetweets > 0)
                    {
                        neutral.Add(tweetSentiment);
                    }
                }

                //var highestSentiment = Math.Max(positive.Count, negative.Count);
                // highestSentiment = Math.Max(highestSentiment, neutral.Count);

                if ((positive.Count > negative.Count) && (positive.Count > neutral.Count))
                {
                    answer = "Positive";
                }
                else if ((negative.Count > positive.Count) && (negative.Count > neutral.Count))
                {
                    answer = "Negative";
                }
                else if ((neutral.Count > positive.Count) && (neutral.Count > negative.Count))
                {
                    answer = "Neutral";
                }
            }
            //Total Tweets
            else if (text.StartsWith("tweet") && (place == null || place == "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var totalTweets = Convert.ToInt32(tweet["Total Tweets"]);

                    var tweetSentiment = tweet["Sentiments_Updated"].ToString().ToLower();
                    if (tweetSentiment == "positive" && totalTweets > 0)
                    {
                        positive.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "negative" && totalTweets > 0)
                    {
                        negative.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "neutral" && totalTweets > 0)
                    {
                        neutral.Add(tweetSentiment);
                    }
                }

                //var highestSentiment = Math.Max(positive.Count, negative.Count);
                // highestSentiment = Math.Max(highestSentiment, neutral.Count);

                if ((positive.Count > negative.Count) && (positive.Count > neutral.Count))
                {
                    answer = "Positive";
                }
                else if ((negative.Count > positive.Count) && (negative.Count > neutral.Count))
                {
                    answer = "Negative";
                }
                else if ((neutral.Count > positive.Count) && (neutral.Count > negative.Count))
                {
                    answer = "Neutral";
                }
            }
            // Total Tweets from a location
            else if (text.StartsWith("tweet") && (place != null || place != "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var totalTweets = Convert.ToInt32(tweet["Total Tweets"]);
                    var location = tweet["Location"].ToString().ToLower();
                    var tweetSentiment = tweet["Sentiments_Updated"].ToString().ToLower();

                    if (tweetSentiment == "positive" && totalTweets > 0 && location.StartsWith(place))
                    {
                        positive.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "negative" && totalTweets > 0 && location.StartsWith(place))
                    {
                        negative.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "neutral" && totalTweets > 0 && location.StartsWith(place))
                    {
                        neutral.Add(tweetSentiment);
                    }
                }
                if ((positive.Count > negative.Count) && (positive.Count > neutral.Count))
                {
                    answer = "Positive";
                }
                else if ((negative.Count > positive.Count) && (negative.Count > neutral.Count))
                {
                    answer = "Negative";
                }
                else if ((neutral.Count > positive.Count) && (neutral.Count > negative.Count))
                {
                    answer = "Neutral";
                }
            }
            // Total Retweets from a location
            else if (text.StartsWith("retweet") && (place != null || place != "null"))
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var totalTweets = Convert.ToInt32(tweet["Total Retweets"]);
                    var location = tweet["Location"].ToString().ToLower();
                    var tweetSentiment = tweet["Sentiments_Updated"].ToString().ToLower();

                    if (tweetSentiment == "positive" && totalTweets > 0 && location.StartsWith(place))
                    {
                        positive.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "negative" && totalTweets > 0 && location.StartsWith(place))
                    {
                        negative.Add(tweetSentiment);
                    }
                    else if (tweetSentiment == "neutral" && totalTweets > 0 && location.StartsWith(place))
                    {
                        neutral.Add(tweetSentiment);
                    }
                }
                if ((positive.Count > negative.Count) && (positive.Count > neutral.Count))
                {
                    answer = "Positive";
                }
                else if ((negative.Count > positive.Count) && (negative.Count > neutral.Count))
                {
                    answer = "Negative";
                }
                else if ((neutral.Count > positive.Count) && (neutral.Count > negative.Count))
                {
                    answer = "Neutral";
                }
            }
            if (answer == "" || answer == null)
            {
                answer = "No Matching results";
            }
            return answer.ToString();

        }


        [HttpGet]
        [Route("api/values/getAnswers")]
        public string GetAnswers(string count, string text, string order, int tweetCount)
        {
            List<string> answer = new List<string>();
            var data = Get();
            List<string> listedData = new List<string>();
            if ((text.ToLower().StartsWith("location") || text.ToLower().StartsWith("place") || text.ToLower().StartsWith("area")) && tweetCount == 0)
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var locations = tweet["Location"].ToString();
                    if (locations != string.Empty)
                    {
                        listedData.Add(locations.ToString());
                    }
                }

                if (order.ToLower() == "bottom" || order.ToLower() == "lowest")
                {
                    answer = listedData.GroupBy(q => q).OrderBy(gp => gp.Count())
                                  .Take(10)
                                  .Select(g => g.Key).ToList();
                }
                else
                {
                    answer = listedData.GroupBy(q => q).OrderByDescending(gp => gp.Count())
                                  .Take(10)
                                  .Select(g => g.Key).ToList();
                }

            }
            else if ((text.ToLower().StartsWith("hashtag")) && tweetCount == 0)
            {

                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var locations = tweet["hashtag"].ToString();
                    if (locations != string.Empty)
                    {
                        listedData.Add(locations.ToString());
                    }
                }


                if (order.ToLower() == "bottom" || order.ToLower() == "lowest")
                {
                    answer = listedData.GroupBy(q => q).OrderBy(gp => gp.Count())
                                  .Take(10)
                                  .Select(g => g.Key).ToList();
                }
                else
                {
                    answer = listedData.GroupBy(q => q).OrderByDescending(gp => gp.Count())
                                  .Take(10)
                                  .Select(g => g.Key).ToList();
                }

            }
            else if ((text.ToLower().StartsWith("influencer")) && tweetCount == 0)
            {
                var listFollower = new List<Tuple<string, long>>();

                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var followerCount = Convert.ToInt64(tweet["Max Followers"]);
                    var _user = tweet["Screen Name"].ToString();
                    if (_user != string.Empty)
                    {
                      listFollower.Add( new Tuple<string,long>(_user, followerCount));
                    }
                }


                if (order.ToLower() == "bottom" || order.ToLower() == "lowest")
                {
                    answer = (listFollower.OrderBy(x => x.Item2).Select(x => x.Item1).ToList());
                }
                else
                {
                    answer = listFollower.OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();
                }

            }
            else if(tweetCount == 1)
            {
                foreach (JObject parsedObject in data.Children<JObject>())
                {
                    JObject tweet = (JObject)parsedObject;
                    var locations = tweet["Location"].ToString();
                    if (locations != string.Empty)
                    {
                        listedData.Add(locations.ToString());
                    }
                }

                if (order.ToLower() == "bottom" || order.ToLower() == "lowest")
                {
                  var d  = listedData.GroupBy(q => q).OrderBy(gp => gp.Count())
                                  .Take(1)
                                  .Select(g => g.Key).ToList();
                  //  answer = listedData.Where(x => x == d).ToList();
                    answer.Add(listedData.Where(x => x == d.SingleOrDefault()).Count().ToString());
                }
                else
                {
                    var d = listedData.GroupBy(q => q).OrderByDescending(gp => gp.Count())
                                  .Take(1)
                                  .Select(g => g.Key).ToList();
                    answer.Add(listedData.Where(x => x == d.SingleOrDefault()).Count().ToString());
                }
            }

            if (answer.Count == 0)
            {
                answer.Add("null");
            }
            if (count == null || count == "null")
            {
                return answer.FirstOrDefault();
            }
            else
            {
                return string.Join(",", answer.Take(Convert.ToInt32(count)));
            }
        }


        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
