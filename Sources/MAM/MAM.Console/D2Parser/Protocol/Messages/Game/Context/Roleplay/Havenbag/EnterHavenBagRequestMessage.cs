namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EnterHavenBagRequestMessage : NetworkMessage
	{
		public const uint Id = 6451;
		public override uint MessageId => Id;
		public ulong havenBagOwner { get; set; }

		public EnterHavenBagRequestMessage(ulong havenBagOwner)
		{
			this.havenBagOwner = havenBagOwner;
		}

		public EnterHavenBagRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(havenBagOwner);
		}

		public override void Deserialize(IDataReader reader)
		{
			havenBagOwner = reader.ReadVarULong();
		}

	}
}
