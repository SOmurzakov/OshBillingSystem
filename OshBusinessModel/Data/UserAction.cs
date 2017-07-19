using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OshBusinessModel.Data
{
    public class UserAction
    {

        public static UserAction Created = new UserAction("created", "Создан");
        public static UserAction Enabled = new UserAction("enabled", "Разблокирован");
        public static UserAction Disabled = new UserAction("disabled", "Заблокирован");

        public static UserAction[] Actions = new UserAction[] {Created, Enabled, Disabled, };

        public static UserAction GetById(string semanticId)
        {
            return Actions.FirstOrDefault(ua => ua.SemanticId == semanticId);
        }

        public string SemanticId { get; private set; }
        public string Name { get; private set; }

        public UserAction(string semanticId, string name)
        {
            SemanticId = semanticId;
            Name = name;
        }
    }
}
