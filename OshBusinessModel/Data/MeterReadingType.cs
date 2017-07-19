using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Data
{
    public class MeterReadingType
    {
        public static readonly MeterReadingType Installation = new MeterReadingType("install", "Установка водомера");
        public static readonly MeterReadingType Removal = new MeterReadingType("removal", "Снятие водомера");
        public static readonly MeterReadingType Regular = new MeterReadingType("regular", "Контроллер");
        public static readonly MeterReadingType Estimated = new MeterReadingType("estimated", "Автоматически");
        public static readonly MeterReadingType Correction = new MeterReadingType("correction", "Корректировка");
        public static readonly MeterReadingType SelfCommunicated = new MeterReadingType("self", "Абонент");
        public static readonly MeterReadingType Unknown = new MeterReadingType("unk", "Неизвестно");

        public static readonly MeterReadingType[] MeterReadingTypes = new MeterReadingType[] {Installation, Removal, Regular, Estimated, Correction, SelfCommunicated};

        public static readonly MeterReadingType[] MeterReadingTypesForEnter = new MeterReadingType[] {Regular, SelfCommunicated, Removal, Correction};

        public static MeterReadingType GetMeterReadingTypeById(string semanticId)
        {
            return MeterReadingTypes.FirstOrDefault(t => t.SemanticId == semanticId) ?? Unknown;
        }

        public string SemanticId { get; set; }
        public string Name { get; set; }

        public MeterReadingType(string semanticId, string name)
        {
            SemanticId = semanticId;
            Name = name;
        }
    }
}
