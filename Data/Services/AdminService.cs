﻿using ComputerStoreWebApi.Data.Models;
using ComputerStoreWebApi.Data.ViewModel;

namespace ComputerStoreWebApi.Data.Services
{
    public class AdminService
    {
        private AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;
        }
         
        public void AddAdmin(AdminVM admin)
        {
            var _admin = new Admin()
            {
                UserName = admin.UserName,
                Password = admin.Password,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                ImageUrl = admin.ImageUrl,
                PhoneNumber = admin.PhoneNumber,
                DateOfBirth = DateTime.Now
            };
            _context.Admin.Add(_admin);
            _context.SaveChanges(); 
        }

        public List<Admin> GetAdminList() => _context.Admin.ToList();

        public Admin GetAdminById(int AdminId) => _context.Admin.FirstOrDefault(n => n.Id == AdminId);

        public Admin UpdateAdminById(int adminId, AdminVM admin )
        {
            var _admin = _context.Admin.FirstOrDefault(n => n.Id == adminId);
            if(_admin != null)
            {
                _admin.UserName = admin.UserName;
                _admin.Password = admin.Password;
                _admin.FirstName = admin.FirstName;
                _admin.LastName = admin.LastName;
                _admin.Email = admin.Email;
                _admin.ImageUrl = admin.ImageUrl;
                _admin.PhoneNumber = admin.PhoneNumber;
                _admin.DateOfBirth = DateTime.Now;
                _context.SaveChanges();
            };
            return _admin;
        }
        public void DeleteAdminById(int adminId)
        {
            var admin = _context.Admin.FirstOrDefault(n => n.Id == adminId);
            _context.Admin.Remove(admin);
            _context.SaveChanges();
        }
    }
}