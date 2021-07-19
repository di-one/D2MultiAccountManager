namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdolsPresetSaveRequestMessage : IconPresetSaveRequestMessage
	{
		public new const uint Id = 9696;
		public override uint MessageId => Id;

		public IdolsPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData)
		{
			this.presetId = presetId;
			this.symbolId = symbolId;
			this.updateData = updateData;
		}

		public IdolsPresetSaveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
