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
	public class ObjectItemMinimalInformation : Item
	{
		public new const short Id = 2903;
		public override short TypeId => Id;
		public ushort objectGID { get; set; }
		public IEnumerable<ObjectEffect> effects { get; set; }

		public ObjectItemMinimalInformation(ushort objectGID, IEnumerable<ObjectEffect> effects)
		{
			this.objectGID = objectGID;
			this.effects = effects;
		}

		public ObjectItemMinimalInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(objectGID);
			writer.WriteShort((short)effects.Count());
			foreach (var objectToSend in effects)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectGID = reader.ReadVarUShort();
			var effectsCount = reader.ReadUShort();
			var effects_ = new ObjectEffect[effectsCount];
			for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				effects_[effectsIndex] = objectToAdd;
			}
			effects = effects_;
		}

	}
}
