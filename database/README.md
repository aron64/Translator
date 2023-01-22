Import:
run:
 sqlcmd -S [hostname] -i init.sql
 bcp dictionary in ./data.txt -S localhost -T -d Translator -c -t\t