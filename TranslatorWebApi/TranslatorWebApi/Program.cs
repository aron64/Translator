using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
/* 
 * Author: Aron Levente Hertendi
 * C# BackEnd to query and translate matching phrases from an MSSQL database
 * used>> dotnet add package Microsoft.AspNet.WebApi.Cors --version 5.2.9
 */


namespace TranslatorWebApi
{
    public class Program
    {
        public static string connstring = "Data Source=ERIN-NB;Initial Catalog=TRANSLATOR;Integrated Security=true";
        public static SqlConnection sqlConnection { get; set; }
        public static void Main(string[] args)
        {
            Program.sqlConnection = new SqlConnection(Program.connstring);
            sqlConnection.Open();
            string QueryM = "SELECT * From dictionary";
            SqlCommand cmdM = new SqlCommand(QueryM, sqlConnection);
            SqlDataReader drM = cmdM.ExecuteReader();
            string path = @".\MyTest.txt";
            
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < 5; i++)
                {
                    drM.Read();
                
                    sw.WriteLine(drM.GetValue(0) + "\t" +
                    drM.GetValue(1) + "\t" +
                    drM.GetValue(2) + "\t" +
                    drM.GetValue(3) + "\t" +
                    drM.GetValue(4));
                }
            }
            Console.WriteLine("HERE");
            CreateHostBuilder(args).Build().Run();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
