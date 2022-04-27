# Application Insights Demo

## Prerequisites

1. [Microsoft Azure Account](https://azure.microsoft.com/en-us/free/)
2. [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)
3. [Azure Bicep](https://docs.microsoft.com/en-us/azure/azure-resource-manager/bicep/install)
4. [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/)

## Kusto Queries

### Request Density per Second

```kusto
requests
| summarize totalCount=sum(itemCount) by bin(timestamp, 1s)
| where timestamp > datetime(2022-04-25 04:40:00Z) and timestamp < datetime(2022-04-26 04:45:00Z)
| order by timestamp
| render timechart
```

[More Samples](https://docs.microsoft.com/en-us/azure/data-explorer/kusto/query/samples?pivots=azuredataexplorer)

## Reference

- [Overview](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)
- [ASP.NET Core](https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core)