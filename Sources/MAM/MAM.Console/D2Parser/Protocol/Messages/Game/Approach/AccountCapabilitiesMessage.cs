namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccountCapabilitiesMessage : NetworkMessage
	{
		public const uint Id = 7617;
		public override uint MessageId => Id;
		public bool tutorialAvailable { get; set; }
		public bool canCreateNewCharacter { get; set; }
		public int accountId { get; set; }
		public uint breedsVisible { get; set; }
		public uint breedsAvailable { get; set; }
		public sbyte status { get; set; }

		public AccountCapabilitiesMessage(bool tutorialAvailable, bool canCreateNewCharacter, int accountId, uint breedsVisible, uint breedsAvailable, sbyte status)
		{
			this.tutorialAvailable = tutorialAvailable;
			this.canCreateNewCharacter = canCreateNewCharacter;
			this.accountId = accountId;
			this.breedsVisible = breedsVisible;
			this.breedsAvailable = breedsAvailable;
			this.status = status;
		}

		public AccountCapabilitiesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, tutorialAvailable);
			flag = BooleanByteWrapper.SetFlag(flag, 1, canCreateNewCharacter);
			writer.WriteByte(flag);
			writer.WriteInt(accountId);
			writer.WriteVarUInt(breedsVisible);
			writer.WriteVarUInt(breedsAvailable);
			writer.WriteSByte(status);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			tutorialAvailable = BooleanByteWrapper.GetFlag(flag, 0);
			canCreateNewCharacter = BooleanByteWrapper.GetFlag(flag, 1);
			accountId = reader.ReadInt();
			breedsVisible = reader.ReadVarUInt();
			breedsAvailable = reader.ReadVarUInt();
			status = reader.ReadSByte();
		}

	}
}
