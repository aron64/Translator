# React
* Make sure the port number to in the fetch call checks out.
# C# Web Api
* Make sure the Data Source is set properly in appsettings.json
 Interface:
* POST /api/Phrase
  * Description: Send English phrase to translate
  * Request Body: Phrase item with English field
  * Response Body: Phrase item with Hungarian field
# Database
* I added the scripts that include the steps to import the data to a locally hosted MSSQL database through command line and sqlcmd utility
## A Phrase item the layers use between each other:
{<br>&nbsp;&nbsp;&nbsp;&nbsp;
     English: "",<br>&nbsp;&nbsp;&nbsp;&nbsp;
     Hungarian: "",<br>
}
