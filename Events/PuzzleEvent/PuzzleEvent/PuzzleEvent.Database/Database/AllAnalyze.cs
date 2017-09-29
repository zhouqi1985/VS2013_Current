using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    public class Analyze
    {
        public const string PayPointField = "PayPoint";
        public const string OtherPointField = "OtherPoint";
        public const string BillPointField = "BillPoint";
        public const string PersonsField = "Persons";
        public const string BJNumField = "BJNum";
        public const string CNNumField = "CNNum";
        public const string JPNumField = "JPNum";
        public const string RedNumField = "RedNum";
        public const string XNNumField = "XNNum";

        public DateTime Date { get; set; }

        public int PayPoint { get; set; }
          
        public int OtherPoint { get; set; }

        public int BillPoint { get; set; }

        public int Persons { get; set; }

        public int BJNum { get; set; }

        public int CNNum { get; set; }
        public int JPNum { get; set; }

        public int RedNum { get; set; }
        public int XNNum { get; set; }


        public List<Packet> ListPacket { get; set; }

    }

    public class Packet 
    {
        public const string PacketIDField = "PacketID";
        public const string PacketNameField = "PacketName";
        public const string ExchangeNumField = "ExchangeNum";

        public long PacketID { get; set; }
        public string PacketName { get; set; }

        public int ExchangeNum { get; set; }
    }

}
