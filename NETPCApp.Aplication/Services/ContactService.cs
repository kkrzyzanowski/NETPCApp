using AutoMapper;
using NETPCApp.Application.DTOs;
using NETPCApp.Application.Interfaces;
using NETPCApp.Domain.IRepositories;
using NETPCApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETPCApp.Infrastructure.Services
{
    /// <summary>
    /// Contact CRUD service
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository repository, IAuthService authService, IUserRepository userRepository, IMapper mapper)
        {
            _contactRepository = repository;
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync()
        {
            try
            {
                var contacts = await _contactRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ContactDTO>>(contacts);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Get all contacts failed");
            }
        }

        public async Task<ContactDTO> GetContactByIdAsync(int id)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(id);
                var contactDto = _mapper.Map<ContactDTO>(contact);
                return contactDto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Get Contact failed with id: {id}");
            }
        }

        public async Task AddContactAsync(ContactDTO contactDTO)
        {
            var existingUser = await _userRepository.GetByEmailAsync(contactDTO.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User exists");
            }
            try
            {
                var contact = _mapper.Map<User>(contactDTO);
                contact.PasswordHash = _authService.HashPassword(contactDTO.Password);
                await _contactRepository.AddAsync(contact);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Add Contact failed");
            }
        }

        public async Task UpdateContactAsync(int id, ContactDTO contactDTO)
        {
            var currentContact = await _contactRepository.GetByIdAsync(id);
            if (currentContact == null)
            {
                throw new InvalidOperationException($"No data with id: {id}");
            }

            try
            {
                _mapper.Map(contactDTO, currentContact);

                if (currentContact.PasswordHash != contactDTO.Password)
                {
                    if (currentContact.PasswordHash.Length >= 8)
                        currentContact.PasswordHash = _authService.HashPassword(contactDTO.Password);
                    else
                        throw new InvalidOperationException("Password is too short");
                }
                await _contactRepository.UpdateAsync(currentContact);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Update contact with id {id} failed");
            }
        }

        public async Task DeleteContactAsync(int id)
        {
            try
            {
                await _contactRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Delete contact with id {id} failed");
            }
        }
    }
}
