# Cake.AppVeyor

A set of aliases for <http://cakebuild.net> to access the AppVeyor API

![AppVeyor](https://ci.appveyor.com/api/projects/status/github/cake-contrib/Cake.AppVeyor)

You can easily reference Cake.AppVeyor directly in your build script via a cake addin:

```csharp
#addin nuget:?package=Cake.AppVeyor
#addin nuget:?package=Refit&version=9.0.3
```

NOTE: It's very important at this point in time to specify the `Refit` package *and* the version *9.0.2* for it.

## Aliases

Please visit the Cake Documentation for a list of available aliases:

[http://cakebuild.net/dsl/appveyor](http://cakebuild.net/dsl/appveyor)

## Apache License 2.0

Apache Cake.AppVeyor Copyright 2016. The Apache Software Foundation This product includes software developed at [The Apache Software Foundation](http://www.apache.org/).

## Discussion

For questions and to discuss ideas & feature requests, use the [GitHub discussions on the Cake GitHub repository](https://github.com/cake-build/cake/discussions), under the [Extension Q&A](https://github.com/cake-build/cake/discussions/categories/extension-q-a) category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)
