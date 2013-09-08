using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace QuestManager.Serialization
{
    public class QuestArrayAttributeAccessor : QuestElementAttributeAccessor
    {
        private QuestAttributes _itemAttributes;

        public QuestArrayAttributeAccessor(QuestKeyedArrayAttribute keyedArrayAttribute, MemberInfo member)
            : base(keyedArrayAttribute.ElementName, member)
        {
        }

        public IEnumerable GetArray(object target)
        {
            var enumerableValue = GetValue(target) as IEnumerable;
            return enumerableValue ?? Enumerable.Empty<object>();
        }

        public object GetItemValue(object item)
        {
            if (ItemAttributes.QuestArrayValueAccessor != null)
                return ItemAttributes.QuestArrayValueAccessor.GetValue(item);

            return null;
        }

        public object GetItemKey(object item)
        {
            if (ItemAttributes.QuestArrayKeyAccessor != null)
                return ItemAttributes.QuestArrayKeyAccessor.GetValue(item);

            return null;
        }

        private Type GetItemType()
        {
            var memberReturnType = GetMemberReturnType();
            if (memberReturnType == null)
                return null;

            return memberReturnType.GetGenericArguments().FirstOrDefault();
        }

        private QuestAttributes ItemAttributes
        {
            get { return _itemAttributes ?? (_itemAttributes = new QuestAttributes(GetItemType())); }
        }
    }
}