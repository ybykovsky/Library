using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Enums
{
    public enum BookingStatus
    {
        Reserved = 0,
        OnHands = 1,
        Cancelled = 2,
        CancelledByModerator = 3
    }
}
