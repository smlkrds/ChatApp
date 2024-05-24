using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Repositories.Interfaces;

namespace SignalRChat.Repositories
{
    public class BaseRepository<TEntity>(DbContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        #region Initialization

        private readonly DbContext _dbContext = context;
        private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        #endregion

        #region Methods

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbSet.ToListAsync();
            }
            return await _dbSet.Where(predicate).ToListAsync();
        }

        #endregion
    }
}
