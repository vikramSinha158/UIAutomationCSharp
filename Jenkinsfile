projectVersion = ''
pipeline {
	agent any
	stages {
			
			 stage("Set project version")
            {
				steps{
					script{
						projectVersion =readFile file: "version"
						projectVersion = projectVersion.trim() + ".${env.BUILD_NUMBER}"
						echo "Project version ${projectVersion}"
						}
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
				script{
				def artifactLocation = "${env:WORKSPACE}\\Published"
				def artifactName = "r1-UI-Automation ${projectVersion}"
                def exportLoc = "**\\Artifact\\**\\"
                 echo "Archive Location ${artifactName}"
                /* archiveArtifacts artifacts: 'Published/*.*'  */
                zip archive: false, dir: "${artifactLocation}", glob: '', zipFile: "${artifactName}.zip"
                 echo "Artifact Build"
                
                 echo "Archive File Name ${artifactName}.zip"
                 archiveArtifacts artifacts: '**/*.zip*', onlyIfSuccessful: true
				 }
				 }
            }
            stage ("Set build result") {
				steps{
				script{
				currentBuild.result = 'SUCCESS'
				
				echo "Build Result ${currentBuild.result}"
				}
				}
			}
            
	}
   
}