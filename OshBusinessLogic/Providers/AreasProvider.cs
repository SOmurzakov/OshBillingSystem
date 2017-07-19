using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Areas;

namespace OshBusinessLogic.Providers
{
    public class AreasProvider
    {
        public AreasDictionaryModel GetAreasDictionary()
        {
            var tables = NativeSql.ExecMultiple("areas_getDictionary");

            return new AreasDictionaryModel()
                       {
                           Areas = tables[0].Rows<AreasDictionaryDa>(),
                           Controllers = tables[1].Rows<CreateAreaControllerDa>(),
                       };
        }

        public AreasHousesModel GetAreasHouses()
        {
            var tables = NativeSql.ExecMultiple("areas_getHouses");

            return new AreasHousesModel()
                       {
                           Houses = tables[0].Rows<AreasHousesDa>(),
                           Areas = tables[1].Rows<AreasDictionaryDa>(),
                       };
        }

        public void CreateArea(string areaName, string remarks, int controllerId)
        {
            NativeSql.Exec("areas_create", new {areaName, remarks, controllerId,});
        }

        public void EditArea(int areaId, string areaName, string remarks, int controllerId)
        {
            NativeSql.Exec("areas_edit", new {areaId, areaName, remarks, controllerId,});
        }

        public void SaveAreasControllers(SaveAreasControllersDa[] areas)
        {
            NativeSql.Exec("areas_saveControllers", new {areas,});
        }

        public void SaveAreasHouses(AreasHousesDa[] houses)
        {
            houses.ToList().ForEach((t) =>
                                        {
                                            t.AddressBuilding = t.AddressBuilding ?? "";
                                            t.AddressStreet = t.AddressStreet ?? "";
                                        });

            NativeSql.Exec("areas_saveHouses", new {houses,});
        }
    }
}
