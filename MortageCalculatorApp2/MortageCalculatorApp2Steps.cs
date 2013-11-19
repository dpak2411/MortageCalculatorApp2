
using System;
using System.Collections;
using System.IO;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web.Script.Serialization;
using AlteryxGalleryAPIWrapper;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MortageCalculatorApp2
{
    [Binding]
    public class MortageCalculatorApp2Steps
    {

        private string _devurl;
        [Given(@"alteryx running at""(.*)""")]
        public void GivenAlteryxRunningAt(string p0)
        {
            _devurl = p0;
        }
        
        [Given(@"I am logged in using ""(.*)"" and ""(.*)""")]
        public void GivenIAmLoggedInUsingAnd(string username, string password)
        {
            Client Obj = new Client("https://gallery.alteryx.com/api/");
            // Obj.Authenticate("deepak.manoharan@accionlabs.com", "P@ssw0rd");
            Obj.Authenticate(username, password);
            string response = Obj.SearchApps("mortgage");  //url + "/apps/studio/?search=" + appName + "&limit=20&offset=0"
            var dict = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(response);
            int count = dict["recordCount"];
            int i = 0;
            string id = dict["records"][i]["id"];
            string res = Obj.GetAppInterface(id); //url +"/apps/" + appPackageId + "/interface/
            dynamic resp1 = JsonConvert.DeserializeObject(res);
            
            


        }
        
        [When(@"I publish application: mortgage calculator")]
        public void WhenIPublishApplicationMortgageCalculator()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I run mortgage calculator with principle (.*) interest (.*) payments (.*)")]
        public void WhenIRunMortgageCalculatorWithPrincipleInterestPayments(int p0, Decimal p1, int p2)
        {
            
        }
        
        [Then(@"I see output (.*)")]
        public void ThenISeeOutput(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
