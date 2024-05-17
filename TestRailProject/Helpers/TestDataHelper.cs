using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Models;
using TestRailProject.Pages;

namespace TestRailProject.Helpers;
public static class TestDataHelper
{
    public static TestSuite AddTestSuite(string fileName)
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(assemblyPath + Path.DirectorySeparatorChar + "Resources"
                                    + Path.DirectorySeparatorChar + fileName);  //Path.Combine(assemblyPath, "Resources", fileName);
        var jsonObject = JObject.Parse(json);

        var suite = new TestSuite
        {
            Id = (int)jsonObject["id"],
            Name = (string)jsonObject["name"],
            Description = (string)jsonObject["project_id"],
            Announcement = (string)jsonObject["announcment"]
        };

        return suite;
    }
}
