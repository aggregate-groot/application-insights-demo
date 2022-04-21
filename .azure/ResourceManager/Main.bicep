param location string = resourceGroup().location

param applicationInsightsName string = 'insights${uniqueString(resourceGroup().id)}'
param cosmosAccountName string = 'cosmos${uniqueString(resourceGroup().id)}'
param serviceBusName string =   'servicebus${uniqueString(resourceGroup().id)}'

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

resource ratingsContainer 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2021-10-15' = {
  name: '${demoDatabase.name}/Ratings'
  properties: {
    resource: {
      id: 'Ratings'
      partitionKey: {
        paths: [
          '/whiskyId'
        ]
      }
    }
  }
}

resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2021-11-01' = {
  name: serviceBusName
  location: location
  sku: {
    name: 'Basic'
    tier: 'Basic'
  }
}

resource serviceBusQueue 'Microsoft.ServiceBus/namespaces/queues@2021-11-01' = {
  name: '${serviceBusNamespace.name}/notify-rating'
}
