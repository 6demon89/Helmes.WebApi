
/// <summary>
/// Used for injection of the EndPoints mapping
/// </summary>
public interface IEndpointDefinition
{
    /// <summary>
    /// provides service configurations option
    /// </summary>
    void DefineServices(IServiceCollection services);

    /// <summary>
    /// Provides mapping cabalities
    /// </summary>
    void DefineEndpoints(WebApplication app);
}
