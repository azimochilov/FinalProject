using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RecruitmentPlatform.Data.Configurations;
using RecruitmentPlatform.Data.IGenericRepository;
using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private string Path;
        public long LastId;
        public GenericRepository()
        {
            if (typeof(T) == typeof(Adress))
            {
                Path = DatabasePath.ADRESS_PATH ;
            }
            else if (typeof(T) == typeof(Statement))
            {
                Path = DatabasePath.STATEMENT_PATH;
            }
            else if (typeof(T) == typeof(TargetAudience))
            {
                Path = DatabasePath.AUDIENCE_PATH;
            }
            else if(typeof(T) == typeof(Company)) 
            {
                Path = DatabasePath.COMPANY_PATH;
            }
            else if (typeof(T) == typeof(JobTable)) 
            {
                Path = DatabasePath.JOB_TABLE_PATH;
            }
            else
            {
                Path = DatabasePath.CV_PATH;
            }

            ConfigurateLastId();
        }
        public async void ConfigurateLastId()
        {
            foreach (var i in await GetAllAsync())
            {
                if (i.Id > LastId)
                {
                    i.Id = LastId;
                }
            }
        }


        public async Task<T> CreateAsync(T entity)
        {
            var values = await GetAllAsync();
            values.Add(entity);
            var js  = JsonConvert.SerializeObject(values,Formatting.Indented);
            await File.WriteAllTextAsync(Path, js);
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var values = await GetAllAsync();
            var value = values.FirstOrDefault(v => v.Id == id);
            if(value is null)
            {
                return false;
            }
            values.Remove(value);
            var js = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(Path, js);
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var values = await File.ReadAllTextAsync(Path);
            if(string.IsNullOrEmpty(values))
            {
                values = "[]";
            }
            var js = JsonConvert.DeserializeObject<List<T>>(values);
            return js;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var values = await GetAllAsync();
            var value = values.FirstOrDefault(v => v.Id == id);
            if(value is null)
            {
                return null;
            }
            return value;
        }

        public async Task<T> UpdateAsync(long id,T entity)
        {
            var models = await GetAllAsync();
            var updatingModel = models.FirstOrDefault(x => x.Id == entity.Id);

            if (updatingModel == null)
                return null;

            int index = models.IndexOf(updatingModel);

            models.Remove(updatingModel);
            models.Insert(index, entity);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

            return entity;
        }
    }
}
