#!/bin/bash

./BuildTools/UpdateVersion.sh

dotnet build --configuration Release
dotnet pack CSharpExcelChangeLogger/CSharpExcelChangeLogger.csproj --configuration Release
