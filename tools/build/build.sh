#!/bin/bash

dotnet build --configuration Release
dotnet pack ExcelChangeHandler/ExcelChangeHandler.csproj --configuration Release
