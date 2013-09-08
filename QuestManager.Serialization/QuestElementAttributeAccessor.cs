using System.Reflection;

namespace QuestManager.Serialization
{
    public class QuestElementAttributeAccessor : QuestAttributeAccessor
    {
        private readonly QuestElementAttribute _elementAttribute;

        public QuestElementAttributeAccessor(QuestElementAttribute elementAttribute, MemberInfo member)
            : base(member)
        {
            _elementAttribute = elementAttribute;
        }

        public string GetName()
        {
            return _elementAttribute.ElementName;
        }
    }
}