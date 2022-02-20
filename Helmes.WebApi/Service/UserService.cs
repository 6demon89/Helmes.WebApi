using Helmes.Shared.Model;
using Helmes.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace Helmes.WebApi.Service
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        public UserService(DatabaseContext context) => _context = context;

        /// <summary>
        /// Helper method to assing Sector entities to user
        /// </summary>
        /// <exception cref="ArgumentException">User was requesting sector which does not exsist</exception>
        private async Task AssignSecotrsToUser(User user)
        {
            List<Sectors> sectorsList = new List<Sectors>();

            foreach (var item in user.Sectors)
            {
                var sector = await _context.Sectors.FindAsync(item.SectorID);
                if (sector is null)
                    throw new ArgumentException("Requested Sector was not found");
                sectorsList.Add(sector);
            }
            user.Sectors = sectorsList;
        }

        /// <summary>
        /// Creates new user entry and map between Sectors
        /// </summary>
        /// <returns>User model with ID</returns>
        /// <exception cref="ArgumentNullException">provided user argument is null</exception>
        public async Task CreateAsync(User? user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            await AssignSecotrsToUser(user);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns user including selected sectors with provided id without tracking
        /// </summary>
        public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.Include(x => x.Sectors)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.ID == id);

        /// <summary>
        /// Provides list of all Sectors
        /// </summary>
        public async Task<List<Sectors>> GetSectorsAsync() => await _context.Sectors.ToListAsync();

        /// <summary>
        /// Update user entry. Note that user has to exsist. Otherwise no update will be provided
        /// </summary>
        public async Task UpdateAsync(User user)
        {
            await AssignSecotrsToUser(user);
            var _ = await _context.Users.FindAsync(user.ID);
            if (_ is not null)
                _context.Entry(_).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }

    }
}
