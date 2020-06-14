pipeline {
	timestamps
{
    node()
    {
        def projectVersion
        catchError
        {
            stage('Clean Workspace')
            {
               cleanWs()
               echo "clean workspace"
            }
            stage('checkout code')
            {
                echo "checkout branch"
                git credentialsId: '618c53ea-c4b3-42aa-b49e-ae3f08a22e34', url: 'https://bitbucket.org/r1rcm/r1-hub-uiautomation/src/', branch: 'master'
            }
             stage('Set project version')
            {
                projectVersion =".${env.BUILD_NUMBER}"
                echo "Project version ${projectVersion}"
            }
             stage ('Restore Packages') 
            {
        
            bat "dotnet restore"
       
            }
            stage('Build')
            {
                echo "workspace ${env.WORKSPACE}"
                bat "dotnet build --configuration Release"
            }
            def automatedTest = "${workspace}/R1.Hub.AutomationTest/R1.Hub.AutomationTest.csproj"
            stage('Run: Automated Test')
            {
            
              echo "Unit test location ${automatedTest}"
                bat returnStatus: true, script: "dotnet test \"${automatedTest}\" /p:CollectCoverage=true /p:CoverletOutput=TestResults/ --logger \"trx;LogFileName=UIAutomation_unitTest.trx\" "
                step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
                echo "publish Test result file"
            }
             stage('Publish')
            {
                echo "${env:WORKSPACE}"
                bat "dotnet publish -o Published"   
                echo "publish sucess   ${env:WORKSPACE}\\Published"
            }
            
            def artifactLocation = "${env:WORKSPACE}\\Published"
            def artifactName = "r1-UI-Automation ${projectVersion}"
            stage('Create Artifact')
            {
                def exportLoc = "**\\Artifact\\**\\"
                 echo "Archive Location ${artifactName}"
                /* archiveArtifacts artifacts: 'Published/*.*'  */
                zip archive: false, dir: "${artifactLocation}", glob: '', zipFile: "${artifactName}.zip"
                 echo "Artifact Build"
                
                 echo "Archive File Name ${artifactName}.zip"
                 archiveArtifacts artifacts: '**/*.zip*', onlyIfSuccessful: true
            }
            stage ('Set build result') {
				currentBuild.result = 'SUCCESS'
				
				echo "Build Result ${currentBuild.result}"
			}
            
        }
        
    
    }
}
}