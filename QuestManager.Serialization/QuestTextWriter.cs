using System.IO;

namespace QuestManager.Serialization
{
    public class QuestTextWriter : QuestWriter
    {
        private readonly TextWriter _textWriter;

        public QuestTextWriter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        protected override void WriteBeginQuest(object questId)
        {
            WriteString("when {0}", SerializeValue(questId));
            WriteLine();
        }

        protected override void WriteStartElement(string name)
        {
            WriteString("q[:{0}]", name);
        }

        protected override void WriteElementValue(object value)
        {

            
            WriteString("={0}", SerializeValue(value));
        }

        private string SerializeValue(object value)
        {
            const string valueFormat = "{0}{1}{2}";
            string valueMarkupBegin = string.Empty;
            string valueMarkupEnd = string.Empty;

            if (value == null)
                value = string.Empty;

            if (value is string)
            {
                valueMarkupBegin = "\"";
                valueMarkupEnd = "\"";
            }

            return string.Format(valueFormat, valueMarkupBegin, value, valueMarkupEnd);
        }

        protected override void WriteEndElement()
        {
            WriteLine();
        }

        private void WriteString(string format, params object[] args)
        {
            _textWriter.Write(format, args);
        }

        private void WriteLine()
        {
            _textWriter.WriteLine();
        }
    }
}