using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        bool IsExist(AdminDto admin);
        string[] GetRoles(string userName);
        void AddAdmin(AdminDto admin);
        List<Admin> GetList();
        Admin GetByID(int id);
        Admin GetByName(string username);
        void AdminDelete(AdminDto admin);
        void AdminUpdate(AdminDto admin);
    }
}
