namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeSetCraftRecipeMessage : NetworkMessage
	{
		public const uint Id = 3940;
		public override uint MessageId => Id;
		public ushort objectGID { get; set; }

		public ExchangeSetCraftRecipeMessage(ushort objectGID)
		{
			this.objectGID = objectGID;
		}

		public ExchangeSetCraftRecipeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectGID);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectGID = reader.ReadVarUShort();
		}

	}
}
