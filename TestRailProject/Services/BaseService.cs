using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Clients;

namespace TestRailProject.Services;

public class BaseService
{
    private RestClientExtended _client;

    public BaseService(RestClientExtended client)
    {
        _client = client;
    }
}