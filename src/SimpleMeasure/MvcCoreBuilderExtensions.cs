namespace Microsoft.Extensions.DependencyInjection
{
    using SimpleMeasure;
    
    public static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder UseBenchmark(this IMvcCoreBuilder builder)
        {
            return builder.AddMvcOptions(t => t.Filters.Add(typeof(BenchmarkAttribute)));
        }
    }
}