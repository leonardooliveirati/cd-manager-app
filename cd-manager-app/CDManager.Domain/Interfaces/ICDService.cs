using CDManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDManager.Domain.Interfaces
{
    public interface ICDService
    {
        CDMusic CreateCD(CDMusic cd);
        List<CDMusic> GetCDs(string title, string artist, string genre, string musicName);
    }
}
