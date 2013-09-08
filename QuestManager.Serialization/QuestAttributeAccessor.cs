using System;
using System.Reflection;

namespace QuestManager.Serialization
{
    public class QuestAttributeAccessor
    {
        private readonly MemberInfo _member;

        public QuestAttributeAccessor(MemberInfo member)
        {
            _member = member;
        }

        public object GetValue(object target)
        {
            var propertyInfo = _member as PropertyInfo;
            if (propertyInfo != null)
            {
                MethodInfo getter = propertyInfo.GetGetMethod();
                if (getter != null)
                    return getter.Invoke(target, null);
            }

            var fieldInfo = _member as FieldInfo;
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(target);
            }

            return null;
        }

        protected Type GetMemberReturnType()
        {
            var propertyInfo = _member as PropertyInfo;
            if (propertyInfo != null)
            {
                MethodInfo getter = propertyInfo.GetGetMethod();
                return getter.ReturnType;
            }

            var fieldInfo = _member as FieldInfo;
            if (fieldInfo != null)
            {
                return fieldInfo.FieldType;
            }

            return null;
        }
    }
}