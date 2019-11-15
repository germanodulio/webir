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

### All latest quotations
To access all quotations append "/Quotations" to URL above

### Specific latest quotation
To access a scpecific quotation append "/Quotations/[coinCode]", being coinCode one of the following:
* DolarUy: gets dollar quotation in Central Bank of Uruguay
* PesoArgUy: gets Peso Argentino quotation in Central Bank of Uruguay
* DolarArg: gets official dollar quotation in Central Bank of Argentina
* DolarArgBlue: gets Blue dollar quotation in Argentina

For example:
* GET localhost:[portnumber]/api/Quotations/DolarUy

### Best quotation for a date
To get best quotation for a specific date append "/Quotations/Best/dd-MM-YYYY" being dd the day, MM the month and YYYY the year.
This method returns the best currency to carry on from Uruguay to Argentina for parameter date.

For example:
* GET localhost:[portnumber]/api/Quotations/Best/05-11-2019

### Quotations for dates range
To retrieve all quotations for a set of coins in a selected range use this method.

Format: localhost:[portnumber]/api/Quotations/range?codes=code1&codes=Code2&startTime=dd-MM-YYYY&endTime=dd-MM-YYYY

For example:
* GET localhost:[portnumber]/api/Quotations/range?codes=DolarUy&codes=DolarArg&startTime=10-04-2019&endTime=10-05-2019
