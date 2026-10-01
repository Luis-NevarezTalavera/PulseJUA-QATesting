using NUnit.Framework;
using Pulse.JUARatingQATesting;

namespace BDDJUARatingEngineTest.StepDefinitions
{
    [Binding]
    public class JUARatingEngineStepDefinitions
    {
        static JUARatingQATesting? ratingEngine;
        string? appNo, categoryName, policyType;
        double actualPremium;

        static string currentScenario, lastScenario = "";
        static string? testResult, scenarioResult, regressionResult, regressionResultDetail = "";
        static int passCount, failCount, totalCount = 0;
        static DateTime regressionStartDT, regressionFinishDT;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            // This method will run once before any scenarios in the feature file are executed
            regressionStartDT = DateTime.Now;
            Console.WriteLine("<<< BeforeFeature - JUA Rating Engine QA Testing STARTED: " + regressionStartDT.ToString("yyyy-MM-dd HH:mm:ss") + " >>>");
            ratingEngine = new JUARatingQATesting(); // Create an instance of the JUARatingQATesting class to initialize the services
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("\n\n<<< AfterFeature - JUA Rating Engine QA Testing COMPLETED: " + regressionFinishDT.ToString("yyyy-MM-dd HH:mm:ss") + " >>>");
            Console.WriteLine("Regression Duration: " + (regressionFinishDT - regressionStartDT).TotalMinutes.ToString("F2") + " minutes");
            regressionResult = regressionResult == "PASS" ? "PASS: " + passCount + " / " + totalCount : "FAIL: " + failCount + " / " + totalCount;
            Console.WriteLine("\nQA Regression Final Result: " + regressionResult);
            Console.WriteLine("Detailed Result:");
            Console.WriteLine(regressionResultDetail);
        }

        [Given("A Medical Insurance Application was created in Pulse JUA with category PhysicianSurgeon")]
        public void GivenAMedicalInsuranceApplicationWasCreatedInPulseJUAWithCategoryPhysicianSurgeon()
        {
            categoryName = "PhysicianSurgeon";
        }

        [Given("A Medical Insurance Application was created in Pulse JUA with category HealthCareProfessional")]
        public void GivenAMedicalInsuranceApplicationWasCreatedInPulseJUAWithCategoryHealthCareProfessional()
        {
            categoryName = "HealthCareProfessional";
        }

        [Given("A Medical Insurance Application was created in Pulse JUA with category FacilityAppl")]
        public void GivenAMedicalInsuranceApplicationWasCreatedInPulseJUAWithCategoryFacilityAppl()
        {
            categoryName = "FacilityAppl";
        }

        [Given("Policy type is Claimsmade")]
        public void GivenPolicyTypeIsClaimsmade()
        {
            policyType = "ClaimsMade";
        }

        [Given("Policy type is Occurrence")]
        public void GivenPolicyTypeIsOccurrence()
        {
            policyType = "Occurrence";
        }

        [When("the Application is Rated with appNo = {string} and appId = {string}")]
        public void WhenTheApplicationIsRatedWithAppNoAndAppId(string appNo, string appId)
        {
            actualPremium = ratingEngine.RateApplicationNoOutput(appId, appNo, categoryName, policyType);
        }

        [Then("the calculated Premium for appNo = {string} should be equal to {float}")]
        public void ThenTheCalculatedPremiumForAppNoAndAppIdShouldBeEqualTo(string appNo, Decimal expectedPremium)
        {
            if (actualPremium == (double) expectedPremium)
            {
                passCount++;
                testResult = "PASS";
                if (lastScenario != currentScenario)
                {
                    // New scenario starts, reset scenario result to PASS
                    scenarioResult = "PASS";
                }
                else
                {
                    // Same scenario, keep the scenario result as FAIL if it was already set to FAIL
                    scenarioResult = scenarioResult != "FAIL" ? "PASS" : "FAIL";
                };

                regressionResult = regressionResult != "FAIL" ? "PASS" : "FAIL";
                regressionResultDetail = regressionResultDetail + $"Application No {appNo}; {testResult}; Actual Premium = Expected Premium = {actualPremium:C}\n";
                Console.WriteLine($"Test Result is: {testResult} for Application No: {appNo}. Actual Premium = Expected Premium: {actualPremium:C}");
            }
            else
            {
                failCount++;
                testResult = "FAIL";
                scenarioResult = "FAIL";
                regressionResult = "FAIL";
                regressionResultDetail = regressionResultDetail + $"Application No {appNo}; {testResult}; Actual Premium = {actualPremium:C}; Expected Premium = {expectedPremium:C}\n";
                Console.WriteLine($"Test Result is: {testResult} for Application No: {appNo}.  Actual Premium = {actualPremium:C}; Expected Premium = {expectedPremium:C}");
            }

            totalCount++;
            lastScenario = currentScenario;
            Assert.That(actualPremium, Is.EqualTo(expectedPremium), $"Application No: {appNo}");
        }
    }
}