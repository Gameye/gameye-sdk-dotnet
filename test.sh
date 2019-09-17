#!/bin/sh

dotnet test ./src -c Release

echo -e "\e[32mTests complete!"