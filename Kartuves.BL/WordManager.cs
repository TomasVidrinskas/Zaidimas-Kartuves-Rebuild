using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kartuves.BL.Interfaces;
using Kartuves.DL;
using System.Data.Entity;

namespace Kartuves.BL
{
    public class WordManager : IReadRepository
    {

        public List<Subject> GetAllSubjects()
        {
            List<Subject> list;
            using (var context = new KartuvesContext())
            {
                list = context.Subjects.Include(e => e.Words).ToList();
            }
            return list;
        }
    }
}
