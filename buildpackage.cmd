REM Ensure that the build directory exists, as NuGet.exe won't create it
if not exist ".\build" mkdir ".\build"

REM Remove existing NuGet files
DEL ".\build\*.nupkg"

".\tools\nuget\nuget.exe" update -self
".\tools\nuget\nuget.exe" pack ".\src\AspNetMvcSerialization\AspNetMvcDictionarySerialization.nuspec" -OutputDirectory ".\build"
".\tools\nuget\nuget.exe" pack ".\src\AspNetMvcSerialization\AspNetMvcSerialization.csproj" -Build -OutputDirectory ".\build" -Properties Configuration=Release 