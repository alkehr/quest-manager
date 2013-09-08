using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QuestManager.Serialization
{
    public class QuestAttributes
    {
        private readonly QuestAttributeAccessor _questIdAccessor;
        private readonly List<QuestElementAttributeAccessor> _questElementAccessors = new List<QuestElementAttributeAccessor>();
        private readonly List<QuestArrayAttributeAccessor> _questArrayAccessors = new List<QuestArrayAttributeAccessor>();
        private readonly QuestAttributeAccessor _questArrayKeyAccessor;
        private readonly QuestAttributeAccessor _questArrayValueAccessor;

        public QuestAttributes(Type type)
        {
            foreach (var member in type.GetMembers(BindingFlags.Instance | BindingFlags.Public))
            {
                object[] questElementAttributes = member.GetCustomAttributes(typeof (QuestElementAttribute), true);
                foreach (QuestElementAttribute questElementAttribute in questElementAttributes)
                {
                    _questElementAccessors.Add(new QuestElementAttributeAccessor(questElementAttribute.ElementName, member));
                }

                object[] questArrayAttributes = member.GetCustomAttributes(typeof (QuestKeyedArrayAttribute), true);
                foreach (QuestKeyedArrayAttribute questArrayAttribute in questArrayAttributes)
                {
                    _questArrayAccessors.Add(new QuestArrayAttributeAccessor(questArrayAttribute, member));
                }

                if (_questIdAccessor == null)
                {
                    _questIdAccessor = GetSingleAttributeAccessor<QuestIdAttribute>(member);
                }
                
                if (_questArrayKeyAccessor == null)
                {
                    _questArrayKeyAccessor = GetSingleAttributeAccessor<QuestArrayKeyAttribute>(member);
                }

                if (_questArrayValueAccessor == null)
                {
                    _questArrayValueAccessor = GetSingleAttributeAccessor<QuestArrayValueAttribute>(member);
                }
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

        public QuestAttributeAccessor QuestIdAccessor
        {
            get { return _questIdAccessor; }
        }

        public IEnumerable<QuestArrayAttributeAccessor> QuestArrayAccessors
        {
            get { return _questArrayAccessors.AsReadOnly(); }
        }

        public QuestAttributeAccessor QuestArrayKeyAccessor
        {
            get { return _questArrayKeyAccessor; }
        }

        public QuestAttributeAccessor QuestArrayValueAccessor
        {
            get { return _questArrayValueAccessor; }
        }

        public static QuestAttributes<T> Create<T>(T target)
        {
            return new QuestAttributes<T>();
        }

        private static QuestAttributeAccessor GetSingleAttributeAccessor<T>(MemberInfo member)
            where T : Attribute
        {
            if (member == null)
                throw new ArgumentNullException("member");

            var customAttribute = member.GetCustomAttributes(typeof(T), true).FirstOrDefault() as T;
            if (customAttribute != null)
                return new QuestAttributeAccessor(member);

            return null;
        }
    }

    public class QuestAttributes<T> : QuestAttributes
    {
        public QuestAttributes()
            : base(typeof (T))
        {
        }
    }
}