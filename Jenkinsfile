pipeline {
    agent any

    environment {
        MSBUILD  = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"
        VSTEST   = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\Extensions\\TestPlatform\\vstest.console.exe"
        MSDEPLOY = "C:\\Program Files\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe"
        PUBLISH_DIR = "${WORKSPACE}\\bin\\app.publish"
        IIS_SITE = "TestJenkins"
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Solution') {
            steps {
                bat """
                "${MSBUILD}" net48\\net48.sln /p:Configuration=Release
                """
            }
        }

        stage('Build Unit Tests') {
            steps {
                bat """
                "${MSBUILD}" UnitTestProject\\UnitTestProject.csproj /p:Configuration=Release
                """
            }
        }

        stage('Run Unit Tests') {
            steps {
                bat """
                "${VSTEST}" UnitTestProject\\bin\\Release\\UnitTestProject.dll /logger:trx
                """
            }
        }

        stage('Publish') {
            steps {
                bat """
                "${MSBUILD}" net48\\net48.csproj ^
                  /p:DeployOnBuild=true ^
                  /p:PublishProfile=FolderProfile ^
                  /p:PublishDir="${PUBLISH_DIR}"
                """
            }
        }

        stage('Deploy IIS (local)') {
            steps {
                bat """
                "${MSDEPLOY}" ^
                  -verb:sync ^
                  -source:contentPath="${PUBLISH_DIR}" ^
                  -dest:contentPath="${IIS_SITE}" ^
                  -enableRule:AppOffline ^
                  -disableLink:AppPoolExtension
                """
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: '**/*.trx', allowEmptyArchive: true
        }
        success {
            echo '✅ Deploy completado correctamente en IIS'
        }
        failure {
            echo '❌ Pipeline falló'
        }
    }
}