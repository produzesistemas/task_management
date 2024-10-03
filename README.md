# task_management
Desafio técnico Eclipseworks

* Create image docker:
  docker build -t image_docker_eclipseworks -f Dockerfile .

* Execute:
  docker run -dt -v "C:\Users\produ\vsdbg\vs2017u5:/remote_debugger:rw" -v "C:\Users\produ\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro" -v "C:\Users\produ\AppData\Roaming\Microsoft\UserSecrets:/home/app/.microsoft/usersecrets:ro" -v "C:\Users\produ\AppData\Roaming\ASP.NET\Https:/root/.aspnet/https:ro" -v "C:\Users\produ\AppData\Roaming\ASP.NET\Https:/home/app/.aspnet/https:ro" -v "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Sdks\Microsoft.Docker.Sdk\tools\linux-x64\net8.0:/VSTools:ro" -v "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\HotReload:/HotReloadAgent:ro" -v "C:\projetos\eclipseworks\TaskManagement:/app:rw" -v "C:\projetos\eclipseworks\TaskManagement:/src/:rw" -v "C:\Users\produ\.nuget\packages:/.nuget/fallbackpackages2:rw" -v "C:\Program Files (x86)\Microsoft Visual Studio\Shared\NuGetPackages:/.nuget/fallbackpackages:rw" -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true" -e "ASPNETCORE_ENVIRONMENT=Development" -e "DOTNET_USE_POLLING_FILE_WATCHER=1" -e "NUGET_PACKAGES=/.nuget/fallbackpackages2" -e "NUGET_FALLBACK_PACKAGES=/.nuget/fallbackpackages;/.nuget/fallbackpackages2" -P --name TaskManagement --entrypoint dotnet taskmanagement:dev --roll-forward Major /VSTools/DistrolessHelper/DistrolessHelper.dll --wait 


  
