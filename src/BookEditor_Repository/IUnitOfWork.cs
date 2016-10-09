namespace BookEditor_Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        //here we need to add rollback
    }
}
