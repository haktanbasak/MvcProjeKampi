using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetTalentsByAdmin(int adminID);
        Talent GetByID(int id);
        void AddTalent(Talent talent);
        void UpdateTalent(Talent talent);
    }
}
