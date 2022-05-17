using HiooshServer.Models;

namespace HiooshServer.Services
{
    public class ContactService : IContactsService
    {

        private static List<User> users = new List<User>();

        private User getUser(string id)
        {
            return users.Find(x => x.Id == id);
        }

        public IEnumerable<Contact> GetAllContacts(string userID)
        {
            User user = getUser(userID);
            if (user == null)
            {
                return null;
            }
            return user.Contacts;
        }


        public void AddContact(string userID, Contact contact)
        {
            User user = getUser(userID);
            user.Contacts.Add(contact);
        }

        public Contact GetContact(string userID, string contactID)
        {
            User user = getUser(userID);
            if (user.Contacts != null)
            {
                return user.Contacts.Find(x => x.id == contactID);
            }
            return null;
        }

        public void RemoveContact(string userID, string contactID)
        {
            User user = getUser(userID);
            Contact contact = GetContact(userID, contactID);
            if (contact != null)
            {
                user.Contacts.Remove(contact);
            }
            
        }
        public void UpdateContact(string userID, string contactID, string nickname, string image, List<Message> chat)
        {
            Contact contact = GetContact(userID, contactID);
            if (contact != null)
            {
                contact.name = nickname;
                contact.image = image;
                contact.chat = chat;
            }
        }

        // get the chat with the contact with this id
        public IEnumerable<Message> GetMessages(string userID, string contactID)
        {
            Contact contact = GetContact(userID, contactID);
            return contact.chat;
        }

        // add message to the chat with the contact with this id
        public void AddMessage(string userID, string contactID, Message message)
        {
            Contact contact = GetContact(userID, contactID);
            contact.chat.Add(message);
            contact.last = message.content;
            contact.lastdate = message.date;
        }
    }
}
