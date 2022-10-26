namespace CandidateCore.UnitOfWorks
{
    public interface IUnitOfWork
    {

        Task CommitAsync();
        void Commit();
    }
}
