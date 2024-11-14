using ContactsManagement.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactsManagement.Repositories
{
    public class ContactsRepository
    {
        private readonly string _filePath = "contacts.json"; // Path to JSON file

        // Get all contacts from the JSON file
        public List<Contact> GetAllContacts()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<Contact>>(jsonData) ?? new List<Contact>();
            }
            return new List<Contact>(); // Return empty list if file does not exist
        }

        // Save contacts to the JSON file
        public void SaveContacts(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData); // Write to JSON file
        }
    }
}
