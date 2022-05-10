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

        public Contact GetContact(string id)
        {
            if (contacts != null)
            {
                return contacts.Find(x => x.Id == id);
            }
            return null;
        }

        public void RemoveContact(string id)
        {
            Contact contact = GetContact(id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            
        }
        public void UpdateContact(string id, string nickname, string image, List<Message> chat)
        {
            Contact contact = GetContact(id);
            if (contact != null)
            {
                contact.Nickname = nickname;
                contact.image = image;
                contact.Chat = chat;
            }
        }

        // get the chat with the contact with this id
        public IEnumerable<Message> GetMessages(string id)
        {
            Contact contact = GetContact(id);
            if (contacts != null)
            {
                return contact.Chat;
            }
            return null;
        }

        // add message to the chat with the contact with this id
        public void AddMessage(string id, Message message)
        {
            Contact contact = GetContact(id);
            if (contacts != null)
            {
                contact.Chat.Add(message);
            }
        }
    }
}
