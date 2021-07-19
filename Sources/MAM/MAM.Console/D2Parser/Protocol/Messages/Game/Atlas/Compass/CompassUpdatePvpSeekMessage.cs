namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
	{
		public new const uint Id = 7293;
		public override uint MessageId => Id;
		public ulong memberId { get; set; }
		public string memberName { get; set; }

		public CompassUpdatePvpSeekMessage(sbyte type, MapCoordinates coords, ulong memberId, string memberName)
		{
			this.type = type;
			this.coords = coords;
			this.memberId = memberId;
			this.memberName = memberName;
		}

		public CompassUpdatePvpSeekMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(memberId);
			writer.WriteUTF(memberName);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			memberId = reader.ReadVarULong();
			memberName = reader.ReadUTF();
		}

	}
}
