using HiooshServer.Models;
namespace HiooshServer.Services
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetAllContacts();
        void AddContact(Contact contact);
        void RemoveContact(string id);
        Contact GetContact(string id);
        void UpdateContact(string id, string nickname, string image, List<Message> chat);
        IEnumerable<Message> getMessages(string id);
        void addMessage (string id, Message message);

    }
}
