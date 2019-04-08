# Cake.AppVeyor
A set of aliases for http://cakebuild.net to access the AppVeyor API

![AppVeyor](https://ci.appveyor.com/api/projects/status/github/redth/Cake.AppVeyor)

You can easily reference Cake.AppVeyor directly in your build script via a cake addin:

```csharp
#addin nuget:?package=Cake.AppVeyor
#addin nuget:?package=Refit&version=4.6.58
#addin nuget:?package=Newtonsoft.Json&version=11.0.2
```

NOTE: It's very important at this point in time to specify the `Newtonsoft.Json` package *and* the version _11.0.2_ for it, as well as the `Refit` package *and* the version _4.6.58_ for it.


## Aliases

Please visit the Cake Documentation for a list of available aliases:

[http://cakebuild.net/dsl/appveyor](http://cakebuild.net/dsl/appveyor)

## Apache License 2.0
Apache Cake.Json Copyright 2016. The Apache Software Foundation This product includes software developed at The Apache Software Foundation (http://www.apache.org/).