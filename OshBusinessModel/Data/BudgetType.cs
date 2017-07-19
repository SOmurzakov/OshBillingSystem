using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Data
{
    public class BudgetType
    {

        //public static BudgetType Local = new BudgetType("local", "Местный");
        public static BudgetType Republic = new BudgetType("republic", "Республиканский");
        public static BudgetType District = new BudgetType("district", "Областной");
        public static BudgetType City = new BudgetType("city", "Городской");
        public static BudgetType Unknown = new BudgetType("unk", "Неизвестно");

        //public static BudgetType[] BudgetTypes = new BudgetType[] {Local, Republic,};
        public static BudgetType[] BudgetTypes = new BudgetType[] {City, District, Republic,};
        
        public static BudgetType GetBudgetTypeById(string type)
        {
            return BudgetTypes.FirstOrDefault(t => t.SemanticId == type) ?? Unknown;
        }

        public string SemanticId { get; private set; }
        public string Name { get; private set; }

        private BudgetType(string semanticId, string name)
        {
            SemanticId = semanticId;
            Name = name;
        }
    }
}
