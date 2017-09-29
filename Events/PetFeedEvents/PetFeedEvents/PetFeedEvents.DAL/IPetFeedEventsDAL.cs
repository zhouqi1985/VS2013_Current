using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetFeedEvents.DAL
{
    public interface IPetFeedEventsDAL
    {
        List<int> GameLogTransfer(DateTime? RecordDate);
        int SendDynamicCouponQueue();
    }
}
