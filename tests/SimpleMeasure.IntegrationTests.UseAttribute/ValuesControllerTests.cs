namespace SimpleMeasure.IntegrationTests.UseAttribute
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;

    public class ValuesControllerTests
    {
        private const string RequestUrl = "/api/values/";
        private const string BenchmarkHeaderKey = "x-time-elapsed";

        private readonly TestServer testServer;

        public ValuesControllerTests()
        {
            testServer =
                new TestServer(
                    new WebHostBuilder().UseStartup<Startup>());
        }

        private async Task<HttpResponseMessage> MakeRequest()
        {
            return await testServer.CreateClient().GetAsync(RequestUrl);
        }

        [Fact]
        public async Task ShouldContainHeaderKey()
        {
            var response = await MakeRequest();
            var header = 
                response.Headers.FirstOrDefault(t => t.Key == BenchmarkHeaderKey);

            Assert.True(header.Value != null);
        }

        [Fact]
        public async Task ShouldContainTimeGreaterThanZero()
        {
            var response = await MakeRequest();
            var header = 
                response.Headers.FirstOrDefault(t => t.Key == BenchmarkHeaderKey);

            Assert.True(TimeSpan.Parse(header.Value.First()).TotalMilliseconds > 0);
        }
    }
}