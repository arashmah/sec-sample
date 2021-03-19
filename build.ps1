SonarScanner.MSBuild.exe begin /k:"SecSample" /d:sonar.host.url="http://localhost:9000"
MsBuild.exe /t:Rebuild
SonarScanner.MSBuild.exe end