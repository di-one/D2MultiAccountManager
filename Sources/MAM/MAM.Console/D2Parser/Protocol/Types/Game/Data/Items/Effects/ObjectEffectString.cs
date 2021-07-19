namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectString : ObjectEffect
	{
		public new const short Id = 3066;
		public override short TypeId => Id;
		public string value { get; set; }

		public ObjectEffectString(ushort actionId, string value)
		{
			this.actionId = actionId;
			this.value = value;
		}

		public ObjectEffectString() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadUTF();
		}

	}
}
