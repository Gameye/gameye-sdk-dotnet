#!/bin/sh
./test.sh

dotnet clean ./src/clients/Gameye.Sdk.csproj
dotnet build ./src/clients/Gameye.Sdk.csproj -c Release
dotnet pack ./src/clients/Gameye.Sdk.csproj -c Release -o ../../artifacts

echo -e "\e[32mBuild complete!"