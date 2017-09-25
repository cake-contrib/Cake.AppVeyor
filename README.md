# Cake.AppVeyor
A set of aliases for http://cakebuild.net to access the AppVeyor API

![AppVeyor](https://ci.appveyor.com/api/projects/status/github/redth/Cake.AppVeyor)

You can easily reference Cake.AppVeyor directly in your build script via a cake addin:

```csharp
#addin nuget:?package=Cake.AppVeyor
#addin nuget:?package=Refit&version=3.0.0
#addin nuget:?package=Newtonsoft.Json&version=9.0.1
```

NOTE: It's very important at this point in time to specify the `Newtonsoft.Json` package *and* the version _9.0.1_ for it, as well as the `Refit` package *and* the version _3.0.0_ for it.


## Aliases

Please visit the Cake Documentation for a list of available aliases:

[http://cakebuild.net/dsl/appveyor](http://cakebuild.net/dsl/appveyor)

## Apache License 2.0
Apache Cake.Json Copyright 2016. The Apache Software Foundation This product includes software developed at The Apache Software Foundation (http://www.apache.org/).