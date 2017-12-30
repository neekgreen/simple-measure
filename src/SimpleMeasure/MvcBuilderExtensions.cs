namespace Microsoft.Extensions.DependencyInjection
{
    using SimpleMeasure;
    
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder UseBenchmark(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(t => t.Filters.Add(typeof(BenchmarkAttribute)));
        }
    }
}