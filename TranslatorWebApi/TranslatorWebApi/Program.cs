using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
/* 
 * Author: Aron Levente Hertendi
 * C# BackEnd to query and translate matching phrases from an MSSQL database
 * used>> dotnet add package Microsoft.AspNet.WebApi.Cors --version 5.2.9
 */


namespace TranslatorWebApi
{
    public class Program
    {
        SqlConnection sqlConnection;
        public static void Main(string[] args)
        {
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
