Remove-Item -Recurse -ErrorAction Ignore -Force .\build
Remove-Item -Recurse -ErrorAction Ignore -Force .\package

cd (resolve-path ..\WebApplication).path
npm install
ng build --configuration production
cd (resolve-path ..\StudentCard.Deployment).path

cd (Resolve-Path ..\StudentCard.Hosting).Path
dotnet publish -c release -o ..\StudentCard.Deployment\build /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:DesktopBuildPackageLocation="..\StudentCard.Deployment\package\StudentCard.zip"
cd (Resolve-Path ..\StudentCard.Deployment).Path