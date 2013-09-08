using System;

namespace QuestManager.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class QuestArrayKeyAttribute : Attribute
    {
    }
}