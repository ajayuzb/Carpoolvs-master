using System;
using TechTalk.SpecFlow;
using Carpoolmodels;
using NUnit.Framework;
using CarpoolService;

namespace Carpool
{
    [Binding]
    public class QuickpostSteps
    {
        Ride ride;
        Employee employee;
        string actionButton, popupButton, message;
        [Given(@"""(.*)"" enter ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenEnterAndAnd(string empName, string source, string destination, string time)
        {
            ride = new Ride();
            employee = new Employee();
            ride.Source = source;
            ride.Destination = destination;
            ride.Ride_Date = DateTime.Now;
            ride.Ride_Time = DateTime.Parse(time);
            employee.Name = empName;

        }
        
        [Given(@"his ""(.*)"" and ""(.*)""")]
        public void GivenHisAnd(string email, string phone)
        {
            employee.Email = email;
            employee.Phone = phone;
        }
        
        [When(@"click on ""(.*)""")]
        public void WhenClickOn(string p0)
        {
            //ScenarioContext.Current.Pending();
            actionButton = p0;
        }
        
        [Then(@"system display ""(.*)"" with ""(.*)"" button")]
        public void ThenSystemDisplayWithButton(string p0, string p1)
        {
            //ScenarioContext.Current.Pending();
            popupButton = p1;
            message = p0;
            RideCollection shareRide = new RideCollection();
            shareRide.MyRide = ride;
            shareRide.MyEmployee = employee;
            RideService rideService = new RideService();
            Assert.NotNull(rideService.SaveRide(shareRide));

        }
        
        [Then(@"click on OK button will redirect on ""(.*)""")]
        public void ThenClickOnOKButtonWillRedirectOn(string p0)
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
