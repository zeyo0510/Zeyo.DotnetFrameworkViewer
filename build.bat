@echo off
set MSBuild=%windir%\Microsoft.NET\Framework\v2.0.50727\MSBuild.exe
%MSBuild% Zeyo.DotnetFrameworkViewer.csproj
pause