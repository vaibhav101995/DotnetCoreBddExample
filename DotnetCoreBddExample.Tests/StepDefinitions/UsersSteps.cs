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
    public class UsersSteps : IClassFixture<WebApplicationFactory<Startup>>

    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage Response { get; set; }
        public UsersSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"I open the Employee Dashboard &  able to see User login page")]
        public void GivenIOpenTheEmployeeDashboardAbleToSeeUserLoginPage()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost:44366/")
            });
        }

        [Given(@"I fill ""(.*)"" into  the emailID textbox && ""(.*)"" into the Password textbox")]
        public async Task GivenIFillIntoTheEmailIDTextboxIntoThePasswordTextbox(string emailID, string p1)
        {
            string resourceEndPoint = "api/UserDetails/" + emailID;
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await _client.GetAsync(postRelativeUri).ConfigureAwait(false);
        }

        [Given(@"I open the  Sample Portal")]
        public void GivenIOpenTheSamplePortal()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://localhost:44366/")
            });
        }
        
        [Given(@"I click the ""(.*)"" Button to  add user details from employee dasboard")]
        public void GivenIClickTheButtonToAddUserDetailsFromEmployeeDasboard(string p0)
        {
        }
        
        [Given(@"New page will open to fill  new user data")]
        public void GivenNewPageWillOpenToFillNewUserData()
        {
        }
        
        [Given(@"I fill following  user data '(.*)'")]
        public async Task GivenIFillFollowingUserData(string postDataJson)
        {
            string resourceEndPoint = "api/UserDetails";
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }
        
        [When(@"I click   the ""(.*)""  button")]
        public void WhenIClickTheButton(string p0)
        {
            int statusCode = 200;
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
        
        [When(@"I click on the ""(.*)""  button")]
        public void WhenIClickOnTheButton(string p0)
        {
            int statusCode = 201;
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
        
        [Then(@"validate ""(.*)""  User password on the screen && user can able to login Employee Dashboard")]
        public void ThenValidateUserPasswordOnTheScreenUserCanAbleToLoginEmployeeDashboard(string expectedResponse)
        {
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Contains(expectedResponse, responseData);
        }
        
        [Then(@"validate ""(.*)"" as new  userEMailID into user details & user is created")]
        public void ThenValidateAsNewUserEMailIDIntoUserDetailsUserIsCreated(string expectedResponse)
        {
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Contains(expectedResponse, responseData);
        }
    }
}
