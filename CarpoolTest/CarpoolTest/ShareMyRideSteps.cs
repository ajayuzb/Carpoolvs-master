using System;
using TechTalk.SpecFlow;
using CarpoolService;
using NUnit.Framework;

namespace CarpoolTest
{
    [Binding]
    public class ShareMyRideSteps
    {
        Ride ride = new Ride();
        string actionButton;
        [Given(@"user ""(.*)"" has entered ""(.*)"", ""(.*)"" at ""(.*)""")]
        public void GivenUserHasEnteredAt(string empname, string source, string desti, string time)
        {
            //ScenarioContext.Current.Pending();
            ride.Empname = empname;
            ride.Soruce = source;
            ride.Destination = desti;
        }
        
        [Given(@"user email ""(.*)"" and phone is ""(.*)""")]
        public void GivenUserEmailAndPhoneIs(string p0, Decimal p1)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I press ""(.*)""")]
        public void WhenIPress(string p0)
        {
            //ScenarioContext.Current.Pending();
            actionButton = p0;
        }
        
        [Then(@"the message should be ""(.*)""")]
        public void ThenTheMessageShouldBe(string p0)
        {
            //ScenarioContext.Current.Pending();
            RideService obj = new RideService();
            Assert.AreEqual(p0, obj.SaveRide(ride));
        }
    }
}
