using WebApiBackgroudServices.Domain;

namespace WebApiBackgroudServices.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private Message _message;

        public CommandRepository()
        {
            _message = new Message
            {
                Content = "Initial command" 
            };
        }

        public string? GetMessage()
        {
            return this._message.Content;
        }

        public void SetMessage(Message message)
        {
            _message = message;
        }
    }
}