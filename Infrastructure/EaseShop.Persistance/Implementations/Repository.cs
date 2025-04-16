using System.Linq.Expressions;
using EaseShop.Domain.Common;
using EaseShop.Domain.Repositories;
using EaseShop.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace EaseShop.Persistance.Implementations;

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EaseDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(EaseDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public async Task Create(T entity)
        {
            try
            {
                var result = _context.Entry(entity);
                result.State = EntityState.Added;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                var result = _context.Entry(entity);
                result.State = EntityState.Deleted;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, bool AsnoTracking=false,bool AsSplitQuery=false, int skip = 0, int take = 0,bool isIgnoredDeleteBehaviour=false, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            try
            {
                IQueryable<T> query = _table;

                // Check if includes array is not null and has elements
                if (includes != null && includes.Length > 0)
                {
                    foreach (var include in includes)
                    {
                        query = include(query);
                    }
                }

                // Apply the predicate if provided
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                // Apply skip and take logic
                if (skip > 0)
                {
                    query = query.Skip(skip);
                }

                if (take > 0)
                {
                    query = query.Take(take);
                }

                // Execute the query and return the list
                if(AsnoTracking is true){
               query = query.AsNoTracking();
                };
                if (AsSplitQuery is true)
                {
                    query = query.AsSplitQuery();
                }
                if(!isIgnoredDeleteBehaviour is true)
                {
                    query = query.IgnoreQueryFilters();
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the full exception details for better debugging
                throw new Exception("Error in GetAll: " + ex.Message, ex);
            }
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, bool AsnoTracking = false, bool AsSplitQuery = false, int skip = 0, int take = 0, bool isIgnoredDeleteBehaviour = false, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            try
            {
                IQueryable<T> query = _table;

                // Check if includes array is not null and has elements
                if (includes != null && includes.Length > 0)
                {
                    foreach (var include in includes)
                    {
                        query = include(query);
                    }
                }

                // Apply the predicate first if provided
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (skip > 0)
                {
                    query = query.Skip(skip);
                }

                if (take > 0)
                {
                    query = query.Take(take);
                }
                if (AsnoTracking is true)
                {
                    query = query.AsNoTracking();
                };
                if (AsSplitQuery is true)
                {
                    query = query.AsSplitQuery();
                }
                if (!isIgnoredDeleteBehaviour is true)
                {
                    query = query.IgnoreQueryFilters();
                }
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetEntity: " + ex.Message, ex);
            }
        }

        public Task<IQueryable<T>> GetQuery(
      Expression<Func<T, bool>> predicate = null, bool AsnoTracking = false, bool AsSplitQuery = false,
      bool isIgnoredDeleteBehaviour = false,
      params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            try
            {
                IQueryable<T> query = _table.AsQueryable();

                if (includes != null && includes.Length > 0)
                {
                    foreach (var include in includes)
                    {
                        query = include(query);
                    }
                }

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (AsnoTracking is true)
                {
                    query = query.AsNoTracking();
                };
                if (AsSplitQuery is true)
                {
                    query = query.AsSplitQuery();
                }
                if (!isIgnoredDeleteBehaviour is true)
                {
                    query = query.IgnoreQueryFilters();
                }
                return Task.FromResult(query);
            }
            catch (Exception ex)
            {
                // Provide more detailed error information
                throw new Exception($"Error in GetQuery for type {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<bool> isExists(Expression<Func<T, bool>> predicate = null,bool AsNoTracking=false, bool isIgnoredDeleteBehaviour = false)
        {
            try
            {
                IQueryable<T> query = _table;
                if(AsNoTracking is true)
                {
                    query = query.AsNoTracking();
                }
                if (!isIgnoredDeleteBehaviour is true)
                {
                    query = query.IgnoreQueryFilters();
                }
                return predicate is null ? false : await query.AnyAsync(predicate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                var result = _context.Entry(entity);
                result.State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }