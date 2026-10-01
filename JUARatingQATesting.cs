using Aspose.Words.XAttr;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Pulse.Web.Data;
using Pulse.Web.Models;
using Pulse.Web.Models.RIMMJUA;
using Pulse.Web.Services;
using System.Runtime.ConstrainedExecution;

namespace Pulse.JUARatingQATesting
{
    public record AppInfo (string appId,  string appNo, string categoryName, string policyType, double expectedPremium);

    public class JUARatingQATesting
    {
        // Create an InsuranceApplicationService variable to hold the instance of the service that will be used to retrieve insurance applications from the database
        InsuranceApplicationService insAppServ;
        // Create an JUARaterService variable to hold the instance of the service that will be used to rate insurance applications
        JUARaterService appRaterServ;

        public JUARatingQATesting()
        {
            // Class Constructor, It initializes the database context and Initial services
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Data Source=sql-svr-331-621-pulse-dev-001.database.windows.net,1433;Initial Catalog=sql-db-331-621-pulse-dev-002;User ID=luis.talavera@bbrown.com;Pooling=False;Connect Timeout=30;Encrypt=True;Authentication=ActiveDirectoryInteractive;Application Name=vscode-mssql;Application Intent=ReadWrite;Command Timeout=30")
                .Options;

            // Create a factory for ApplicationDbContext
            var dbContextFactory = new PooledDbContextFactory<ApplicationDbContext>(dbOptions);
            insAppServ = new InsuranceApplicationService(
                dbContextFactory,
                new LoggerFactory().CreateLogger<InsuranceApplicationService>(),
                new ApplicationTemplateService(dbContextFactory, new LoggerFactory().CreateLogger<ApplicationTemplateService>())
            );

            // Create an instance of JUARaterService
            appRaterServ = new JUARaterService(dbContextFactory);
        }
        
        public static void Main() // string[] args The entry point where execution starts
        {
            JUARatingQATesting juaRatingQATesting = new JUARatingQATesting(); // Create an instance of the JUARatingQATesting class to initialize the services

            //              appId                                   appNo     categoryName       policyType   premium
            AppInfo[] appsInfo = [
            new AppInfo ("C94FE6C3-9160-4D8F-36B4-08DE38C84580", "000003", "PhysicianSurgeon", "ClaimsMade",  9799.0),
            new AppInfo ("0F499B5E-7CEF-41EC-8459-08DE39C62624", "000004", "PhysicianSurgeon", "ClaimsMade",  28844.0),
            new AppInfo ("252A948C-BA91-4E95-845A-08DE39C62624", "000005", "PhysicianSurgeon", "ClaimsMade",  57885.0),
            new AppInfo ("09728801-2468-4319-845B-08DE39C62624", "000006", "PhysicianSurgeon", "ClaimsMade",  43972.0),
            new AppInfo ("22EA07DC-97BD-45CA-845C-08DE39C62624", "000007", "PhysicianSurgeon", "ClaimsMade",  17542.0),
            new AppInfo ("73E76A79-A87C-4AE4-845D-08DE39C62624", "000008", "PhysicianSurgeon", "ClaimsMade",  31999.0),
            new AppInfo ("BC659C69-EB16-4760-845E-08DE39C62624", "000009", "PhysicianSurgeon", "ClaimsMade",  8036.0),
            new AppInfo ("AAD9A152-6A39-4AFA-845F-08DE39C62624", "000010", "PhysicianSurgeon", "ClaimsMade",  67939.0),

            new AppInfo ("BA3C9A21-034C-4968-8460-08DE39C62624", "000011", "PhysicianSurgeon", "Occurrence",  42542.0),
            new AppInfo ("07F582E5-475D-4A3E-8461-08DE39C62624", "000012", "PhysicianSurgeon", "Occurrence",  3980.0),
            new AppInfo ("496D8AA5-2D8D-4B89-8462-08DE39C62624", "000013", "PhysicianSurgeon", "Occurrence",  33679.0),
            new AppInfo ("68034A46-009F-4836-8463-08DE39C62624", "000014", "PhysicianSurgeon", "Occurrence",  10628.0),
            new AppInfo ("83DE5157-2B97-4238-8464-08DE39C62624", "000015", "PhysicianSurgeon", "Occurrence",  112231.0),
            new AppInfo ("AA8A585A-1890-4BCE-8465-08DE39C62624", "000016", "PhysicianSurgeon", "Occurrence",  33323.0),
            new AppInfo ("4AAA2C09-2340-4256-8466-08DE39C62624", "000017", "PhysicianSurgeon", "Occurrence",  14755.0),
            new AppInfo ("21B076D9-DE83-49C5-8467-08DE39C62624", "000018", "PhysicianSurgeon", "Occurrence",  19645.0),

            new AppInfo ("AB52F7BD-4535-4281-8468-08DE39C62624", "000019", "HealthCareProfessional", "ClaimsMade",  22225.0),
            new AppInfo ("87F4AF12-2EAE-432C-8469-08DE39C62624", "000020", "HealthCareProfessional", "ClaimsMade",  6948.0),
            new AppInfo ("8341CE50-A286-4936-846A-08DE39C62624", "000021", "HealthCareProfessional", "ClaimsMade",  19147.0),
            new AppInfo ("DD3C60C1-7C98-4A9D-846B-08DE39C62624", "000022", "HealthCareProfessional", "ClaimsMade",  741.0),
            new AppInfo ("66145BFE-A167-4248-846C-08DE39C62624", "000023", "HealthCareProfessional", "ClaimsMade",  2911.0),
            new AppInfo ("8C95CF7D-65CB-4EFE-846D-08DE39C62624", "000024", "HealthCareProfessional", "ClaimsMade",  11674.0),
            new AppInfo ("4D96F0B2-C877-4B90-846E-08DE39C62624", "000025", "HealthCareProfessional", "ClaimsMade",  454.0),
            new AppInfo ("C3C0B32F-B4E9-40D3-846F-08DE39C62624", "000026", "HealthCareProfessional", "ClaimsMade",  7111.0),

            new AppInfo ("93A0CFE1-0DC5-4286-8470-08DE39C62624", "000027", "HealthCareProfessional", "Occurrence",  170304.0),
            new AppInfo ("5E6DB52A-CEC9-4910-8471-08DE39C62624", "000028", "HealthCareProfessional", "Occurrence",  250.0),
            new AppInfo ("EE9023F5-B1F2-4878-8472-08DE39C62624", "000029", "HealthCareProfessional", "Occurrence",  8728.0),
            new AppInfo ("E9CDC541-24B3-41A5-8473-08DE39C62624", "000030", "HealthCareProfessional", "Occurrence",  1140.0),
            new AppInfo ("BFD4B9AF-A105-43BC-8474-08DE39C62624", "000031", "HealthCareProfessional", "Occurrence",  10097.0),
            new AppInfo ("8E19EB4E-08FC-4847-8475-08DE39C62624", "000032", "HealthCareProfessional", "Occurrence",  25765.0),
            new AppInfo ("DE589598-EC17-4ECE-8476-08DE39C62624", "000033", "HealthCareProfessional", "Occurrence",  16176.0),
            new AppInfo ("998F4FD7-1E89-4652-8477-08DE39C62624", "000034", "HealthCareProfessional", "Occurrence",  6512.0),

            new AppInfo ("3B56AC3E-C2D8-4BFF-ABBA-08DE3C16F58B", "000035", "FacilityAppl", "ClaimsMade",  293665.0),
            new AppInfo ("4E029343-302B-4973-ABBB-08DE3C16F58B", "000036", "FacilityAppl", "ClaimsMade",  494363.0),
            new AppInfo ("440DE8DA-FB2A-4D18-ABBC-08DE3C16F58B", "000037", "FacilityAppl", "ClaimsMade",  1152728.0),
            new AppInfo ("C1D1FF7D-23A6-4A2B-ABBD-08DE3C16F58B", "000038", "FacilityAppl", "ClaimsMade",  329997.0),
            new AppInfo ("054B1B7C-941D-4ACA-ABBE-08DE3C16F58B", "000039", "FacilityAppl", "ClaimsMade",  441797.0),
            new AppInfo ("D09A4325-2A44-46A3-ABBF-08DE3C16F58B", "000040", "FacilityAppl", "ClaimsMade",  146969.0),
            new AppInfo ("743386B9-0CA2-44FE-ABC0-08DE3C16F58B", "000041", "FacilityAppl", "ClaimsMade",  859149.0),
            new AppInfo ("2105925A-606E-4F07-ABC1-08DE3C16F58B", "000042", "FacilityAppl", "ClaimsMade",  436447.0),

            new AppInfo ("E8008350-891C-4877-ABC2-08DE3C16F58B", "000043", "FacilityAppl", "Occurrence",  349976.0),
            new AppInfo ("52284B01-BC97-4647-ABC3-08DE3C16F58B", "000044", "FacilityAppl", "Occurrence",  432568.0),
            new AppInfo ("8826C5AC-FF15-43F3-ABC4-08DE3C16F58B", "000045", "FacilityAppl", "Occurrence",  1309682.0),
            new AppInfo ("5ED666F4-B8C7-40A4-ABC5-08DE3C16F58B", "000046", "FacilityAppl", "Occurrence",  340050.0),
            new AppInfo ("FF1BD7BA-54C3-47C9-ABC6-08DE3C16F58B", "000047", "FacilityAppl", "Occurrence",  1009820.0),
            new AppInfo ("C252B600-B163-4D45-ABC7-08DE3C16F58B", "000048", "FacilityAppl", "Occurrence",  519358.0),
            new AppInfo ("02145520-557E-4E57-ABC8-08DE3C16F58B", "000049", "FacilityAppl", "Occurrence",  2045594.0),
            new AppInfo ("FC9ECF50-14E2-4489-ABC9-08DE3C16F58B", "000050", "FacilityAppl", "Occurrence",  840879.0)
        ];

            // Call the rateEngineQARegression method to perform the QA testing using the predefined applications data
            juaRatingQATesting.RateEngineQARegression(appsInfo);

        }

        public void RateEngineQARegression(AppInfo[] appsInfo)
        {
            string appId, appNo, categoryName, policyType = "";
            double expectedPremium, actualPremium = 0.0;
            string testResult = "";
            string regressionResult = "";
            string regressionResultDetail = "";
            int passCount = 0;
            int failCount = 0;
            int totalCount = 0;

            DateTime regressionStartDT = DateTime.Now;
            DateTime regressionFinishDT;

            Console.WriteLine("<<< JUA Rating Engine QA Testing STARTED: " + regressionStartDT.ToString("yyyy-MM-dd HH:mm:ss") + " >>>");

            int rows = appsInfo.GetLength(0);
            for (int r = 0; r < rows; r++)
            {
                appId = appsInfo[r].appId;
                appNo = appsInfo[r].appNo;
                categoryName = appsInfo[r].categoryName;
                policyType = appsInfo[r].policyType;
                expectedPremium = appsInfo[r].expectedPremium;

                // Call the rateApplication method to rate the application and get the actual premium
                actualPremium = RateApplication(appId, appNo, categoryName, policyType, expectedPremium);

                if (actualPremium == expectedPremium)
                {
                    testResult = "PASS";
                    passCount++;
                    regressionResultDetail = regressionResultDetail + $"App No {appNo};{testResult}; Actual Premium = Expected Premium = {actualPremium:C}\n";
                }
                else
                {
                    testResult = "FAIL";
                    failCount++;
                    regressionResultDetail = regressionResultDetail + $"App No {appNo};{testResult}; Actual Premium = {actualPremium:C}; Expected Premium = {expectedPremium:C}\n";
                }

                totalCount++;
            
            }

            regressionFinishDT = DateTime.Now;
            Console.WriteLine("\n\n<<< JUA Rating Engine QA Testing COMPLETED: " + regressionFinishDT.ToString("yyyy-MM-dd HH:mm:ss") + " >>>");
            Console.WriteLine("Regression Duration: " + (regressionFinishDT - regressionStartDT).TotalMinutes.ToString("F2") + " minutes");
            regressionResult = regressionResult == "" ? "PASS: " + passCount + " / " + totalCount : "FAIL: " + failCount + " / " + totalCount;
            Console.WriteLine("\nQA Regression Final Result:" + regressionResult);
            Console.WriteLine("Detailed Result:");
            Console.WriteLine(regressionResultDetail);

            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }

        public double RateApplication(string appId, string appNo, string categoryName, string policyType, double expectedPremium)
        {
            double actualPremium = 0.0;
            string testResult = "";

            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine($" Application No: '{appNo}'; Category: {categoryName}; Policy Type: {policyType}; DT: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------+");

            // Replace the string argument with a Guid for GetInsuranceApplicationByIdAsync
            // Create an InsuranceApplication variable to hold the retrieved application
            InsuranceApplication? insApp = insAppServ.GetInsuranceApplicationByIdAsync(
                Guid.Parse(appId)
            ).Result;

            if (insApp == null)
            {
                Console.WriteLine("<<<< Insurance Application Was NOT Found >>>>");
            }
            else
            {
                // Call the Rating Engine for the specific category
                switch (categoryName)
                {
                    case "PhysicianSurgeon":
                        insApp = appRaterServ.RatePhysicianSurgeonApp(insApp).Result;
                        break;

                    case "HealthCareProfessional":
                        insApp = appRaterServ.RateHealthCareProApp(insApp).Result;
                        break;

                    case "FacilityAppl":
                        insApp = appRaterServ.RateFacilityApp(insApp).Result;
                        break;

                    default:
                        Console.WriteLine("<<<< Unknown Category Name >>>>");
                        break;
                }

                // Application Info
                Console.WriteLine("Id: " + appId);
                Console.WriteLine("Category Name: " + insApp.Category?.CategoryName);
                Console.WriteLine("App #: '" + insApp.ApplicationNumber + "'");
                Console.WriteLine("Status: " + insApp.ApplicationStatus);
                Console.WriteLine("Created At: " + insApp.CreateDate?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Is Active: " + insApp.IsActive);
                Console.WriteLine("Is51PercentPracticeInstate: " + insApp.Is51PercentPracticeInstate);
                Console.WriteLine("IsGLCoverageElected: " + insApp.IsGLCoverageElected);
                Console.WriteLine("IsPartTime: " + insApp.IsPartTime);
                Console.WriteLine("Coverage From: " + insApp.CoverageFrom?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Coverage To: " + insApp.CoverageTo?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Policy Type: " + insApp.PolicyType);
                Console.WriteLine("Retro Date: " + insApp.RetroDate?.ToString("yyyy-MM-dd"));
                Console.WriteLine("IsLicenseValidated: " + insApp.IsLicenseValidated);
                Console.WriteLine("IsDiscountApproved: " + insApp.IsDiscountApproved);

                // Insured Info
                Console.WriteLine("Insured Name: " + insApp.Insured?.FirstName);
                Console.WriteLine("Insured Email: " + insApp.Insured?.Email);
                Console.WriteLine("Insured Agency Name: " + insApp.Agency?.Name);
                Console.WriteLine();

                Console.WriteLine("<< Rating Engine Output >>");
                if (categoryName != "FacilityAppl")
                {
                    // Create variables to hold the rating engine outputs for individual and facility applications
                    IndividualRatingEngineOutput? ratingEngineOutput = System.Text.Json.JsonSerializer.Deserialize<IndividualRatingEngineOutput>(json: insApp.RatingEngineOutput);

                    Console.WriteLine("Increased Limits Factor: " + ratingEngineOutput?.IncrLimitsFactor + ";" + ratingEngineOutput?.IncrLimitsFactorAmount.ToString("C"));
                    Console.WriteLine("Underwriter Debit: " + ratingEngineOutput?.UnderwriterDebit.ToString("P") + ";" + ratingEngineOutput?.UnderwriterDebitAmount.ToString("C"));
                    Console.WriteLine("Underwriter Credit: " + ratingEngineOutput?.UnderwriterCredit.ToString("P") + ";" + ratingEngineOutput?.UnderwriterCreditAmount.ToString("C"));
                    Console.WriteLine("Subtotal: ;" + ratingEngineOutput?.SubTotalAfterDebitsAndCredits.ToString("C"));

                    if (categoryName == "PhysicianSurgeon")
                    {
                        Console.WriteLine("JUA Insured Hospital: " + ratingEngineOutput?.JUAInsuredHospDiscountPercent.ToString("P") + ";" + ratingEngineOutput?.JUAInsuredHospDiscountAmount.ToString("C"));
                        Console.WriteLine("Subtotal: ;" + ratingEngineOutput?.SubTotalAfterJUAInsuredHospitalDiscount.ToString("C"));
                    };

                    if (insApp.PolicyType.ToString() == "ClaimsMade")
                    {
                        Console.WriteLine("Claims Made Discount: " + ratingEngineOutput?.ClaimsMadeDiscountPercent.ToString("P") + ";" + ratingEngineOutput?.ClaimsMadeDiscountAmount.ToString("C"));
                        Console.WriteLine("SubTotal: ;" + ratingEngineOutput?.SubTotalAfterClaimsMadeDiscount.ToString("C"));
                    };

                    Console.WriteLine("New Physician Discount: " + ratingEngineOutput?.NewPhysicianDiscountPercent.ToString("P") + ";" + ratingEngineOutput?.NewPhysicianDiscountAmount.ToString("C"));
                    Console.WriteLine("Subtotal: ;" + ratingEngineOutput?.SubTotalAfterNewPhysicianDiscount.ToString("C"));

                    Console.WriteLine("PartTime Discount: " + ratingEngineOutput?.PartTimeDiscountPercent.ToString("P") + ";" + ratingEngineOutput?.PartTimeDiscountAmount.ToString("C"));
                    Console.WriteLine("Subtotal: ;" + ratingEngineOutput?.SubTotalForRMCreditPartnershipAndCorpCalc.ToString("C"));

                    Console.WriteLine("MedIQ Credit: " + ratingEngineOutput?.MedRiskCreditPercent.ToString("P") + ";" + ratingEngineOutput?.MedRiskCreditAmount.ToString("C"));
                    Console.WriteLine("Partnership: " + ratingEngineOutput?.PartnershipPercent.ToString("P") + ";" + ratingEngineOutput?.PartnershipAmount.ToString("C"));
                    Console.WriteLine("Corporation: " + ratingEngineOutput?.CorporationPercent.ToString("P") + ";" + ratingEngineOutput?.CorporationAmount.ToString("C"));
                    Console.WriteLine("MediSpa: " + ratingEngineOutput?.MediSpaPercent.ToString("P") + ";" + ratingEngineOutput?.MediSpaAmount.ToString("C"));
                    Console.WriteLine("Personal Injury: ;" + ratingEngineOutput?.PersonalInjuryAmount.ToString("C"));
                    Console.WriteLine("EBL Premium: ;" + ratingEngineOutput?.EmployeeBenefitsAmount.ToString("C"));
                    Console.WriteLine("Gl Premium: ;" + ratingEngineOutput?.GlPremiumAmount.ToString("C"));
                    Console.WriteLine("Subtotal: ;" + ratingEngineOutput?.SubTotalForProRata.ToString("C"));

                    Console.WriteLine("Partial Year ProRata: " + ratingEngineOutput?.PartialYearProRataPercent.ToString("P") + ";" + ratingEngineOutput?.PartialYearProRataAmount.ToString("C"));
                    actualPremium = (double)(ratingEngineOutput?.TotalPremiumAmount ?? 0.0);
                }
                else
                {
                    // Create variables to hold the rating engine outputs for individual and facility applications
                    FacilityRatingEngineOutput? facilityRatingEngineOutput = System.Text.Json.JsonSerializer.Deserialize<FacilityRatingEngineOutput>(insApp.RatingEngineOutput);

                    Console.WriteLine("Facility Premium: ;" + facilityRatingEngineOutput?.FacilityPremiumAmount.ToString("C"));
                    Console.WriteLine("Underwriter Credit: " + facilityRatingEngineOutput?.UnderwriterCredit.ToString("P") + ";" + facilityRatingEngineOutput?.UnderwriterCreditAmount.ToString("C"));
                    Console.WriteLine("Underwriter Debit: " + facilityRatingEngineOutput?.UnderwriterDebit.ToString("P") + ";" + facilityRatingEngineOutput?.UnderwriterDebitAmount.ToString("C"));
                    Console.WriteLine("Subtotal: ;" + facilityRatingEngineOutput?.subTotalAfterDebitsAndCredits.ToString("C"));

                    if (insApp.PolicyType.ToString() == "ClaimsMade")
                    {
                        Console.WriteLine("Claims Made Discount: " + facilityRatingEngineOutput?.ClaimsMadeDiscountPercent.ToString("P") + ";" + facilityRatingEngineOutput?.ClaimsMadeDiscountAmount.ToString("C"));
                        Console.WriteLine("SubTotal: ;" + facilityRatingEngineOutput?.subTotalAfterClaimsMadeCredit.ToString("C"));
                    };

                    Console.WriteLine("Employee Benefits: ;" + facilityRatingEngineOutput?.EmployeeBenefitsAmount.ToString("C"));
                    Console.WriteLine("Gl Premium: ;" + facilityRatingEngineOutput?.GLPremium.ToString("C"));
                    Console.WriteLine("Underwriter Staff Debit: " + insApp.ProfessionalStaffDebit.ToString("F2") + ";" + facilityRatingEngineOutput?.ProfessionalStaffDebitAmount.ToString("C"));
                    Console.WriteLine("Subtotal for MedIQ: ;" + facilityRatingEngineOutput?.SubTotalForMedIQ.ToString("C"));
                    Console.WriteLine("Med IQ Discount: " + facilityRatingEngineOutput?.MedRiskDiscountPercentFacility.ToString("P") + ";" + facilityRatingEngineOutput?.MedRiskCreditAmount.ToString("C"));
                    Console.WriteLine("Subtotal: ;" + facilityRatingEngineOutput?.SubTotalForProRata.ToString("C"));

                    Console.WriteLine("Partial Year ProRata: " + facilityRatingEngineOutput?.PartialYearProRataPercent.ToString("P") + ";" + facilityRatingEngineOutput?.PartialYearProRataAmount.ToString("C"));
                    actualPremium = (double)(facilityRatingEngineOutput?.TotalPremiumAmount ?? 0.0);
                };

                testResult = actualPremium == expectedPremium ? "PASS" : "FAIL";
                Console.WriteLine($"Final Premium: ;{actualPremium:C}; {testResult} {(testResult != "PASS" ? "; expected premium: " + expectedPremium : "")}");
                Console.WriteLine("");
            }

            return actualPremium;

        }

        public double RateApplicationNoOutput(string appId, string appNo, string categoryName, string policyType)
        {
            double actualPremium = 0.0;

            // Replace the string argument with a Guid for GetInsuranceApplicationByIdAsync
            // Create an InsuranceApplication variable to hold the retrieved application
            InsuranceApplication? insApp = insAppServ.GetInsuranceApplicationByIdAsync(
                Guid.Parse(appId)
            ).Result;

            if (insApp == null)
            {
                Console.WriteLine("<<<< Insurance Application Was NOT Found >>>>");
            }
            else
            {
                // Call the Rating Engine for the specific category
                switch (categoryName)
                {
                    case "PhysicianSurgeon":
                        insApp = appRaterServ.RatePhysicianSurgeonApp(insApp).Result;
                        break;

                    case "HealthCareProfessional":
                        insApp = appRaterServ.RateHealthCareProApp(insApp).Result;
                        break;

                    case "FacilityAppl":
                        insApp = appRaterServ.RateFacilityApp(insApp).Result;
                        break;

                    default:
                        Console.WriteLine("<<<< Unknown Category Name >>>>");
                        break;
                }

                if (categoryName != "FacilityAppl")
                {
                    // Create variables to hold the rating engine outputs for individual and facility applications
                    IndividualRatingEngineOutput? ratingEngineOutput = System.Text.Json.JsonSerializer.Deserialize<IndividualRatingEngineOutput>(json: insApp.RatingEngineOutput);
                    actualPremium = (double)(ratingEngineOutput?.TotalPremiumAmount ?? 0.0);
                }
                else
                {
                    // Create variables to hold the rating engine outputs for individual and facility applications
                    FacilityRatingEngineOutput? facilityRatingEngineOutput = System.Text.Json.JsonSerializer.Deserialize<FacilityRatingEngineOutput>(insApp.RatingEngineOutput);
                    actualPremium = (double)(facilityRatingEngineOutput?.TotalPremiumAmount ?? 0.0);
                };

            }

            return actualPremium;

        }
    }
}