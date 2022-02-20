using Helmes.Shared.Model;

namespace Helmes.WebApi.Service
{
    /// <summary>
    /// Service to get User relevatnt data from storage
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Create new User based on Used Validations
        /// </summary>
        Task CreateAsync(User? user);

        /// <summary>
        /// Returns signle user with id or null if no entry was found
        /// </summary>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>
        /// Update user entry (exept ID)
        /// </summary>
        Task UpdateAsync(User user);

        /// <summary>
        /// Return list of all Sectors
        /// </summary>
        Task<List<Sectors>> GetSectorsAsync();
    }
}
