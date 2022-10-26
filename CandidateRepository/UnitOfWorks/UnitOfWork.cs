using CandidateCore.UnitOfWorks;

namespace CandidateRepository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly CondidateDbContext _context;
        public UnitOfWork(CondidateDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

