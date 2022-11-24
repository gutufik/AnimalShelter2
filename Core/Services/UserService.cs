﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Services
{
    public class UserService
    {
        public DataAccess _dataAccess;
        public UserService()
        {
            _dataAccess = new DataAccess();
        }
        public User GetUser(string login, string password)
        {
            return _dataAccess.GetUser(login, password);
        }
        public User GetUser(int id)
        {
            return _dataAccess.GetUser(id);
        }
        public List<Employee> GetEmployees()
        {
            return _dataAccess.GetEmployees();
        }
        public void SaveUser(User user)
        {
            _dataAccess.SaveUser(user);
        }
        public void SaveEmployee(Employee employee)
        {
            _dataAccess.SaveEmployee(employee);
        }
        public List<User> GetUsers()
        {
            return _dataAccess.GetUsers();
        }
        public List<Role> GetRoles()
        {
            return _dataAccess.GetRoles();
        }
        public void DeleteUser(User user) 
        {

        }
    }
}
