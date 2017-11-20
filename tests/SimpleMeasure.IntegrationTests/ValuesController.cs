namespace SimpleMeasure.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SimpleMeasure;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [Benchmark, HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}