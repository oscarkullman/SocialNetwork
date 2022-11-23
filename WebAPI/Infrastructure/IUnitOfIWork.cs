namespace WebAPI.Infrastructure
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
