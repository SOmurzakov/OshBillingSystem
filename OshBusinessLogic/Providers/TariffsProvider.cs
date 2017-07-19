using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Da;
using OshBusinessModel.Da.Tariffs;

namespace OshBusinessLogic.Providers
{
    public class TariffsProvider
    {
        public TariffDictionaryDa[] GetTariffsDictionary()
        {
            var tables = NativeSql.ExecMultiple("tariffs_getDictionary", new {enabled = true,});
            var tariffs = tables[0].Rows<TariffDictionaryDa>();
            var tariffsOptions = tables[1].Rows<TariffOptionDictionaryDa>();

            tariffs.ToList().ForEach(
                t => t.TariffOptions = tariffsOptions.Where(to => to.TariffSubtype == t.Subtype).ToArray());

            return tariffs;
        }

        public TariffDictionaryDa[] GetTariffsArchiveDictionary()
        {
            var tables = NativeSql.ExecMultiple("tariffs_getDictionary", new {enabled = false, });
            var tariffs = tables[0].Rows<TariffDictionaryDa>();
            var tariffOptions = tables[1].Rows<TariffOptionDictionaryDa>();

            tariffs.ToList().ForEach(
                t => t.TariffOptions = tariffOptions.Where(to => to.TariffSubtype == t.Subtype).ToArray());

            return tariffs;
        }

        public TariffDetailsModel GetDetails(string semanticId)
        {
            var tables = NativeSql.ExecMultiple("tariffs_getDetails", new {semanticId,});
            var curState = tables[0].OneRow<TariffDictionaryDa>();

            return
                curState == null
                    ? null
                    : new TariffDetailsModel()
                          {
                              CurrentState = curState,
                              Changes = tables[1].Rows<TariffChangesDa>(),
                              TariffOptions = tables[2].Rows<TariffOptionDictionaryDa>(),
                          };
        }

        public TariffOptionDetailsModel GetTariffOptionDetails(string semanticId)
        {
            var tables = NativeSql.ExecMultiple("tariffsOptions_getDetails", new {semanticId,});
            var details = tables[0].OneRow<TariffOptionDetalisDa>();

            return
                details == null
                    ? null
                    : new TariffOptionDetailsModel()
                          {
                              Details = details,
                              Changes = tables[1].Rows<TariffOptionChangesDa>(),
                              Tariffs = tables[2].Rows<TariffOptionTariffsDa>(),
                          };
        }

        public void ChangeTariffPrice(int userId, string tariffId, string tariffName, double litersPerPersonPerDay, double waterPricePerCubicMeter, double sewagePricePerCubicMeter)
        {
            NativeSql.ExecMultiple("tariffs_changePrice",
                           new
                               {
                                   tariffId,
                                   tariffName,
                                   litersPerPersonPerDay,
                                   waterPricePerCubicMeter,
                                   sewagePricePerCubicMeter,
                                   userId,
                               });
        }

        public void ChangeTariffOptionPrice(int userId, string tariffOptionId, double litersPerDay)
        {
            NativeSql.Exec("tariffsOptions_changePrice", new {userId, tariffOptionId, litersPerDay,});
        }
    }
}
