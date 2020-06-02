#!/bin/bash

./BuildTools/UpdateVersion.sh

dotnet build --configuration Release
dotnet pack CSharpExcelChangeLogger/CSharpExcelChangeHandler.csproj --configuration Release
