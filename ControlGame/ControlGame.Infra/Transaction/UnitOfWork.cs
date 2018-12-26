using ControlGame.Infra.Persistence;

namespace ControlGame.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private ControlGameContext _context { get; set; }

        public UnitOfWork(ControlGameContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
