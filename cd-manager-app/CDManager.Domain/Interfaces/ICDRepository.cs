using System.Collections.Generic;
using CDManager.Domain.Entities;

namespace CDManager.Domain.Interfaces
{
    public interface ICDRepository
    {
        CDMusic Create(CDMusic cd);
        List<CDMusic> GetCDs(string title, string artist, string genre, string musicName);
    }
}
