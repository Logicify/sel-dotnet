How to publish new release
==========================

* cd to this folder
* Edit spec file: .spec
* run to build nuget package
``` 
nuget pack SimpleExpressionLanguage.csproj -Prop Configuration=Release
```
* publish it to NuGet repo (if you have Api token set):
```
nuget push SimpleExpressionLanguage.1.0.0.0.nupkg
```

Note: Before publishing the package you need to set your API key (could be found on your NuGet profile page)"
```
nuget setApiKey Your-API-Key
```