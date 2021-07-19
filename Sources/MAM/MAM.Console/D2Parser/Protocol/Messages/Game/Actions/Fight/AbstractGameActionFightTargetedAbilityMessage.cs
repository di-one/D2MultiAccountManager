namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
	{
		public new const uint Id = 8120;
		public override uint MessageId => Id;
		public bool silentCast { get; set; }
		public bool verboseCast { get; set; }
		public double targetId { get; set; }
		public short destinationCellId { get; set; }
		public sbyte critical { get; set; }

		public AbstractGameActionFightTargetedAbilityMessage(ushort actionId, double sourceId, bool silentCast, bool verboseCast, double targetId, short destinationCellId, sbyte critical)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.silentCast = silentCast;
			this.verboseCast = verboseCast;
			this.targetId = targetId;
			this.destinationCellId = destinationCellId;
			this.critical = critical;
		}

		public AbstractGameActionFightTargetedAbilityMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, silentCast);
			flag = BooleanByteWrapper.SetFlag(flag, 1, verboseCast);
			writer.WriteByte(flag);
			writer.WriteDouble(targetId);
			writer.WriteShort(destinationCellId);
			writer.WriteSByte(critical);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			silentCast = BooleanByteWrapper.GetFlag(flag, 0);
			verboseCast = BooleanByteWrapper.GetFlag(flag, 1);
			targetId = reader.ReadDouble();
			destinationCellId = reader.ReadShort();
			critical = reader.ReadSByte();
		}

	}
}
