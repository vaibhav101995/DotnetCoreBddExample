using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using WebAPICore;
using Xunit;

namespace DotnetCoreBddExample.Tests.StepDefinitions
{
    [Binding]
    public class EmpSteps : IClassFixture<WebApplicationFactory<Startup>>

    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage Response { get; set; }
        public EmpSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"I  open the  Sample Portal")]
        public void GivenIOpenTheSamplePortal()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost:44366/")
            });
        }

        [Given(@"I click  the ""(.*)""  MenuBar  to show  employee details")]
        public async Task GivenIClickTheMenuBarToShowEmployeeDetails(string p0)
        {
            string resourceEndPoint = "api/Employees";
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await _client.GetAsync(postRelativeUri).ConfigureAwait(false);
        }
        
        [Given(@"I open the emp  Sample Portal")]
        public void GivenIOpenTheEmpSamplePortal()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost:44366/")
            });
        }
        
        [Given(@"I click on the ""(.*)"" MenuBar to show all  employee data")]
        public void GivenIClickOnTheMenuBarToShowAllEmployeeData(string p0)
        {
        }
        
        [Given(@"I click the ""(.*)"" Button to  add employee details  from employee dasboard")]
        public void GivenIClickTheButtonToAddEmployeeDetailsFromEmployeeDasboard(string p0)
        {
        }
        
        [Given(@"New page will open  to fill  new employee data")]
        public void GivenNewPageWillOpenToFillNewEmployeeData()
        {
        }
        
        [Given(@"I fill following employee  details '(.*)'")]
        public async Task GivenIFillFollowingEmployeeDetails(string postDataJson)
        {
            string resourceEndPoint = "api/Employees";
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }
        
        [Given(@"I open Emp Sample  Portal")]
        public void GivenIOpenEmpSamplePortal()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost:44366/")
            });
        }
        
        [Given(@"I click the ""(.*)"" MenuBar   to show all employee data")]
        public void GivenIClickTheMenuBarToShowAllEmployeeData(string p0)
        {
        }
        
        [Given(@"I click the ""(.*)"" Button to  update  existing employee details")]
        public void GivenIClickTheButtonToUpdateExistingEmployeeDetails(string p0)
        {
        }
        
        [Given(@"New page will open with  existing  employee data")]
        public void GivenNewPageWillOpenWithExistingEmployeeData()
        {
        }
        
        [Given(@"I fill following employee details to update employeeName '(.*)'")]
        public async Task GivenIFillFollowingEmployeeDetailsToUpdateEmployeeName(string postDataJson)
        {
            string resourceEndPoint = "api/Employees";
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PutAsync(postRelativeUri, content).ConfigureAwait(false);
        }
        
        [Then(@"validate ""(.*)"" as a employee Name in Employee  Details  is displayed on the screen")]
        public void ThenValidateAsAEmployeeNameInEmployeeDetailsIsDisplayedOnTheScreen(string expectedResponse)
        {
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Contains(expectedResponse, responseData);
        }
        
        [Then(@"I click on the Add Employee  button")]
        public void ThenIClickOnTheAddEmployeeButton()
        {

            int statusCode = 201;
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
        
        [Then(@"validate ""(.*)"" as a employee  name are added into employee data")]
        public void ThenValidateAsAEmployeeNameAreAddedIntoEmployeeData(string expectedResponse)
        {
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Contains(expectedResponse, responseData);
        }
        
        [Then(@"I click on the Update  Employee button")]
        public void ThenIClickOnTheUpdateEmployeeButton()
        {
            int statusCode = 200;
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }

        [Then(@"validate ""(.*)"" as a employee name are  updated into employee data")]
        public void ThenValidateAsAEmployeeNameAreUpdatedIntoEmployeeData(string p0)
        {
            string expectedResp = "Updated Successfully";
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Contains(expectedResp, responseData);
        }
    }
}
