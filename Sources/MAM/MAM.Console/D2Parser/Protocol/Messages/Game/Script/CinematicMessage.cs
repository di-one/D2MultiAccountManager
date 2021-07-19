namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CinematicMessage : NetworkMessage
	{
		public const uint Id = 1487;
		public override uint MessageId => Id;
		public ushort cinematicId { get; set; }

		public CinematicMessage(ushort cinematicId)
		{
			this.cinematicId = cinematicId;
		}

		public CinematicMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cinematicId);
		}

		public override void Deserialize(IDataReader reader)
		{
			cinematicId = reader.ReadVarUShort();
		}

	}
}
