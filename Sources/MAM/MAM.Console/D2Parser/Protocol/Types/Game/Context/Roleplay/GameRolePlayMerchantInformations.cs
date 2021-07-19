namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
	{
		public new const short Id = 2992;
		public override short TypeId => Id;
		public sbyte sellType { get; set; }
		public IEnumerable<HumanOption> options { get; set; }

		public GameRolePlayMerchantInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, string name, sbyte sellType, IEnumerable<HumanOption> options)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.name = name;
			this.sellType = sellType;
			this.options = options;
		}

		public GameRolePlayMerchantInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(sellType);
			writer.WriteShort((short)options.Count());
			foreach (var objectToSend in options)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			sellType = reader.ReadSByte();
			var optionsCount = reader.ReadUShort();
			var options_ = new HumanOption[optionsCount];
			for (var optionsIndex = 0; optionsIndex < optionsCount; optionsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				options_[optionsIndex] = objectToAdd;
			}
			options = options_;
		}

	}
}
