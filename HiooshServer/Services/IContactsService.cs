using HiooshServer.Models;
namespace HiooshServer.Services
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetAllContacts(string userID);
        void AddContact(string userID, Contact contact);
        void RemoveContact(string userID, string contactID);
        Contact? GetContact(string userID, string contactID);
        void UpdateContact(string userID, string contactID, string nickname, string server);
        List<Message> GetMessages(string userID, string contactID);
        void AddMessage (string userID, string contactID, Message message);
        Message? GetMessage(string userID, string contactID, int messageID);
        void RemoveMessage (string userID, string contactID, int messageID);
        void UpdateMessage (string userID, string contactID, int messageID, string content);
        List<User> GetUsers();
    }
}
