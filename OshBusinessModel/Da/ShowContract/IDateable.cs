using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Da.ShowContract
{
    public interface IDateable
    {

        DateTime Date { get; }

    }

    public static class IDateableExtentions
    {
        public static int CompareTo(this IDateable a, IDateable b)
        {
            return -a.Date.CompareTo(b.Date);
        }
    }
}
