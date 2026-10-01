Feature: PulseJUASurveyJSAPIs

Test the Pulse JUA SurveyJS APIs Using BDD and Data Driven Testing

Background: 
    Given Pulse JUA SurveyJS APIs does Not need Authentication
    And Response type is <startOfURL>
    When Middle Of URL = <middleOfURL> And End of URL = <endOfURL> And AuxiliaryDescription = <auxDescription>
    Then Expected Status Code should be equal to <expectedStatusCode> And Expected Array should be equal to <expectedArray> And Expected Length should be equal to <expectedLenght> and Expected 1st element should be equal to <expected1st> And Expected Last element should be equal to <expectedLast>

    @Specialties
    Scenario Outline: 1-Get-Specialties
        Examples:
        | startOfURL   | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st                                                                                     | expectedLast                                                                                |
        | "Specialties | ""          | ""       | "All"          |                200 | true          |            217 | {"id": "616ffb04-515a-4159-87e0-c8d62bde09ce","name": "Active U.S. Military", "code": "80172A"} | {"id": "017111ac-b5a2-4cee-b969-719116ac0039", "name": "X-Ray Technician", "code": "80713"} |

    @appSpecialties
    Scenario Outline: 2-Get-appSpecialties
        Examples:
        | startOfURL            | middleOfURL                            | endOfURL              | auxDescription      | expectedStatusCode | expectedArray | expectedLenght | expected1st | expectedLast |
        | "uiSectionSpecialties | "0c355626-9dfc-4942-a0d0-6ac8673887c8" | "PhysicianInTraining" | "Physician Surgeon" | 200 | true  | 3   | {"id": "35687134-2386-478f-b142-1e228f9e8733", "name": "Physician In Training - Fellow", "code": "80100C"} | {"id": "5d514bed-f305-4d8b-9975-8e3e6f5f5919", "name": "Physician In Training - Resident", "code": "80100B"} |
        | "uiSectionSpecialties | "0c355626-9dfc-4942-a0d0-6ac8673887c8" | "NewSpecialties"      | "Physician Surgeon" | 200 | true  | 13  | {"id": "3eb6b0df-c988-4bf9-86c4-4897798dfa31", "name": "Diagnostic X-Ray Tech", "code": "80148C"} | {"id": "4fd05efd-d6a2-4b86-b45a-ba4ab55bce72", "name": "Radioactive Isotopes", "code": "80165B"} |
        | "uiSectionSpecialties | "0c355626-9dfc-4942-a0d0-6ac8673887c8" | "Other"               | "Physician Surgeon" | 200 | true  | 101 | {"id": "616ffb04-515a-4159-87e0-c8d62bde09ce", "name": "Active U.S. Military", "code": "80172A"} | {"id": "9e71b96f-2e93-492c-8228-d16b984b2e4a", "name": "Vascular Surgery", "code": "80146"} |
        | "uiSectionSpecialties | "1f216994-30d8-4207-aac4-3a6f8b073dac" | "Other"         | "Healthcare Professional" | 404 | false | 10  | {"response": "No Results"} | {"response": "No Results"} |
    
    @appSpecialties
    Scenario Outline: 3-Get-uiSectionSpecialties
        Examples:
        | startOfURL       | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st | expectedLast |
        | "appSpecialties" | "Facility"  | ""       | ""             | 200 | true | 217 | {"id": "616ffb04-515a-4159-87e0-c8d62bde09ce","name": "Active U.S. Military", "code": "80172A"} | {"id": "11ff9650-82ea-4fa5-9ed3-e6f8476ba219", "name": "X-Ray Therapy Technician/Radiological Physicist", "code": "80714B"} |
        | "appSpecialties" | "HealthcarePro" | ""   | ""             | 200 | true | 217 | {"id": "616ffb04-515a-4159-87e0-c8d62bde09ce","name": "Active U.S. Military", "code": "80172A"} | {"id": "11ff9650-82ea-4fa5-9ed3-e6f8476ba219", "name": "X-Ray Therapy Technician/Radiological Physicist", "code": "80714B"} |
        | "appSpecialties" | "Physician"   | ""     | ""             | 200 | true | 217 | {"id": "616ffb04-515a-4159-87e0-c8d62bde09ce","name": "Active U.S. Military", "code": "80172A"} | {"id": "11ff9650-82ea-4fa5-9ed3-e6f8476ba219", "name": "X-Ray Therapy Technician/Radiological Physicist", "code": "80714B"} |
    
    @CGLItems
    Scenario Outline: 4-Get-CGLItems
        Examples:
        | startOfURL | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st | expectedLast |
        | "CGLItems" | ""          | ""       | "All"          | 200                | true          | 35             | {"id": "7d0113a8-4b39-403a-8146-2f4b2fd2fa10", "description": "Apartment Building", "code": "60010", "cglpBase": "Per unit"} | {"id": "10ee4b48-a61b-47f7-8caa-ddb496ceeb0c", "description": "Vacant Land", "code": "49451",        "cglpBase": "Per Acre"} |
        | "CGLItems" | ""          | ""       | "Item 1"       | 200                | true          | 1              | {"id": "7d0113a8-4b39-403a-8146-2f4b2fd2fa10", "description": "Apartment Building", "code": "60010", "cglpBase": "Per unit"} | {"id": "7d0113a8-4b39-403a-8146-2f4b2fd2fa10", "description": "Apartment Building", "code": "60010", "cglpBase": "Per unit"} |
        | "CGLItems" | ""          | ""       | "Item N"       | 200                | true          | 1              | {"id": "10ee4b48-a61b-47f7-8caa-ddb496ceeb0c", "description": "Vacant Land",        "code": "49451", "cglpBase": "Per Acre"} | {"id": "10ee4b48-a61b-47f7-8caa-ddb496ceeb0c", "description": "Vacant Land", "code": "49451",        "cglpBase": "Per Acre"} |
    
    @facilityprofession
    Scenario Outline: 5-Get-facilityprofession
        Examples:
        | startOfURL           | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st                                                                             | expectedLast                                                          |
        | "facilityprofession" | ""          | ""       | "              |                200 | true          |             21 | {"id": "cce71498-7f78-4b28-b5cb-055416bdbb3f", "description": "Laboratory Technicians"} | {"id": "7ca1129d-75ed-4339-822a-feec8de33247", "description": "None"} |
    
    @Limits
    Scenario Outline: 6-Get-Limits
        Examples:
        | startOfURL | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st                                                                                  | expectedLast                                                                                 |
        | "Limits"   | ""          | ""       | ""             | 200                | true          | 4              | {"id": "0df31c69-3331-4852-8a2f-2ed566ca6831", "limit": "$1,000,000/$3,000,000", "code": 72} | {"id": "57d14107-a022-4afb-8d13-fdbff68dc1e9", "limit": "$1,000,000/$3,000,000", "code": 72} |
    
    @States
    Scenario Outline: 7-Get-States
        Examples:
        | startOfURL | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st                      | expectedLast                              |
        | "States"   | ""          | ""       | ""             |                200 | true          |             60 | {"name": "", "abbreviation": ""} | {"name": "Wyoming", "abbreviation": "WY"} |
    
    @Zips
    Scenario Outline: 8-Get-Zips
        Examples:
        | startOfURL | middleOfURL | endOfURL | auxDescription | expectedStatusCode | expectedArray | expectedLenght | expected1st                                                                        | expectedLast                                                                       |
        | "Zips"     | ""          | ""       | ""             |                200 | true          |             90 | {"id": "79b53343-a2d5-40ee-8ad0-001b306a87a6", "territory": "501", "zip": "02940"} | {"id": "fd4ef366-1425-42b1-8a26-f38e98c1b200", "territory": "503", "zip": "02842"} |
