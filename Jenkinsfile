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
            
	}
   
}