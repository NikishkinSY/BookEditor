# BookEditor

Simple web-application which describe relationships between books and authors.


## Back-end: 
 - Techs: ASP.NET Core (mainly web-api), Entity Framework Core, Dependency Injection, MS SQL.
 - Patterns/Principles: IoC, Repository, UnitOfWork.

## Fron-end:
 - Techs: Angular 1.5, JQuery, Bootstrap.
 - Enviroment: nmp, gulp.
 - Patterns: [johnpapa guid](https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md)

## Faced issues:
 - EF core still has some problems with many-to-many relationships.
 - Issue with configuration Automapper. Can't access automapper's class 'ValueResolver' in .Net Core (may be).

## Prerequisites:
 - Visual Studio 2015 Update 3. 
 - MS SQL server (express) 2008R2+.
 - .Net Core.
 - IISExpress 10.

## Before run solution:
 - In projects BookEditor_Web/BookEditor_Web in web.config you need to write correct sqlConnectionString.
 - Restore Nuget packeges if needed.
 - Restore nmp packeges if needed.
