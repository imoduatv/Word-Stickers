using System.IO;
using System.Text;

namespace SimpleJSON
{
	public class JSONBool : JSONNode
	{
		private bool m_Data;

		public override JSONNodeType Tag => JSONNodeType.Boolean;

		public override bool IsBoolean => true;

		public override string Value
		{
			get
			{
				return m_Data.ToString();
			}
			set
			{
				if (bool.TryParse(value, out bool result))
				{
					m_Data = result;
				}
			}
		}

		public override bool AsBool
		{
			get
			{
				return m_Data;
			}
			set
			{
				m_Data = value;
			}
		}

		public override Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public JSONBool(bool aData)
		{
			m_Data = aData;
		}

		public JSONBool(string aData)
		{
			Value = aData;
		}

		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append(m_Data ? "true" : "false");
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is bool)
			{
				return m_Data == (bool)obj;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_Data.GetHashCode();
		}

		public override void SerializeBinary(BinaryWriter aWriter)
		{
			aWriter.Write((byte)6);
			aWriter.Write(m_Data);
		}
	}
}