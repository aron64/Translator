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
 * added System.Data.SqlClient through NuGet
 * 
 * Make sure the ConnectionString is set properly for your environment.
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
            CreateHostBuilder(args).Build().Run();
          //  Console.WriteLine("HERE");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
