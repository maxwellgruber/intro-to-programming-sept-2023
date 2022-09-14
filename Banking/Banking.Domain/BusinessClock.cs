using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain;
public class BusinessClock : IProvideTheBusinessClock
{

    private readonly ISystemTime _clock;

    public BusinessClock(ISystemTime clock)
    {
        _clock = clock;
    }

    public bool DuringBusinessHours()
    {
        return _clock.GetCurrent().Hour >= 9 && _clock.GetCurrent().Hour <= 17;
    }
}

