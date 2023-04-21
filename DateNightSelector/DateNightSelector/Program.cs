using DateNightSelector.Classes;
using Microsoft.Extensions.Configuration;
using System.IO;
using DateNightSelector.DAO;
using System;

namespace DateNightSelector
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            IDatesDAO datesDAO = new DatesSqlDAO(@"Server=.\SQLEXPRESS;Database=DateNight;Trusted_Connection=True;");

            UI ui = new UI(datesDAO);
            ui.Run();
        }
    }
}
