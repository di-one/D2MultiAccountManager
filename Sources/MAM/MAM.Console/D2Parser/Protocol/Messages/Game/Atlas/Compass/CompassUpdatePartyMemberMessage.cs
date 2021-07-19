namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
	{
		public new const uint Id = 1539;
		public override uint MessageId => Id;
		public ulong memberId { get; set; }
		public bool active { get; set; }

		public CompassUpdatePartyMemberMessage(sbyte type, MapCoordinates coords, ulong memberId, bool active)
		{
			this.type = type;
			this.coords = coords;
			this.memberId = memberId;
			this.active = active;
		}

		public CompassUpdatePartyMemberMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(memberId);
			writer.WriteBoolean(active);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			memberId = reader.ReadVarULong();
			active = reader.ReadBoolean();
		}

	}
}
