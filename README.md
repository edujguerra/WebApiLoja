dotnet run
dotnet publish --os linux --arch x64 /t:PublishContainer -c Release
docker run --name webapiloja -d -p 8080:8080 webapiloja:latest