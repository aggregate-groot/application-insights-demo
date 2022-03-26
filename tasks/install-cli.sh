#!/usr/bin/env bash

dotnet build ../src/Client/Client.csproj -c Release
dotnet tool update --global --add-source ../src/Client/bin/Release/ AggregateGroot.ApplicationInsightsDemo.Client