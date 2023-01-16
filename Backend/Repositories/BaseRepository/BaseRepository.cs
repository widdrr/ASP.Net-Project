using Backend.Data;
using Backend.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly GameStoreContext _context;
        protected readonly DbSet<TEntity> _table;

        public BaseRepository(GameStoreContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _table.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
