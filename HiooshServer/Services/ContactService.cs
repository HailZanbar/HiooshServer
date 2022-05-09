using HiooshServer.Models;

namespace HiooshServer.Services
{
    public class ContactService : IContactsService
    {

        private static List<Contact> contacts = new List<Contact>();
        public IEnumerable<Contact> GetAllContacts()
        {
            return contacts;
        }


        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        Contact GetContact(string id)
        {
            if (contacts != null)
            {
                return contacts.Find(x => x.Id == id);
            }
            return null;
        }

        void RemoveContact(string id)
        {
            Contact contact = GetContact(id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            
        }
        void UpdateContact(string id, string nickname, string image, List<Message> chat)
        {
            Contact contact = GetContact(id);
            if (contact != null)
            {
                contact.Nickname = nickname;
                contact.image = image;
                contact.Chat = chat;
            }

        }
    }
}
