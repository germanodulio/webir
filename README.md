# Webir Project

Software Requirements

* Net Core 2.2
* PostgreSQL 12.0 or above

Api use

By default API run in localhost:[portnumber]/api

To access all quotations append "/Quotations" to URL above

To access a scpecific quotation append "/Quotations/[coinCode]", being coinCode one of the following:
* DolarUy: gets dollar quotation in Central Bank of Uruguay
* PesoArgUy: gets Peso Argentino quotation in Central Bank of Uruguay
* DolarArg: gets official dollar quotation in Central Bank of Argentina
* DolarBlue: gets Blue dollar quotation in Argentina
* Best: returns the best currency to carry on from Uruguay to Argentina
