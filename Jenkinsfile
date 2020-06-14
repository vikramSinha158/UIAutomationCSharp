pipeline {
	agent any
	stages {
			stage("Clean Workspace")
            {
			steps{
               cleanWs()
               echo "clean workspace"
				}
			}
            stage("checkout code")
            {
				steps{
                echo "checkout branch"
                git credentialsId: '618c53ea-c4b3-42aa-b49e-ae3f08a22e34', url: 'https://bitbucket.org/r1rcm/r1-hub-uiautomation/src/', branch: 'master'
				}
			}
             stage ("Restore Packages") 
            {
			  steps{
					bat "dotnet restore"
				}
            }
            stage("Build")
            {
				steps{
                echo "workspace ${env.WORKSPACE}"
                bat "dotnet build --configuration Release"
					}
			}
			
            stage("Run: Automated Test")
            {
				steps{
					script{
					def automatedTest = "${workspace}/R1.Hub.AutomationTest/R1.Hub.AutomationTest.csproj"
					echo "Unit test location ${automatedTest}"
					bat returnStatus: true, script: "dotnet test \"${automatedTest}\" /p:CollectCoverage=true /p:CoverletOutput=TestResults/ --logger \"trx;LogFileName=UIAutomation_unitTest.trx\" "
					step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
					echo "publish Test result file"
					}
				}
			}
            stage("Publish")
            {
			steps{
					script{
					echo "${env:WORKSPACE}"
					bat "dotnet publish -o Published"   
					echo "publish sucess   ${env:WORKSPACE}\\Published"
					}
				}
			}
            stage("Create Artifact")
            {
				steps{
				def artifactLocation = "${env:WORKSPACE}\\Published"
				def artifactName = "r1-UI-Automation"
                def exportLoc = "**\\Artifact\\**\\"
                 echo "Archive Location ${artifactName}"
                /* archiveArtifacts artifacts: 'Published/*.*'  */
                zip archive: false, dir: "${artifactLocation}", glob: '', zipFile: "${artifactName}.zip"
                 echo "Artifact Build"
                
                 echo "Archive File Name ${artifactName}.zip"
                 archiveArtifacts artifacts: '**/*.zip*', onlyIfSuccessful: true
				 }
            }
            stage ("Set build result") {
				steps{
				currentBuild.result = 'SUCCESS'
				
				echo "Build Result ${currentBuild.result}"
				}
			}
            
	}
   
}