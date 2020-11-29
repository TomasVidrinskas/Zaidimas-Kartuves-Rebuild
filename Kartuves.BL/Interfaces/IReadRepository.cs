using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kartuves.BL.Interfaces;
using Kartuves.DL;

namespace Kartuves.BL.Interfaces
{
    public interface IReadRepository
    {
        List<Subject> GetAllSubjects();
    }
}
