param location string = resourceGroup().location

param applicationInsightsName string = 'insights${uniqueString(resourceGroup().id)}'
param cosmosAccountName string = 'cosmos${uniqueString(resourceGroup().id)}'

resource applicationInsights 'Microsoft.Insights/components@2018-05-01-preview' = {
  name: applicationInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}

resource cosmosAccount 'Microsoft.DocumentDB/databaseAccounts@2021-10-15' = {
  name: cosmosAccountName
  location: location
  properties: {
    locations: [
      {
        locationName: location
        failoverPriority: 0
      }
    ]
    databaseAccountOfferType: 'Standard'
    capabilities: [
      {
        name: 'EnableServerless'
      }
    ]
  }
}

resource demoDatabase 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2021-10-15' = {
  name: '${cosmosAccount.name}/ApplicationInsightsDemo'
  properties: {
      resource: {
          id: 'ApplicationInsightsDemo'
      }
  }
}

resource whiskiesContainer 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2021-10-15' = {
  name: '${demoDatabase.name}/Whiskies'
  properties: {
      resource: {
          id: 'Whiskies'
          partitionKey: {
              paths: [
                  '/brand'
              ]
          }
      }
  }
}
