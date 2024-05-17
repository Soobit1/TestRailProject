using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Models;

namespace TestRailProject.Services
{
    public interface ITestSuitesService
    {
        Task<TestSuite> GetSuite(int suiteId);
        Task<TestSuite> GetSuites(int projectId);
        Task<TestSuite> AddSuite(TestSuite suite, int projectId);
        Task<TestSuite> UpdateSuite(TestSuite suite, int suiteId);
        HttpStatusCode DeleteSuite(int suiteId);
    }
}
