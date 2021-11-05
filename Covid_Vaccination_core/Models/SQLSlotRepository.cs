using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Models
{
    public class SQLSlotRepository : ISlotRepository
    {
        private readonly AppDbContext context;

        public SQLSlotRepository(AppDbContext context)
        {
            this.context = context;
        }
        Slot ISlotRepository.Add(Slot Slot)
        {
            context.Slots.Add(Slot);
            context.SaveChanges();
            return Slot;
        }

        Slot ISlotRepository.GetSlot(User user)
        {
            Slot s = context.Slots.FirstOrDefault(s => s.User == user);
            return s;
        }
    }
}
