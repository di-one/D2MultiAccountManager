namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCreationResultMessage : NetworkMessage
	{
		public const uint Id = 9184;
		public override uint MessageId => Id;
		public sbyte result { get; set; }

		public CharacterCreationResultMessage(sbyte result)
		{
			this.result = result;
		}

		public CharacterCreationResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			result = reader.ReadSByte();
		}

	}
}
