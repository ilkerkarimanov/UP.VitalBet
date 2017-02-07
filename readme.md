# Live streaming sport feed with SignalR, Web Api & Entity Framework 6 #

### Summary ###
This sample shows how to implement live streaming sports events with SignalR 2 on top of ASP.NET Web Api.

Solution implements indexing engine of xml-based feed for different kinds of sport events.

Entity Framework is used for data persistance with the additional extensions like EFUtilities to maximize performance for bulk operations.

### Solution ###
Solution | Author(s)
---------|----------
UP.VitalBet | Ilker Karimanov

### Version history ###
Version  | Date | Comments
---------| -----| --------
1.0  | February 2017 | Initial release

### Disclaimer ###
**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**


----------

# Solution Settings #
* In order to use this sample should modify connection string and app settings acording to your needs in web.config.

Code snippet:
```C#
  <connectionStrings>
    <add name="VitalBetDbContext" providerName="System.Data.SqlClient" connectionString="Server=.\SQLEXPRESS;Database=VitalBet;Integrated Security=True;" />
  </connectionStrings>
  ...
    <add key="feedClientUrl" value="http://vitalbet.net/sportxml" />
    <add key="feedApiUrl" value="http://localhost:50736/api/feeds/import" />
```


