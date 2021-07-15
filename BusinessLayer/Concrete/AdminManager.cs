using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddAdmin(AdminDto admin)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(admin.Password, out passwordHash, out passwordSalt);
            var ad = new Admin
            {
                AdminUsername = admin.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminRole = admin.AdminRole
            };
            _adminDal.Insert(ad);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void AdminDelete(AdminDto admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(AdminDto admin)
        {
            byte[] passwordHash, passwordSalt;
            var ad = _adminDal.Get(x => x.AdminUsername == admin.UserName);
            if (admin.Password != null)
            {
                CreatePasswordHash(admin.Password, out passwordHash, out passwordSalt);
                ad.PasswordHash = passwordHash;
                ad.PasswordSalt = passwordSalt;
            }
            ad.AdminRole = admin.AdminRole;
            _adminDal.Update(ad);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public Admin GetByName(string username)
        {
            return _adminDal.Get(x => x.AdminUsername == username);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public string[] GetRoles(string userName)
        {
            string[] result = _adminDal.List(x => x.AdminUsername == userName).Select(x => x.AdminRole).ToArray();
            return result;
        }

        public bool IsExist(AdminDto admin)
        {
            var ad = _adminDal.Get(x => x.AdminUsername == admin.UserName);
            return VerifyPasswordHash(admin.Password, ad.PasswordHash, ad.PasswordSalt);
        }
    }
}
