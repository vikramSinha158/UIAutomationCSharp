Feature: Additional MSP call on adding CPT codes

Background: User navigates to R1 Hub Page
  Given user is on R1 Hub login page
  # And user is on home page of the application
  And Select Facilty Code

@tag1
Scenario: Validate entries in R1Necessity tab when CPT codes are added on the account
	When user navigates to the Patient Access > Preregistrations worklist
    And user open any account with Medicare coverage with passed status

