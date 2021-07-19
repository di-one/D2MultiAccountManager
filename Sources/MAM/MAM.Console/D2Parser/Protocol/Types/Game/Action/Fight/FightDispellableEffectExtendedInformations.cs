namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightDispellableEffectExtendedInformations
	{
		public const short Id  = 7773;
		public virtual short TypeId => Id;
		public ushort actionId { get; set; }
		public double sourceId { get; set; }
		public AbstractFightDispellableEffect effect { get; set; }

		public FightDispellableEffectExtendedInformations(ushort actionId, double sourceId, AbstractFightDispellableEffect effect)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.effect = effect;
		}

		public FightDispellableEffectExtendedInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(actionId);
			writer.WriteDouble(sourceId);
			writer.WriteShort(effect.TypeId);
			effect.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			actionId = reader.ReadVarUShort();
			sourceId = reader.ReadDouble();
			effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadShort());
			effect.Deserialize(reader);
		}

	}
}
