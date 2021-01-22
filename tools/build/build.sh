#!/bin/bash

dotnet build --configuration Release
dotnet pack CSharpExcelChangeHandler/CSharpExcelChangeHandler.csproj --configuration Release
