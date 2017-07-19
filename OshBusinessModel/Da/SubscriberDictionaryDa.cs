using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da
{
    public class SubscriberDictionaryDa
    {
        public string SubscriberType { get; set; }
        public int SubscribersCount { get; set; }
        public int CurPageNumber { get; set; }
        public int ItemsPerPage { get; set; }

        public SubscribersDictionaryItemDa[] Subscribers { get; set; }
        public string[] Streets { get; set; }

    }
}
