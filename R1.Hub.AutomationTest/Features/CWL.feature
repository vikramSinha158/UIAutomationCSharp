Feature: CWL

Background: User navigates to R1 Hub Page
  Given user is on R1 Hub login page
  And Select Facilty Code
  When user clicks on Patient Access link
 


Scenario: Verify filter folder in conversion Followup worklist
 Given user clicks on Conversion Followup worklist
 When user verify subfilter folder of conversion followup worklist
 Then user should be able to view following subfilter folder tree in conversion followup worklist:
 #Pending|On-Deck|I/S at Risk|E/O at Risk|Future Follow Up|Zero Balance|Supervisor Worklist|Care Coverage|BSO


 @DBConnection
Scenario Outline: Verify records in folder
    Given user clicks on Conversion Followup worklist
	When user clicks on "<FilterFolder>" filter folder
	Then user should be able to view "<FilterFolder>" filter folder
	When user connect to Tran database and fetch data from Tran database using DB query "<QueryID>"
	Then db query result count should be matched with I/S at Risk worklist count.	
	Examples:
	| FilterFolder	        | QueryID                   |
	| I/S at Risk           | CWL_433959_SQL1           |
    | E/O at Risk           | CWL_433960_SQL1           |
    | Future Follow Up      | CWL_433961_SQL1           |
    | Zero Balance          | CWL_433962_SQL1           |
    | Supervisor Worklist   | CWL_433963_SQL1           |
    | On-Deck               | CWL_433964_SQL1           |
    | BSO                   | CWL_433965_SQL1           |


@DBConnection
Scenario Outline: Verify Care Coverage filter folder and it's sub-folders
    Given user clicks on Conversion Followup worklist
	When user clicks on "<FilterFolder>" filter folder
	Then user should be able to view "<FilterFolder>" filter folder
	When user connect to Tran database and fetch data from Tran database using DB query "<QueryID>"
	Then db query result count should be matched with I/S at Risk worklist count.
    When user clicks on + button of Care Coverage filter folder
    Then following list of sub filter folders should be appear
    |SubFilterFolderDeck|SubFilterFolderPending|
    |On-Deck            |Pending               |
    When user clicks on Coveragecare  "<CoverageCareOnDeck>" sub filter folder
    Then user should be able to view "<CoverageCareOnDeck>" filter folder
    When user connect to Tran database and fetch data from Tran database using DB query "<QueryCoverageOnDeck>"
    Then db query result count should be matched with I/S at Risk worklist count.
     When user clicks on Coveragecare  "<CoverageCarePending>" sub filter folder
    Then user should be able to view "<CoverageCarePending>" filter folder
    When user connect to Tran database and fetch data from Tran database using DB query "<QueryCoveragePending>"
    Then db query result count should be matched with I/S at Risk worklist count.
	Examples:
	| FilterFolder	  | QueryID          |CoverageCareOnDeck 	|CoverageCarePending |QueryCoverageOnDeck  |QueryCoveragePending |
    | Care Coverage   | CWL_433966_SQL1  |On-Deck               |Pending	         |CWL_433966_SQL2      |CWL_433966_SQL3      |


Scenario: 433967 : Verify PFA override account should be fall in conversion followup worklist  
   Given user clicks on "R1 Detect" worklist
   And user is on R1 detect worklist
   When user open an account from worklist
   And user clicks on PFA tab
   And user clicks on override tab
   And user verify FollowUp Date field 