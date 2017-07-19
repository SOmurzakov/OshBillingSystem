using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da.Areas;
using OshBusinessModel.Da.Rootings;
using OshBusinessModel.Da.ClosingPeriods;
using OshBusinessModel.Da;

namespace OshBusinessLogic.Providers
{
    public class RootingsProvider
    {
        public RootingsAreasDa[] GetRootingsAreas(int userId)
        {
            return NativeSql.Exec("rootings_getAreas", new {userId,}).Rows<RootingsAreasDa>();
        }

        public RootingsStreetsModel GetRootingsStreets(int userId, int areaId)
        {
            var tables = NativeSql.ExecMultiple("rootings_getStreets", new {userId, areaId,});
            var model = new RootingsStreetsModel()
            {
                AreaId = areaId,
                AreaName = "",
                ControllerId = userId,
                Controllers = tables[0].Rows<UserDa>(),
                Areas = tables[1].Rows<AreasDictionaryDa>(),
            };
            var firstRow = tables[2].OneRow<RootingsStreetsModel>();
            if (firstRow != null) model.AreaName = firstRow.AreaName;

            if (tables.Length>3)
            {
                model.Streets = tables[3].Rows<RootingsStreetsDa>();
            } 
            return model;
        }

        public RootingsBuildingsModel GetRootingsBuildings(int areaId, string street)
        {
            var tables = NativeSql.ExecMultiple("rootings_getBuildings", new {areaId, street,});
            var model = tables[0].OneRow<RootingsBuildingsModel>();

            if (model != null)
            {
                model.Buildings = tables[1].Rows<RootingsBuildingsDa>();
            }

            return model;
        }

        public RootingsContractsModel GetRootingsContracts(int areaId, string street, string building)
        {
            var tables = NativeSql.ExecMultiple("rootings_getContracts", new {areaId, street, building,});
            var model = tables[0].OneRow<RootingsContractsModel>();

            if (model != null)
            {
                model.Contracts = tables[1].Rows<RootingsContractsDa>();
                model.Areas = tables[2].Rows<RootingsAreasDa>();
            }

            return model;
        }

        public RootingsForControllerModel GetRootingsForController(int periodId, int controllerId, int areaId)
        {
            var tables = NativeSql.ExecMultiple("customs_getRootingsForController", new {periodId, controllerId, areaId,});

            var periods = tables[0].Rows<ShortBillingDa>();

            if (periods.Length == 0)
            {
                return null;
            }

            var model = new RootingsForControllerModel()
                            {
                                PeriodId = periodId,
                                Periods = periods,
                                ControllerId = controllerId,
                                Controllers = tables[1].Rows<UserDa>(),
                                AreaId = areaId,
                                Areas = tables[2].Rows<AreasDictionaryDa>(),
                                Contracts = tables[3].Rows<RootingContractForControllerDa>(),
                            };

            return model;
        }


        public void RootingsChangeArea(int OldAreaId, int NewAreaId, string Street, string Building)
        {
            NativeSql.Exec("rootings_changeArea", new { OldAreaId, NewAreaId, Street, Building });
        }
    }
}
