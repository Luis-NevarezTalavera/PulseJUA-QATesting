using NUnit.Framework;
using Pulse.JUARatingQATesting;

namespace JUA.RatingQATesting
{
    [TestFixture]
    public class JuaRatingEngineNUnitTest
    {
        JUARatingQATesting? ratingEngine;
        double actualPremium;

        string testResult = "";
        string regressionResult = "";
        string regressionResultDetail = "";
        int passCount = 0;
        int failCount = 0;
        int totalCount = 0;
        DateTime regressionStartDT;
        DateTime regressionFinishDT;

        [DatapointSource]
        public static AppInfo[] appsInfoData = [
            new AppInfo ("C94FE6C3-9160-4D8F-36B4-08DE38C84580", "000003", "PhysicianSurgeon", "ClaimsMade",  9799.0),
            new AppInfo ("0F499B5E-7CEF-41EC-8459-08DE39C62624", "000004", "PhysicianSurgeon", "ClaimsMade", 28844.0),
            new AppInfo ("252A948C-BA91-4E95-845A-08DE39C62624", "000005", "PhysicianSurgeon", "ClaimsMade", 57884.0),
            new AppInfo ("09728801-2468-4319-845B-08DE39C62624", "000006", "PhysicianSurgeon", "ClaimsMade", 43973.0),
            new AppInfo ("22EA07DC-97BD-45CA-845C-08DE39C62624", "000007", "PhysicianSurgeon", "ClaimsMade", 17542.0),
            new AppInfo ("73E76A79-A87C-4AE4-845D-08DE39C62624", "000008", "PhysicianSurgeon", "ClaimsMade", 31999.0),
            new AppInfo ("BC659C69-EB16-4760-845E-08DE39C62624", "000009", "PhysicianSurgeon", "ClaimsMade",  8037.0),
            new AppInfo ("AAD9A152-6A39-4AFA-845F-08DE39C62624", "000010", "PhysicianSurgeon", "ClaimsMade", 67939.0),

            new AppInfo ("BA3C9A21-034C-4968-8460-08DE39C62624", "000011", "PhysicianSurgeon", "Occurrence", 42543.0),
            new AppInfo ("07F582E5-475D-4A3E-8461-08DE39C62624", "000012", "PhysicianSurgeon", "Occurrence",  3980.0),
            new AppInfo ("496D8AA5-2D8D-4B89-8462-08DE39C62624", "000013", "PhysicianSurgeon", "Occurrence", 33679.0),
            new AppInfo ("68034A46-009F-4836-8463-08DE39C62624", "000014", "PhysicianSurgeon", "Occurrence", 10628.0),
            new AppInfo ("83DE5157-2B97-4238-8464-08DE39C62624", "000015", "PhysicianSurgeon", "Occurrence", 112232.0),
            new AppInfo ("AA8A585A-1890-4BCE-8465-08DE39C62624", "000016", "PhysicianSurgeon", "Occurrence", 33324.0),
            new AppInfo ("4AAA2C09-2340-4256-8466-08DE39C62624", "000017", "PhysicianSurgeon", "Occurrence", 14755.0),
            new AppInfo ("21B076D9-DE83-49C5-8467-08DE39C62624", "000018", "PhysicianSurgeon", "Occurrence", 19646.0),

            new AppInfo ("AB52F7BD-4535-4281-8468-08DE39C62624", "000019", "HealthCareProfessional", "ClaimsMade", 22226.0),
            new AppInfo ("87F4AF12-2EAE-432C-8469-08DE39C62624", "000020", "HealthCareProfessional", "ClaimsMade",  6948.0),
            new AppInfo ("8341CE50-A286-4936-846A-08DE39C62624", "000021", "HealthCareProfessional", "ClaimsMade", 19146.0),
            new AppInfo ("DD3C60C1-7C98-4A9D-846B-08DE39C62624", "000022", "HealthCareProfessional", "ClaimsMade",   741.0),
            new AppInfo ("66145BFE-A167-4248-846C-08DE39C62624", "000023", "HealthCareProfessional", "ClaimsMade",  2911.0),
            new AppInfo ("8C95CF7D-65CB-4EFE-846D-08DE39C62624", "000024", "HealthCareProfessional", "ClaimsMade", 11673.0),
            new AppInfo ("4D96F0B2-C877-4B90-846E-08DE39C62624", "000025", "HealthCareProfessional", "ClaimsMade",   454.0),
            new AppInfo ("C3C0B32F-B4E9-40D3-846F-08DE39C62624", "000026", "HealthCareProfessional", "ClaimsMade",  7111.0),

            new AppInfo ("93A0CFE1-0DC5-4286-8470-08DE39C62624", "000027", "HealthCareProfessional", "Occurrence", 170305.0),
            new AppInfo ("5E6DB52A-CEC9-4910-8471-08DE39C62624", "000028", "HealthCareProfessional", "Occurrence",    250.0),
            new AppInfo ("EE9023F5-B1F2-4878-8472-08DE39C62624", "000029", "HealthCareProfessional", "Occurrence",   8727.0),
            new AppInfo ("E9CDC541-24B3-41A5-8473-08DE39C62624", "000030", "HealthCareProfessional", "Occurrence",   1140.0),
            new AppInfo ("BFD4B9AF-A105-43BC-8474-08DE39C62624", "000031", "HealthCareProfessional", "Occurrence",  10098.0),
            new AppInfo ("8E19EB4E-08FC-4847-8475-08DE39C62624", "000032", "HealthCareProfessional", "Occurrence",  25766.0),
            new AppInfo ("DE589598-EC17-4ECE-8476-08DE39C62624", "000033", "HealthCareProfessional", "Occurrence",  16176.0),
            new AppInfo ("998F4FD7-1E89-4652-8477-08DE39C62624", "000034", "HealthCareProfessional", "Occurrence",   6512.0),

            new AppInfo ("3B56AC3E-C2D8-4BFF-ABBA-08DE3C16F58B", "000035", "FacilityAppl", "ClaimsMade",  293665.0),
            new AppInfo ("4E029343-302B-4973-ABBB-08DE3C16F58B", "000036", "FacilityAppl", "ClaimsMade",  494364.0),
            new AppInfo ("440DE8DA-FB2A-4D18-ABBC-08DE3C16F58B", "000037", "FacilityAppl", "ClaimsMade", 1152726.0),
            new AppInfo ("C1D1FF7D-23A6-4A2B-ABBD-08DE3C16F58B", "000038", "FacilityAppl", "ClaimsMade",  329997.0),
            new AppInfo ("054B1B7C-941D-4ACA-ABBE-08DE3C16F58B", "000039", "FacilityAppl", "ClaimsMade",  441797.0),
            new AppInfo ("D09A4325-2A44-46A3-ABBF-08DE3C16F58B", "000040", "FacilityAppl", "ClaimsMade",  146969.0),
            new AppInfo ("743386B9-0CA2-44FE-ABC0-08DE3C16F58B", "000041", "FacilityAppl", "ClaimsMade",  859148.0),
            new AppInfo ("2105925A-606E-4F07-ABC1-08DE3C16F58B", "000042", "FacilityAppl", "ClaimsMade",  436447.0),

            new AppInfo ("E8008350-891C-4877-ABC2-08DE3C16F58B", "000043", "FacilityAppl", "Occurrence",  349976.0),
            new AppInfo ("52284B01-BC97-4647-ABC3-08DE3C16F58B", "000044", "FacilityAppl", "Occurrence",  432568.0),
            new AppInfo ("8826C5AC-FF15-43F3-ABC4-08DE3C16F58B", "000045", "FacilityAppl", "Occurrence", 1309681.0),
            new AppInfo ("5ED666F4-B8C7-40A4-ABC5-08DE3C16F58B", "000046", "FacilityAppl", "Occurrence",  340050.0),
            new AppInfo ("FF1BD7BA-54C3-47C9-ABC6-08DE3C16F58B", "000047", "FacilityAppl", "Occurrence", 1009821.0),
            new AppInfo ("C252B600-B163-4D45-ABC7-08DE3C16F58B", "000048", "FacilityAppl", "Occurrence",  519359.0),
            new AppInfo ("02145520-557E-4E57-ABC8-08DE3C16F58B", "000049", "FacilityAppl", "Occurrence", 2045591.0),
            new AppInfo ("FC9ECF50-14E2-4489-ABC9-08DE3C16F58B", "000050", "FacilityAppl", "Occurrence",  840878.0)
        ];

        [OneTimeSetUp]
        public void Setup()
        {
            regressionStartDT = DateTime.Now;
            TestContext.Progress.WriteLine("<<< JUA Rating Engine QA Testing STARTED: " + regressionStartDT.ToString("yyyy-MM-dd HH:mm:ss") + " >>>");

            ratingEngine = new JUARatingQATesting(); // Create an instance of the JUARatingQATesting class to initialize the services
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            regressionFinishDT = DateTime.Now;
            TestContext.Progress.WriteLine("\n\n<<< JUA Rating Engine QA Testing COMPLETED: " + regressionFinishDT.ToString("yyyy-MM-dd HH:mm:ss") + " >>>");
            TestContext.Progress.WriteLine("Regression Duration: " + (regressionFinishDT - regressionStartDT).TotalMinutes.ToString("F2") + " minutes");
            regressionResult = regressionResult == "" ? "PASS: " + passCount + " / " + totalCount : "FAIL: " + failCount + " / " + totalCount;
            TestContext.Progress.WriteLine("\nQA Regression Final Result: " + regressionResult);
            TestContext.Progress.WriteLine("Detailed Result:");
            TestContext.Progress.WriteLine(regressionResultDetail);
        }

        [Theory]
        public void RatingEngineTest(AppInfo appInfo)
        {
            // Call the rateApplication method to rate the application and get the actual premium
            actualPremium = ratingEngine.RateApplication(appInfo.appId, appInfo.appNo, appInfo.categoryName, appInfo.policyType, appInfo.expectedPremium);

            // Assert that the calculated premium matches the expected premium
            Assert.That(actualPremium, Is.EqualTo(appInfo.expectedPremium), $"Application No: {appInfo.appNo}: Actual Total Premium: {actualPremium:C} Should be Equal to Expected Total Premium: {appInfo.expectedPremium:C}");

            if (actualPremium == appInfo.expectedPremium)
            {
                testResult = "PASS";
                passCount++;
                regressionResultDetail = regressionResultDetail + $"Application No {appInfo.appNo}; {testResult}; Actual Premium = Expected Premium = {actualPremium:C}\n";
            }
            else
            {
                failCount++;
                testResult = "FAIL";
                regressionResult = "FAIL: " + failCount + " / " + totalCount;
                regressionResultDetail = regressionResultDetail + $"Application No {appInfo.appNo}; {testResult}; Actual Premium = {actualPremium:C}; Expected Premium = {appInfo.expectedPremium:C}\n";
            }

            totalCount++;

        }
    }
}