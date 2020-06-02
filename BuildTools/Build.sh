#!/bin/bash

./BuildTools/UpdateVersion.sh

dotnet build --configuration Release
dotnet pack CSharpExcelChangeHandler/CSharpExcelChangeHandler.csproj --configuration Release
