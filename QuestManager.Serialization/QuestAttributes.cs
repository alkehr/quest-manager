using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QuestManager.Serialization
{
    public class QuestAttributes
    {
        public static QuestAttributes<T> Create<T>(T target)
        {
            return new QuestAttributes<T>();
        }
    }

    public class QuestAttributes<T>
    {
        private readonly QuestAttributeAccessor _questIdAttributeAccessor;
        private readonly List<QuestElementAttributeAccessor> _questElementAccessors = new List<QuestElementAttributeAccessor>(); 

        public QuestAttributes()
        {
            Type type = typeof (T);

            foreach (var member in type.GetMembers(BindingFlags.Instance | BindingFlags.Public))
            {
                object[] questElementAttributes = member.GetCustomAttributes(typeof(QuestElementAttribute), true);
                foreach (QuestElementAttribute questElementAttribute in questElementAttributes)
                {
                    _questElementAccessors.Add(new QuestElementAttributeAccessor(questElementAttribute, member));
                }

                var questIdAttribute =
                    member.GetCustomAttributes(typeof (QuestIdAttribute), true).FirstOrDefault() as
                        QuestIdAttribute;
                    if (questIdAttribute != null)
                        _questIdAttributeAccessor = new QuestAttributeAccessor(member);
            }
        }

        public QuestAttributeFlags QuestFlags
        {
            get
            {
                QuestAttributeFlags questAttributeFlags = 0;
                if (_questElementAccessors.Count > 0)
                    questAttributeFlags |= QuestAttributeFlags.Elements;

                return questAttributeFlags;
            }
        }

        public IEnumerable<QuestElementAttributeAccessor> QuestElementAccessors
        {
            get { return _questElementAccessors.AsReadOnly(); }
        }

        public QuestAttributeAccessor QuestIdAttributeAccessor
        {
            get { return _questIdAttributeAccessor; }
        }
    }
}