namespace Service.Model.Repositories
{
    public interface IToDoRepository
    {
        public Task Remove(int orderId);
    }
}