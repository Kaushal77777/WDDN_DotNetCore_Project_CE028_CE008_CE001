using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Models
{
    public interface ISlotRepository
    {
        Slot GetSlot(User user);
        Slot Add(Slot Slot);
    }
}
