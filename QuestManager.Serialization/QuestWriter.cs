using System;

namespace QuestManager.Serialization
{
    [Flags]
    public enum QuestAttributeFlags
    {
        Elements = 1,
    }

    public abstract class QuestWriter
    {
        protected abstract void WriteBeginQuest(object questId);

        protected abstract void WriteStartElement(string name);
        protected abstract void WriteElementValue(object value);

        protected virtual void WriteEndElement()
        {
        }

        protected virtual void WriteEndQuest()
        {
        }

        public void Write<T>(T quest)
        {
            var questAttributes = QuestAttributes.Create(quest);

            WriteBeginQuest(questAttributes.QuestIdAttributeAccessor.GetValue(quest));

            foreach (var elementAccessor in questAttributes.QuestElementAccessors)
            {
                var value = elementAccessor.GetValue(quest);
                if (value != null)
                    WriteElement(elementAccessor.GetName(), value);
            }

            WriteEndQuest();

            /*
             when 1 # Quest 1 - SAMPLE QUEST
              q[:name]              = "Haunted Font"
              q[:level]             = 3
              q[:icon_index]        = 7
              q[:description]       = "Investigate the source of the strange phenomenon."
              q[:objectives][0]     = "Talk to Fontaneda"
              q[:objectives][1]     = "Drink the Water"
              q[:prime_objectives]  = [1]
              q[:custom_categories] = []
              q[:banner]            = ""
              q[:banner_hue]        = 0
              q[:client]            = "Amoxtli"
              q[:location]          = "Tribulation Springs"
              q[:common_event_id]   = 0
              q[:rewards]           = [
                [:item, 1, 3],
                [:gold, 500],
              ]
              q[:layout]            = false
             */
        }

        protected void WriteElement(string name, object value)
        {
            WriteStartElement(name);
            WriteElementValue(value);
            WriteEndElement();
        }
    }
}