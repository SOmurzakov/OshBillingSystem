using System.Linq;
using OshBusinessModel.Da.Streets;

namespace OshBusinessLogic.Providers
{
    public class StreetsProvider
    {
        public string[] GetAllStreets()
        {
            return NativeSql.Exec("streets_getAll").Rows<StreetDa>().Select(street => street.AddressStreet).OrderBy(s => s).ToArray();
        }

        public void Rename(string street, string newName)
        {
            NativeSql.Exec("streets_rename", new {street, newName});
        }
    }
}