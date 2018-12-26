namespace ControlGame.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
