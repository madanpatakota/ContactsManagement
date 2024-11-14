using ContactsManagement.Models;
using ContactsManagement.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManagement.Services
{
    public class ContactsService
    {
        private readonly ContactsRepository _repository;

        public ContactsService(ContactsRepository repository)
        {
            _repository = repository;
        }

        // Get all contacts
        public List<Contact> GetAllContacts() => _repository.GetAllContacts();

        // Get a contact by Id
        public Contact GetContactById(int id) =>
            _repository.GetAllContacts().FirstOrDefault(c => c.Id == id);

        // Add a new contact
        public bool AddContact(Contact contact)
        {
            var contacts = _repository.GetAllContacts();
            if (contacts.Any(c => c.Id == contact.Id || c.Email == contact.Email))
                return false; // Check if ID or Email already exists

            contact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
            contacts.Add(contact);
            _repository.SaveContacts(contacts);
            return true;
        }

        // Update an existing contact
        public bool UpdateContact(int id, Contact updatedContact)
        {
            var contacts = _repository.GetAllContacts();
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null) return false; // Contact not found

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            _repository.SaveContacts(contacts);
            return true;
        }

        // Delete a contact by Id
        public bool DeleteContact(int id)
        {
            var contacts = _repository.GetAllContacts();
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            contacts.Remove(contact);
            _repository.SaveContacts(contacts);
            return true;
        }
    }
}
