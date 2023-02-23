namespace RecruitmentPlatform.Data.IGenericRepository
{
    public interface IGenericRepository <T>
    {
        Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(long id,T entity);
        public Task<bool> DeleteAsync(long id);
        public Task<T> GetByIdAsync(long id);
        public Task<List<T>> GetAllAsync();
    }
}
