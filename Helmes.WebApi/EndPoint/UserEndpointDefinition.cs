using Helmes.Shared.Model;
using Helmes.WebApi.Service;

namespace Helmes.WebApi.EndPoint
{
    public class UserEndpointDefinition : IEndpointDefinition
    {
        /// <summary>
        /// API Routing Map
        /// </summary>
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/sectors", GetSectorsAsync);
            app.MapGet("/user/{id}", GetUserByIdAsync);
            app.MapPost("/user", CreateUserAsync);
            app.MapPut("/user/{id}", UpdateUserAsync);
        }

        /// <summary>
        /// Attempt to return all sectors from Storage. If no Sectors were found, returns NotFound
        /// </summary>
        internal async Task<IResult> GetSectorsAsync(IUserService service)
        {
            var sectors = await service.GetSectorsAsync();
            return sectors is not null ? Results.Ok(sectors) : Results.NotFound();
        }

        /// <summary>
        /// Attempt to return User with specific ID from Storage. In case user was not found, returns NotFound
        /// </summary>
        internal async Task<IResult> GetUserByIdAsync(IUserService service, Guid id)
        {
            var user = await service.GetByIdAsync(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        }

        /// <summary>
        /// Attempt to create user with based on user validation rules.
        /// if user was not provided,user validation rules failed or user already exsists with id - return BadRequest;
        /// </summary>
        /// <returns>Created user</returns>
        internal async Task<IResult> CreateUserAsync(IUserService service, User user)
        {
            if (user is null) return Results.BadRequest();
            if (!user.IsValid()) return Results.BadRequest();
            if (await service.GetByIdAsync(user.ID) != null) return Results.BadRequest();
            await service.CreateAsync(user);
            return Results.Created($"/user/{user.ID}", user);
        }

        /// <summary>
        /// Attempt to update user with provided ID and user model;
        /// if user was not provided or user validation rules failed - return BadRequest;
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"> Id of user to be updated</param>
        /// <param name="updateduser">user model</param>
        /// <returns>OK update user</returns>
        internal async Task<IResult> UpdateUserAsync(IUserService service, Guid id, User updateduser)
        {
            if (updateduser is null) return Results.BadRequest();
            if (!updateduser.IsValid()) return Results.BadRequest();
            var user = await service.GetByIdAsync(id);
            if (user is null) return Results.NotFound();
            await service.UpdateAsync(updateduser);
            return Results.Ok(updateduser);
        }

        /// <summary>
        /// defines the service for IUserService
        /// </summary>
        /// </summary>
        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
