namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SetUpdateMessage : NetworkMessage
	{
		public const uint Id = 8665;
		public override uint MessageId => Id;
		public ushort setId { get; set; }
		public IEnumerable<ushort> setObjects { get; set; }
		public IEnumerable<ObjectEffect> setEffects { get; set; }

		public SetUpdateMessage(ushort setId, IEnumerable<ushort> setObjects, IEnumerable<ObjectEffect> setEffects)
		{
			this.setId = setId;
			this.setObjects = setObjects;
			this.setEffects = setEffects;
		}

		public SetUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(setId);
			writer.WriteShort((short)setObjects.Count());
			foreach (var objectToSend in setObjects)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)setEffects.Count());
			foreach (var objectToSend in setEffects)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			setId = reader.ReadVarUShort();
			var setObjectsCount = reader.ReadUShort();
			var setObjects_ = new ushort[setObjectsCount];
			for (var setObjectsIndex = 0; setObjectsIndex < setObjectsCount; setObjectsIndex++)
			{
				setObjects_[setObjectsIndex] = reader.ReadVarUShort();
			}
			setObjects = setObjects_;
			var setEffectsCount = reader.ReadUShort();
			var setEffects_ = new ObjectEffect[setEffectsCount];
			for (var setEffectsIndex = 0; setEffectsIndex < setEffectsCount; setEffectsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				setEffects_[setEffectsIndex] = objectToAdd;
			}
			setEffects = setEffects_;
		}

	}
}
