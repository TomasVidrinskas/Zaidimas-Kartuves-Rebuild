using Kartuves.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartuves.BL.Interfaces
{
    public interface IHiddenWordManager
    {
        HiddenWords HiddenWords { get; set; }

        HiddenWords GetHiddenWord();
        string GetHiddenWordsStructure();
        void CheckLetter(string spejimas);
    }
}
