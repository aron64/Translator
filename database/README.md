# Run in cmd to create DB and import data:
 * sqlcmd -S [hostname] -i init.sql
 * bcp dictionary in ./data.txt -S localhost -T -d Translator -c -t\t
