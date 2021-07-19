namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
	{
		public new const uint Id = 7421;
		public override uint MessageId => Id;
		public ushort objectGID { get; set; }

		public GameRolePlayDelayedObjectUseMessage(double delayedCharacterId, sbyte delayTypeId, double delayEndTime, ushort objectGID)
		{
			this.delayedCharacterId = delayedCharacterId;
			this.delayTypeId = delayTypeId;
			this.delayEndTime = delayEndTime;
			this.objectGID = objectGID;
		}

		public GameRolePlayDelayedObjectUseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(objectGID);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectGID = reader.ReadVarUShort();
		}

	}
}
