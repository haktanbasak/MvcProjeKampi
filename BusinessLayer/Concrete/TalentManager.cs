using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public void AddTalent(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public Talent GetByID(int id)
        {
            return _talentDal.Get(x => x.TalentID == id);
        }

        public List<Talent> GetTalentsByAdmin(int adminID)
        {
            return _talentDal.List(x => x.AdminID == adminID);
        }

        public void UpdateTalent(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
