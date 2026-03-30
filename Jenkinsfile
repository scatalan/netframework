pipeline {
    agent { label 'windows' }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build net48') {
            steps {
                bat '''
                "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe" net48\\net48.sln
                '''
            }
        }
    }
}