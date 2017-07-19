using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Data
{
    public class SubscriberType
    {

        public static SubscriberType Personal = new SubscriberType("prs", "Физическое лицо", "ФЛ", "Физ лица");
        public static SubscriberType LegalEntity = new SubscriberType("le", "Комм. предприятие", "ЮЛ", "Комм. предприятия");
        public static SubscriberType Budget = new SubscriberType("bgt", "Бюджетное учреждение", "БУ", "Бюджетные учреждения");
        public static SubscriberType Industry = new SubscriberType("ind", "Промышленное предприятие", "ЮЛ", "Промышленные предприятия");
        public static SubscriberType Unknown = new SubscriberType("unknown", "Неизвестно", "НИ", "Неизвестные");

        public static readonly SubscriberType[] SubscriberTypes = new SubscriberType[] {Personal, LegalEntity, Industry, Budget,};

        public static SubscriberType GetById (string semanticId)
        {
            return SubscriberTypes.FirstOrDefault(st => st.SemanticId == semanticId) ?? Unknown;
        }

        public string SemanticId { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Plural { get; private set; }

        private SubscriberType(string semanticId, string name, string abbreviation, string plurar)
        {
            SemanticId = semanticId;
            Name = name;
            Abbreviation = abbreviation;
            Plural = plurar;
        }

    }
}
