namespace BiogenomTestResults;

public class AppConfig
{
    public ConnectionStringsConfig ConnectionStrings { get; set; } = null!;

    public AppConfig(WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        configuration.AddEnvironmentVariables();

        configuration.Bind(this);
    }
}

public class ConnectionStringsConfig
{
    public string DefaultConnection { get; set; }
}