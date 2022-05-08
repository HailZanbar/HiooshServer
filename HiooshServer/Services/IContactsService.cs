using HiooshServer.Models;
namespace HiooshServer.Services
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetAllContacts();
        void AddContact(Contact contact);
    }
}
