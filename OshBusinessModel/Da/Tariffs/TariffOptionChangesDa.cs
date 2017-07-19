using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.Tariffs
{
    public class TariffOptionChangesDa
    {
        public DateTime Date { get; set; }
        public double LitersPerDay { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
