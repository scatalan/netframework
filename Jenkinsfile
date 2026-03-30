pipeline {
    agent any

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Solution') {
            steps {
                bat '''
                "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe" net48\\net48.sln /p:Configuration=Release
                '''
            }
        }

        stage('Build Unit Tests') {
            steps {
                bat '''
                "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe" UnitTestProject\\UnitTestProject.csproj /p:Configuration=Release
                '''
            }
        }

        stage('Run Unit Tests') {
            steps {
                bat '''
                "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\Extensions\\TestPlatform\\vstest.console.exe" ^
                UnitTestProject\\bin\\Release\\UnitTestProject.dll ^
                /logger:trx
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: '**/*.trx', allowEmptyArchive: true
        }
        failure {
            echo '❌ Unit tests failed'
        }
        success {
            echo '✅ Unit tests passed'
        }
    }
}