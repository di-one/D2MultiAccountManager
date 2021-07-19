namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameServerInformations
	{
		public const short Id  = 920;
		public virtual short TypeId => Id;
		public bool isMonoAccount { get; set; }
		public bool isSelectable { get; set; }
		public ushort objectId { get; set; }
		public sbyte type { get; set; }
		public sbyte status { get; set; }
		public sbyte completion { get; set; }
		public sbyte charactersCount { get; set; }
		public sbyte charactersSlots { get; set; }
		public double date { get; set; }

		public GameServerInformations(bool isMonoAccount, bool isSelectable, ushort objectId, sbyte type, sbyte status, sbyte completion, sbyte charactersCount, sbyte charactersSlots, double date)
		{
			this.isMonoAccount = isMonoAccount;
			this.isSelectable = isSelectable;
			this.objectId = objectId;
			this.type = type;
			this.status = status;
			this.completion = completion;
			this.charactersCount = charactersCount;
			this.charactersSlots = charactersSlots;
			this.date = date;
		}

		public GameServerInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, isMonoAccount);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isSelectable);
			writer.WriteByte(flag);
			writer.WriteVarUShort(objectId);
			writer.WriteSByte(type);
			writer.WriteSByte(status);
			writer.WriteSByte(completion);
			writer.WriteSByte(charactersCount);
			writer.WriteSByte(charactersSlots);
			writer.WriteDouble(date);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			isMonoAccount = BooleanByteWrapper.GetFlag(flag, 0);
			isSelectable = BooleanByteWrapper.GetFlag(flag, 1);
			objectId = reader.ReadVarUShort();
			type = reader.ReadSByte();
			status = reader.ReadSByte();
			completion = reader.ReadSByte();
			charactersCount = reader.ReadSByte();
			charactersSlots = reader.ReadSByte();
			date = reader.ReadDouble();
		}

	}
}
