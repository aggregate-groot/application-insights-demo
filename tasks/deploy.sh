#!/usr/bin/env bash

LOCATION=$(dirname "${BASH_SOURCE[0]}")
BICEP_FILE=$LOCATION/../.azure/ResourceManager/Main.bicep
RESOURCE_GROUP=Application-Insights-Demo

az bicep build --file $BICEP_FILE --outdir $LOCATION/../.local/ARM/

az group create --name $RESOURCE_GROUP --location EastUS

az deployment group create \
    --resource-group $RESOURCE_GROUP \
    --template-file $BICEP_FILE \