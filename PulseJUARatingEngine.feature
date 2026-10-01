Feature: PulseJUARatingEngine

Test the JUA Rating Engine Using BDD and Data Driven Testing

Rule: I have a PhysicianSurgeon Application
    Background: 
    Given A Medical Insurance Application was created in Pulse JUA with category PhysicianSurgeon

    @PhysicianSurgeon
    @ClaimsMade
    Scenario Outline: 1-PhysicianSurgeon-Claimsmade
        Given Policy type is Claimsmade
        When the Application is Rated with appNo = <appNo> and appId = <appId>
        Then the calculated Premium for appNo = <appNo> should be equal to <expectedPremium>

        Examples:
            | appNo    | expectedPremium  | appId                                  |
            | "000003" |           9799.0 | "C94FE6C3-9160-4D8F-36B4-08DE38C84580" |
            | "000004" |          28844.0 | "0F499B5E-7CEF-41EC-8459-08DE39C62624" |
            | "000005" |          57885.0 | "252A948C-BA91-4E95-845A-08DE39C62624" |
            | "000006" |          43972.0 | "09728801-2468-4319-845B-08DE39C62624" |
            | "000007" |          17542.0 | "22EA07DC-97BD-45CA-845C-08DE39C62624" |
            | "000008" |          31999.0 | "73E76A79-A87C-4AE4-845D-08DE39C62624" |
            | "000009" |           8036.0 | "BC659C69-EB16-4760-845E-08DE39C62624" |
            | "000010" |          67939.0 | "AAD9A152-6A39-4AFA-845F-08DE39C62624" |

    @PhysicianSurgeon
    @Occurrence
    Scenario Outline: 2-PhysicianSurgeon-Occurrence
        Given Policy type is Occurrence
        When the Application is Rated with appNo = <appNo> and appId = <appId>
        Then the calculated Premium for appNo = <appNo> should be equal to <expectedPremium>

        Examples:
            | appNo    | expectedPremium | appId                                  |
            | "000011" |         42542.0 | "BA3C9A21-034C-4968-8460-08DE39C62624" |
            | "000012" |          3980.0 | "07F582E5-475D-4A3E-8461-08DE39C62624" |
            | "000013" |         33679.0 | "496D8AA5-2D8D-4B89-8462-08DE39C62624" |
            | "000014" |         10628.0 | "68034A46-009F-4836-8463-08DE39C62624" |
            | "000015" |        112231.0 | "83DE5157-2B97-4238-8464-08DE39C62624" |
            | "000016" |         33323.0 | "AA8A585A-1890-4BCE-8465-08DE39C62624" |
            | "000017" |         14755.0 | "4AAA2C09-2340-4256-8466-08DE39C62624" |
            | "000018" |         19645.0 | "21B076D9-DE83-49C5-8467-08DE39C62624" |


Rule: A Medical Insurance Application was created in Pulse JUA with category HealthCareProfessional
    Background: 
    Given A Medical Insurance Application was created in Pulse JUA with category HealthCareProfessional

    @HealthCareProfessional
    @ClaimsMade
    Scenario Outline: 3-HealthCareProfessional-Claimsmade
        Given Policy type is Claimsmade
        When the Application is Rated with appNo = <appNo> and appId = <appId>
        Then the calculated Premium for appNo = <appNo> should be equal to <expectedPremium>

        Examples:
            | appNo    | expectedPremium | appId                                  |
            | "000019" |         22225.0 | "AB52F7BD-4535-4281-8468-08DE39C62624" |
            | "000020" |          6948.0 | "87F4AF12-2EAE-432C-8469-08DE39C62624" |
            | "000021" |         19147.0 | "8341CE50-A286-4936-846A-08DE39C62624" |
            | "000022" |           741.0 | "DD3C60C1-7C98-4A9D-846B-08DE39C62624" |
            | "000023" |          2911.0 | "66145BFE-A167-4248-846C-08DE39C62624" |
            | "000024" |         11674.0 | "8C95CF7D-65CB-4EFE-846D-08DE39C62624" |
            | "000025" |           454.0 | "4D96F0B2-C877-4B90-846E-08DE39C62624" |
            | "000026" |          7111.0 | "C3C0B32F-B4E9-40D3-846F-08DE39C62624" |

    @HealthCareProfessional
    @Occurrence
    Scenario Outline: 4-HealthCareProfessional-Occurrence
        Given Policy type is Occurrence
        When the Application is Rated with appNo = <appNo> and appId = <appId>
        Then the calculated Premium for appNo = <appNo> should be equal to <expectedPremium>

        Examples:
            | appNo    | expectedPremium | appId                                  |
            | "000027" |        170304.0 | "93A0CFE1-0DC5-4286-8470-08DE39C62624" |
            | "000028" |           250.0 | "5E6DB52A-CEC9-4910-8471-08DE39C62624" |
            | "000029" |          8728.0 | "EE9023F5-B1F2-4878-8472-08DE39C62624" |
            | "000030" |          1140.0 | "E9CDC541-24B3-41A5-8473-08DE39C62624" |
            | "000031" |         10097.0 | "BFD4B9AF-A105-43BC-8474-08DE39C62624" |
            | "000032" |         25765.0 | "8E19EB4E-08FC-4847-8475-08DE39C62624" |
            | "000033" |         16176.0 | "DE589598-EC17-4ECE-8476-08DE39C62624" |
            | "000034" |          6512.0 | "998F4FD7-1E89-4652-8477-08DE39C62624" |


Rule: A Medical Insurance Application was created in Pulse JUA with category FacilityAppl
    Background: 
    Given A Medical Insurance Application was created in Pulse JUA with category FacilityAppl

    @FacilityAppl
    @ClaimsMade
    Scenario Outline: 5-FacilityAppl-Claimsmade
        Given Policy type is Claimsmade
        When the Application is Rated with appNo = <appNo> and appId = <appId>
        Then the calculated Premium for appNo = <appNo> should be equal to <expectedPremium>

        Examples:
            | appNo    | expectedPremium | appId                                  |
            | "000035" |        293665.0 | "3B56AC3E-C2D8-4BFF-ABBA-08DE3C16F58B" |
            | "000036" |        494363.0 | "4E029343-302B-4973-ABBB-08DE3C16F58B" |
            | "000037" |       1152728.0 | "440DE8DA-FB2A-4D18-ABBC-08DE3C16F58B" |
            | "000038" |        329997.0 | "C1D1FF7D-23A6-4A2B-ABBD-08DE3C16F58B" |
            | "000039" |        441797.0 | "054B1B7C-941D-4ACA-ABBE-08DE3C16F58B" |
            | "000040" |        146969.0 | "D09A4325-2A44-46A3-ABBF-08DE3C16F58B" |
            | "000041" |        859149.0 | "743386B9-0CA2-44FE-ABC0-08DE3C16F58B" |
            | "000042" |        436447.0 | "2105925A-606E-4F07-ABC1-08DE3C16F58B" |

    @FacilityAppl
    @Occurrence
    Scenario Outline: 6-FacilityAppl-Occurrence
        Given Policy type is Occurrence
        When the Application is Rated with appNo = <appNo> and appId = <appId>
        Then the calculated Premium for appNo = <appNo> should be equal to <expectedPremium>

        Examples:
            | appNo    | expectedPremium | appId                                  |
            | "000043" |        349976.0 | "E8008350-891C-4877-ABC2-08DE3C16F58B" |
            | "000044" |        432568.0 | "52284B01-BC97-4647-ABC3-08DE3C16F58B" |
            | "000045" |       1309682.0 | "8826C5AC-FF15-43F3-ABC4-08DE3C16F58B" |
            | "000046" |        340050.0 | "5ED666F4-B8C7-40A4-ABC5-08DE3C16F58B" |
            | "000047" |       1009820.0 | "FF1BD7BA-54C3-47C9-ABC6-08DE3C16F58B" |
            | "000048" |        519358.0 | "C252B600-B163-4D45-ABC7-08DE3C16F58B" |
            | "000049" |       2045594.0 | "02145520-557E-4E57-ABC8-08DE3C16F58B" |
            | "000050" |        840879.0 | "FC9ECF50-14E2-4489-ABC9-08DE3C16F58B" |
