#!/usr/bin/env bash

LOCATION=$(dirname "${BASH_SOURCE[0]}")

az bicep build --file $LOCATION/../.azure/ResourceManager/Main.bicep --outdir $LOCATION/../.local/ARM/