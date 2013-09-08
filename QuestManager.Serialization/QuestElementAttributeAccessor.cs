using System.Reflection;

namespace QuestManager.Serialization
{
    public class QuestElementAttributeAccessor : QuestAttributeAccessor
    {
        private readonly string _name;

        public QuestElementAttributeAccessor(string name, MemberInfo member)
            : base(member)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}