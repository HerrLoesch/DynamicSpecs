@echo off

<<<<<<< HEAD
=======
echo.
echo Target nuget package version:
echo.
type Shared.AssemblyInfo.cs | findstr "AssemblyVersion"
echo.
pause

>>>>>>> origin/master
if "%VisualStudioVersion%"=="" call "%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\Tools\vsvars32.bat"
color

msbuild /t:Build /p:Configuration=Release /nologo /v:m
if errorlevel 1 goto ERROR

set NUGETEXE="%CD%\.nuget\nuget.exe"
set NUGETDST="%CD%"\_nuget_output
if exist %NUGETDST% rmdir %NUGETDST% /s /q
mkdir %NUGETDST%


pushd DynamicSpecs
%NUGETEXE% pack -Prop Configuration=Release -OutputDirectory %NUGETDST%
if errorlevel 1 goto error
popd

pushd AutoFacItEasy
%NUGETEXE% pack -Prop Configuration=Release -OutputDirectory %NUGETDST%
if errorlevel 1 goto error
popd

pushd MSTest\DynamicSpecs.MSTest\
%NUGETEXE% pack -Prop Configuration=Release -OutputDirectory %NUGETDST%
if errorlevel 1 goto error
popd

pushd NUnit\DynamicSpecs.NUnit\
%NUGETEXE% pack -Prop Configuration=Release -OutputDirectory %NUGETDST%
if errorlevel 1 goto error
popd





:OK
<<<<<<< HEAD
echo JOB WELL DONE
=======
echo.
echo JOB WELL DONE
echo.
>>>>>>> origin/master
pause 
exit /b

:ERROR
color 0C
<<<<<<< HEAD
echo OOPS...
=======
echo.
echo WTF?!
echo.
>>>>>>> origin/master
pause
exit /b