using WebApiBackgroudServices.Domain;

namespace WebApiBackgroudServices.Repository
{
    public interface ICommandRepository
    {
        public string? GetMessage();
        public void SetMessage(Message message);
    }
}