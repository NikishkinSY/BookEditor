# BookEditor

Simple web-application which describe relationships between books and authors.

## Technologies: 
 - Back-end Techs: ASP.NET Core 1.0.1, Entity Framework Core, Dependency Injection, MS SQL, Automapper.
 - Back-end Patterns/Principles: MVC, WebApi, IoC, Repository, UnitOfWork, async/await.
 - Fron-end Techs: Angular 1.5, JQuery, Bootstrap, ([angular-base64-upload](https://github.com/adonespitogo/angular-base64-upload), [angularjs-dropdown-multiselect](http://dotansimha.github.io/angularjs-dropdown-multiselect/#/)).
 - Fron-end Enviroment: nmp, gulp.
 - Fron-end Patterns/Principles: IIFE, SPA, [johnpapa guid](https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md).
 - Common approaches: SOLID, DRY.

## Prerequisites:
 - Visual Studio 2015 Update 3. 
 - MS SQL server (express) 2008R2+.
 - .Net Core.
 - IISExpress 10.

## Before run solution:
 - In projects src/BookEditor_Web in appsettings.json you need to write correct sql connection string.
 - Restore Nuget packeges if needed.
 - Restore nmp packeges if needed.
 
## Faced issues:
 - EF core still has some problems with many-to-many relationships, but it solved by custom way.
 - Libraries (xUnit, Unit Test) for unit and integrations tests still do not support newest .net core 1.0. ([xUnit](http://xunit.github.io/docs/getting-started-dotnet-core.html)). Without tests :(
 - Module for angular ([angularjs-dropdown-multiselect](http://dotansimha.github.io/angularjs-dropdown-multiselect/#/)) has issue with event (onUnselectAll), it does not fire. It is to late to search new one :( but others work fine :)

## Other:
 - Only 'jpg' images are supported.

## Future improvements:
 - Separate images to different table in database with type and name.
 - Extend web error codes.
 - Web improvements: concatinations, minifications js & css, use less preprocessor.
 - Move from Angular 1.5 to 2.0 and use TypeScript (but it is disputable issue according to too new and "wet" technology as well as ASP.NET Core).
 - Add tests to back-end and frond-end.
 - I would be glad to use Angular Material insted of bootstrap (or with) and webpack ensted of gulp.
 
