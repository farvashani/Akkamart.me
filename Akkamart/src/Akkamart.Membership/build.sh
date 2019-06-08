#!/usr/bin/env bash


dotnet restore
dotnet build
##dotnet publish
dotnet publish --configuration Release --no-restore --output ./dist /p:PublishWithAspNetCoreTargetManifest="false"
