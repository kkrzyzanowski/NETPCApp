using NETPCApp.Application.DTOs;

namespace NETPCApp.Application.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(int id);
        Task AddContactAsync(ContactDTO contact);
        Task UpdateContactAsync(int id, ContactDTO contact);
        Task DeleteContactAsync(int id);
    }
}
