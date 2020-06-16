Feature: Additional MSP call on adding CPT codes

Background: User navigates to R1 Hub Page
  Given user is on R1 Hub login page
  # And user is on home page of the application
  And Select Facilty Code

@tag1
Scenario: Validate entries in R1Necessity tab when CPT codes are added on the account
	When user navigates to the Patient Access > Preregistrations worklist
    And user open any account with "Medicare" coverage with passed status
    And user clicks on complete button
    And R1Necesity tab is enabled on the account
    When user navigates to the services tab
    And user adds CPT code on the account
    And user clicks on complete button 
    Then An entry should get inserted into the R1Necessity tab for each CPT code being added

Scenario: Validate entries in R1Necessity tab when CPT codes are added on the account with non-medicare coverage
    When user navigates to the Patient Access > Preregistrations worklist
    And user open any account with "NonMedicare" coverage with passed status
    And user clicks on complete button
    When user navigates to the services tab
    And user adds CPT code on the account
    And user clicks on complete button 
    And User Clic on Continue button
    Then R1Necesity tab should not get displayed on the account

Scenario: Validate entries in R1Necessity tab when Diagnosis codes are added on the account with medicare coverage
    When user navigates to the Patient Access > Preregistrations worklist
    And user open any account with "Medicare" coverage with passed status
    And user clicks on complete button
    And R1Necesity tab is enabled on the account
    When user navigates to the services tab
    And user adds diagnosis code on the account
    And user clicks on complete button 
    And User Clic on Continue button
    Then entry should not get inserted into the R1Necessity tab

