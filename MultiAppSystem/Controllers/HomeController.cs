using MultiAppSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MultiAppSystem.Controllers
{
    public class HomeController : Controller
    {
        public class AllAppDetailsData
        {
            public List<allappsdetails> allappsdetails
            {
                get;
                set;
            }
        }
        public class Comments
        {
            public List<CommentData> notice
            {
                get;
                set;
            }
        }
        public class NonJoinedUsers
        {
            public List<UserData> users_noApp
            {
                get;
                set;
            }
        }
        private int App_ID;
        


        private List<String> ProjectName {
            get;
            set;
        }
        private List<String> BuildingName
        {
            get;
            set;
        }
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://unstranger.azurewebsites.net/api/AppAdmin/allapps?token=123";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Apps = JsonConvert.DeserializeObject<AllAppDetailsData>(responseData);
                return View(Apps.allappsdetails.ToList());
            }
            return View("Error");
        }
       [HttpGet]
        public ActionResult CreateApp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateApp(AllAppDetails appData)
        {
            Uri requestUri = new Uri("http://unstranger.azurewebsites.net/api/AppAdmin/createapp?token=123");  
            string json = "";
            appData.app_id = 0;
            appData.app_splashlink= "http://unstranger.azurewebsites.net/AppSplashImage/IMAGE_1494319766769_914508951.jpg";
            appData.app_latitude = 0.0;
            appData.app_longitude = 0.0;
            appData.app_type = 1;
            appData.app_subtype = 1;
            appData.isPrivate = true;
            //AppAdmin appAdmin = new AppAdmin();
            //appAdmin.admin_userid = "us659626989108639315334429853149";
            InputAppData finalData = new InputAppData();
            finalData.app_details = appData;
            finalData.admin_masterid = "us870951684669578216641";
            json = JsonConvert.SerializeObject(finalData);
            HttpResponseMessage respon = await client.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            string responJsonText = await respon.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
            //return View();
        }
        [HttpGet]
        public ActionResult CreateSociety()
        {
            var message = TempData["Project"] as List<String>;
            ViewBag.Project= message;
            return View();
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProjectData(String[] DynamicTextBox1)
        {
            ProjectName =new List<String>();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.Values = serializer.Serialize(DynamicTextBox1);
            string message = "";
                    foreach (string projectValue in DynamicTextBox1)
                    {
                        message += projectValue + "\\n";
                        ProjectName.Add(message);
                    }
            TempData["Project"] = ProjectName;
            return RedirectToAction("CreateSociety");
          //  return View();
        }
        public ActionResult CreateBuildingData(String[] DynamicTextBox2)
        {
            BuildingName = new List<String>();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.Values = serializer.Serialize(DynamicTextBox2);
            string message = "";
                    foreach (string projectValue in DynamicTextBox2)
                    {
                        message += projectValue + "\\n";
                        BuildingName.Add(message);
                    }
            TempData["Building"] = message;
            return RedirectToAction("CreateSociety");
          //  return View();
        }
        [HttpPost]
        public ActionResult CreateSociety(BuildingData bData)
        {
            bData.building_name.Add(ProjectName[0]);
            bData.building_name.Add(BuildingName[0]);
            string json = "";
            json = JsonConvert.SerializeObject(bData);
            ViewBag.Message = "Society data submitted successfully!";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> AllPosts(int app_id)
        {
            App_ID = app_id;
            InputNoticeData d = new InputNoticeData();
            d.user_masterid = "us659626989108639315334429853149";
            d.app_id =app_id;
            d.club_id = 0;
            String  json = JsonConvert.SerializeObject(d);
            HttpResponseMessage responseMessage = await client.PostAsync("http://unstranger.azurewebsites.net/api/NoticeBoard/allposts?token=123", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Notices = JsonConvert.DeserializeObject<AllNotices>(responseData);
                Notices.app_id = app_id;
                return View(Notices.allposts_data);
            }
            return View("Error");
        }
        public async Task<ActionResult> AllComments(int notice_id,String App_ID)
        {
           // var app_id = TempData["AppID"] as String;
            InputCommentData d = new InputCommentData();
            d.place_id = " ";
            d.app_id = Convert.ToInt16(App_ID);
            d.notice_id = notice_id;
            String json = JsonConvert.SerializeObject(d);
            HttpResponseMessage responseMessage = await client.PostAsync("http://unstranger.azurewebsites.net/api/AppAdmin/getcomments?token=123", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Comments = JsonConvert.DeserializeObject<Comments>(responseData);
                return View(Comments.notice);
            }
            return View("Error");
        }
        public async Task<ActionResult> AllNonJoinedUsers()
        {

            String json = ""; //JsonConvert.SerializeObject(d);
            HttpResponseMessage responseMessage = await client.PostAsync("http://unstranger.azurewebsites.net/api/AppAdmin/users_notjoinedanyapp?token=123", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Users = JsonConvert.DeserializeObject<NonJoinedUsers>(responseData);
                return View(Users.users_noApp);
            }
            return View("Error");
        }
    }
}