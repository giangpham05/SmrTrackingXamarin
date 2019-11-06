using CSharpFunctionalExtensions;
using SMR.Tracking.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace SMR.Tracking.DataAccess
{
    public class CloudRepository
    {
        private readonly CloudDbContext context;

        public CloudRepository(CloudDbContext context) => this.context = context;

        public async Task<Result> AddDefect(Defect defect)
        {
            try
            {
                context.Defects.Include(d => d.At);
                context.Add(defect);
                await context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        #region Dictionary
        public async Task<Result<T>> GetDictionaryAsync<T>(Guid id) where T : BaseDictionary
        {
            try
            {
                var result = await context.Set<T>().FindAsync(id);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Failure<T>(ex.Message);
            }
        }

        public async Task<Result<T>> AddDictionaryAsync<T>(T dictionary) where T : BaseDictionary
        {
            if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));

            try
            {
                context.Set<T>().Add(dictionary);
                await context.SaveChangesAsync();
                return Result.Ok(dictionary);
            }
            catch (Exception ex)
            {
                return Result.Failure<T>(ex.Message);
            }
        }

        public async Task<Result<T>> UpdateDictionarAsync<T>(T dictionary) where T : BaseDictionary
        {
            if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));

            try
            {
                // dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                context.Set<T>().Attach(dictionary);
                context.Entry(dictionary).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Result.Ok(dictionary);
            }
            catch (Exception ex)
            {
                return Result.Failure<T>(ex.Message);
            }
        }

        public async Task<Result> DeleteDictionaryAsync<T>(Guid id) where T : BaseDictionary
        {
            try
            {
                return await GetDictionaryAsync<T>(id).Tap(foundItem =>
                {
                    context.Set<T>().Remove(foundItem);
                    context.SaveChangesAsync();
                });
            }
            catch (Exception ex)
            {
                return Result.Failure<T>(ex.Message);
            }
        }

        public async Task<Result> BulkCreateDictionariesAsync<T>(List<T> dictionaries) where T : BaseDictionary
        {
            try
            {
                foreach (var dictionary in dictionaries) context.Set<T>().Add(dictionary);
                await Task.WhenAll(context.SaveChangesAsync());
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Failure<T>(ex.Message);
            }
        }
        #endregion
    }
}
