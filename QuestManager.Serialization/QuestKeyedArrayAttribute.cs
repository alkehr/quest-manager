using System;

namespace QuestManager.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class QuestKeyedArrayAttribute : Attribute
    {
        private string _elementName;
        private int _order;

        public QuestKeyedArrayAttribute(string elementName)
        {
            ElementName = elementName;
        }

        public QuestKeyedArrayAttribute(string elementName, int order)
        {
            ElementName = elementName;
            Order = order;
        }

        public string ElementName
        {
            get { return _elementName ?? string.Empty; }
            set { _elementName = value; }
        }

        public int Order
        {
            get { return _order; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Order");
                _order = value;
            }
        }
    }
}
