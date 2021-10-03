02oct21

simple project to make sense of .net framework [ pka core, x-platform ] 6.0 release story for implementation of webapi  

https://dotnet.microsoft.com/download/dotnet/6.0 | windows | installers | x64 -> dotnet-sdk-6.0.100-rc.1.21463.6-win-x64.exe
https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new | web & webapi  
https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package | /list/remove package Swashbuckle.AspNetCore  
https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference | /list/remove package &lt;project name&gt;.csproj  
  
using .net 6 dotnet new webapi ->   
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api ->  
the swagger page is at /swagger/index.html, e.g. http://localhost:5199/swagger/index.html  
and example webapi is at /WeatherForecast, e.g. http://localhost:5199/WeatherForecast  
  
asp<span></span>.net core 6 minimal api ->  
aug 05, 2021 https://hanselman.com/blog/exploring-a-minimal-web-api-with-aspnet-core-6  
https://github.com/anuraj/MinimalApi?WT.mc_id=-blog-scottha
https://github.com/davidfowl/Minimal-API-.NET-6-Example?WT.mc_id=-blog-scottha
https://github.com/davidfowl/CommunityStandUpMinimalAPI?WT.mc_id=-blog-scottha
https://github.com/martincostello/dotnet-minimal-api-integration-testing?WT.mc_id=-blog-scottha

asp<span></span>.net core 6 app.MapGet arguments -> 
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing
https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-rc-1/

.net core history -> https://dotnet.microsoft.com/platform/support/policy/dotnet-core & https://en.wikipedia.org/wiki/.NET#History

http://localhost:5038/swagger/index.html
http://localhost:5038/api/values  
http://127.0.0.1:5038/api/values  
http://192.168.4.33:5038/api/values -- doesn't work because asp.net development web server is by design limited to localhost/127.0.0.1 connections  
http://192.168.4.33:8080/api/values -- works provided you have applied the following settings that enable port forwarding / proxy configuration  

access asp<span></span>.net development web server from subnet -> https://stackoverflow.com/questions/1730280/accessing-asp-net-development-server-from-another-pc-on-the-network  
- netsh interface portproxy add v4tov4 listenport=&lt;tcp port for non-localhost access allowed/enabled in windows firewall&gt; listenaddress=0.0.0.0 &lt; or windows wired/wifi ipaddress &gt; connectport=&lt;tcp port for localhost access to asp<span></span>.net development web server&gt; connectaddress=localhost, e.g. netsh interface portproxy add v4tov4 listenport=4430 listenaddress=0.0.0.0 connectport=7146 connectaddress=localhost & netsh interface portproxy add v4tov4 listenport=8080 listenaddress=0.0.0.0 connectport=5038 connectaddress=localhost & netsh interface portproxy show all [ & for %i in ( 4430, 8080 ) do ( netsh interface portproxy delete v4tov4 listenport=%i listenaddress=0.0.0.0 ) ]  
+ netsh advfirewall firewall add rule name="Asp<span></span>.Net Development Web Server Listeners to Expose" dir=in protocol=tcp localport=&lt;csv list of tcp ports allowed/enabled in windows firewall&gt; profile=private|any remoteip=localsubnet|any action=allow [ enable=yes ], e.g. netsh advfirewall firewall add rule name="Asp<span></span>.Net Development Web Server Listeners to Expose" dir=in protocol=tcp localport=4430,8080 profile=private remoteip=localsubnet action=allow & netsh advfirewall firewall show rule name="Asp<span></span>.Net Development Web Server Listeners to Expose" [ or wf.msc | inbound rules & netsh advfirewall firewall delete rule name="Asp<span></span>.Net Development Web Server Listeners to Expose" ]


access wsl service ports from subnet -> https://youtu.be/yCK3easuYm4&t=7m10s @ 3m + 5m48s + 7m10s 
- netsh interface portproxy add v4tov4 listenport=&lt;tcp port allowed/enabled in windows firewall&gt; listenaddress=0.0.0.0 connectport=&lt;tcp port wsl service listening on&gt; connectaddress=&lt;wsl instance ifc eth0 not windows ifc wsl gw address&gt;, e.g. for %i in ( 7146, 5038 ) do ( netsh interface portproxy add v4tov4 listenport=%i listenaddress=0.0.0.0 connectport=%i connectaddress=172.21.56.235 ) & netsh interface portproxy show all [ & for %i in ( 7146, 5038 ) do ( netsh interface portproxy delete v4tov4 listenport=%i listenaddress=0.0.0.0 ) ]  
+ netsh advfirewall firewall add rule name="Wsl Listeners to Expose" dir=in protocol=tcp localport=&lt;csv list of tcp ports allowed/enabled in windows firewall&gt; profile=any remoteip=any action=allow enable=yes, e.g. netsh advfirewall firewall add rule name="Wsl Listeners to Expose" dir=in protocol=tcp localport=7146,5038 profile=any remoteip=any action=allow enable=yes & netsh advfirewall firewall show rule name="Wsl Listeners to Expose" [ or wf.msc | inbound rules & netsh advfirewall firewall delete rule name="Wsl Listeners to Expose" ]  

- .net package restore error NU1100: Unable to resolve -> https://stackoverflow.com/questions/68283730/error-nu1100-unable-to-resolve-microsoftofficecore-15-0-0-for-net5-0  

- should you add .vscode to gitignore -> https://stackoverflow.com/questions/32964920/should-i-commit-the-vscode-folder-to-source-control -> https://gitignore.io | visualstudiocode | create  

