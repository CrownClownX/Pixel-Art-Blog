# Pixel Art Blog
Pixel Art Blog is simple CMS created with ASP.NET MVC5.  

## Table of contents
* [Status](#status)
* [Technologies](#technologies)
* [Setup](#setup)
* [Features](#features)


## Status
Project still requires some changes, mostly with error management on frontend. 


## Technologies
* ASP.NET MVC 5
* Entity Framework 6 
* Jquery 1.10.2


## Setup
To make contact form working application require additional setting file. It should look like this:
  <appSettings>
    <add key="mailAccount" value="example@email.com" />
    <add key="mailPassword" value="ExamplePassword" />
    <add key="host" value="smtp.gmail.com" />
    <add key="port" value="587" />
    <add key="enableSsl" value="true" />
  </appSettings>
File must have extension .config. Path to file is defined in web.config in section appSettings: 
  <appSettings file="..\..\appsettings.config">
Field file should be change to match path of new appsettings file.


## Features
List of features ready and TODOs for future development
* Main Panel - starting point of application. This is very most recent posts are displayed alongside with additional info
* Post Panel - basicly list of posts. Posts are paginate on the server and can be filtrated by categories.
* Admin Panel - this is were all magic happens. To get here admin must be logged. After that all CRUD operation are avaible to use.




