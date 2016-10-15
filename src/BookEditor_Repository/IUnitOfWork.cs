using System.Threading.Tasks;

namespace BookEditor_Repository
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        //here we need to add rollback
    }
}
