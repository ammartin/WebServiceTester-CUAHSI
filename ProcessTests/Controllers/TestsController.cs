using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTests;
using System.Configuration;
using ProcessTests.Models;

namespace ProcessTests.Controllers
{
    public class TestsController : Controller
    {
        private static string TestCasesFile = ConfigurationSettings.AppSettings["TestCasesFile"];
        private static string ExpectedResponsesFolder = ConfigurationSettings.AppSettings["ExpectedResponsesFolder"];
        private static string RealtimeResponsesFolder = ConfigurationSettings.AppSettings["RealtimeResponsesFolder"];

        public ActionResult Index()
        {
            var result = new vmMain();
            var load = new vmAjaxResult();
            try
            {
                var listOfServiceCallsToMake = XMLHelpers.ParseTestXML(TestCasesFile);
                var populatedUrls = XMLHelpers.ConstructServiceUrl(listOfServiceCallsToMake);
                result.TestCases = new List<vmTestCase>();
                populatedUrls.ForEach(x =>
                {
                    result.TestCases.Add(new vmTestCase { TestSuiteObject = x });
                });
                load.ErrorCode = 0;
                if (!populatedUrls.Any())
                {
                    load.ErrorCode = 1001;
                    load.ErrorMessage = String.Format("ERROR #{0}: Unable to recognize test cases from file [{1}]", load.ErrorCode, TestCasesFile);
                }
            }
            catch (Exception ex)
            {
                load.ErrorCode = 1000;
                load.ErrorMessage = String.Format("ERROR #{0}: {1}", load.ErrorCode, ex.Message);
            }
            result.vmAjaxResult = load;
            return View(result);
        }

        [HttpPost]
        public JsonResult RunIndividualTest(string testId, string constructedUrl)
        {
            var result = new vmAjaxResult();
            try
            {
                result = Tester.RunTest(ExpectedResponsesFolder, RealtimeResponsesFolder, testId, constructedUrl);
                return Json(result);
            }
            catch (Exception ex)
            {
                result.ErrorCode = 5000;
                result.ErrorMessage = Server.HtmlEncode(String.Format("ERROR #{0}: {1}", result.ErrorCode, ex.Message));
                return Json(result);
            }

        }

    }
}
