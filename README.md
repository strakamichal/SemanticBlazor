# ![SemanticBlazor](/src/SemanticBlazor/Files/semblazor-logo.jpg)
SemanticBlazor is implementation of Semantic UI components for Blazor.

[![GitHub Stars](https://img.shields.io/github/stars/strakamichal/SemanticBlazor.svg?style=for-the-badge)](https://github.com/strakamichal/SemanticBlazor/stargazers)
[![GitHub Issues](https://img.shields.io/github/issues/Strakamichal/SemanticBlazor.svg?style=for-the-badge)](https://github.com/SamProf/MatBlazor/issues)
[![Live Demo](https://img.shields.io/badge/demo-online-green.svg?style=for-the-badge)]([https://](http://semblazor.azurewebsites.net))
[![MIT](https://img.shields.io/github/license/SamProf/MatBlazor.svg?style=for-the-badge)](LICENSE)

**Latest versions:**

[![NuGet](https://img.shields.io/nuget/v/SemanticBlazor.svg?style=for-the-badge)](https://www.nuget.org/packages/SemanticBlazor/)
[![NuGet](https://img.shields.io/nuget/vpre/SemanticBlazor.svg?style=for-the-badge)](https://www.nuget.org/packages/SemanticBlazor/)

## Live demo
* [SemBlazor.azurewebsite.com - Documentation and live demo website of tha latest stable release.](http://semblazor.azurewebsites.net)
* [SemBlazor-dev.azurewebsite.com - Live demo website of the prerelease version.](http://semblazor-dev.azurewebsites.net)

### What si Semantic UI ###
User Interface is the language of the web.

[More about Semantic UI](https://semantic-ui.com)

### What si Blazor ###
  Blazor lets you build interactive web UIs using C# instead of JavaScript. Blazor apps are composed of reusable web UI components implemented using C#, HTML, and CSS. Both client and server code is written in C#, allowing you to share code and libraries.

  Blazor is a feature of ASP.NET, the popular web development framework that extends the .NET developer platform with tools and libraries for building web apps.

[More about Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)

## Prerequisites
- .NET Core 3.1.8
- Any .NET Core developer IDE (Visual Studio, VS Code...)

## Installation 
**Nuget Package**
```
Install-Package MatBlazor
```
or 
```
dotnet add package MatBlazor
```

**_Imports.razor**
```
@using SemanticBlazor
@using SemanticBlazor.Components
@using SemanticBlazor.Models
```

**Link static CSS and JS files (_Host.cshtml)**

```
<script src="~/_content/SemanticBlazor/modules/jquery/jquery.min.js"></script>
<script src="~/_content/SemanticBlazor/modules/semantic/semantic.min.js"></script>
<link href="~/_content/SemanticBlazor/modules/semantic/semantic.min.css" rel="stylesheet" />
<script src="~/_content/SemanticBlazor/modules/semantic/calendar.min.js"></script>
<link href="~/_content/SemanticBlazor/modules/semantic/calendar.min.css" rel="stylesheet" />
<link href="~/_content/SemanticBlazor/SemanticBlazor.css" rel="stylesheet" />
<script src="~/_content/SemanticBlazor/SemanticBlazor.js"></script>
```

## Usage

```
<SemButton OnClick="DoSomething">Click me!</SemButton>
```

### [Please find more examples at the website...](http://semblazor.azurewebsites.net) ###
