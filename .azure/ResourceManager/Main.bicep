param location string = resourceGroup().location

param applicationInsightsName string = 'insights${uniqueString(resourceGroup().id)}'

resource applicationInsights 'Microsoft.Insights/components@2018-05-01-preview' = {
  name: applicationInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}
