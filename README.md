# Webir Project

## Software Requirements

* Net Core 2.2
* SQLServer 2017

# Create DataBase 
Official docs at https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/

## Visual Studio
Run "Update-Database" in Package Manager Console over "Common" project.

## Command Line
Run "netcore ef update database" over "/Repositories" directory.

### Important
In file /Repositories/Model/DbContext/ContextFactory.cs you must update connection string with yours.

## API usage

By default API run in localhost:[portnumber]/api

To access all quotations append "/Quotations" to URL above

To access a scpecific quotation append "/Quotations/[coinCode]", being coinCode one of the following:
* DolarUy: gets dollar quotation in Central Bank of Uruguay
* PesoArgUy: gets Peso Argentino quotation in Central Bank of Uruguay
* DolarArg: gets official dollar quotation in Central Bank of Argentina
* DolarBlue: gets Blue dollar quotation in Argentina
* Best: returns the best currency to carry on from Uruguay to Argentina

For example:
* GET localhost:[portnumber]/api/Quotations/DolarUy
