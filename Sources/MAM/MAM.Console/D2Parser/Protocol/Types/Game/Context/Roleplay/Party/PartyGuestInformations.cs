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
	public class PartyGuestInformations
	{
		public const short Id  = 6594;
		public virtual short TypeId => Id;
		public ulong guestId { get; set; }
		public ulong hostId { get; set; }
		public string name { get; set; }
		public EntityLook guestLook { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public PlayerStatus status { get; set; }
		public IEnumerable<PartyEntityBaseInformation> entities { get; set; }

		public PartyGuestInformations(ulong guestId, ulong hostId, string name, EntityLook guestLook, sbyte breed, bool sex, PlayerStatus status, IEnumerable<PartyEntityBaseInformation> entities)
		{
			this.guestId = guestId;
			this.hostId = hostId;
			this.name = name;
			this.guestLook = guestLook;
			this.breed = breed;
			this.sex = sex;
			this.status = status;
			this.entities = entities;
		}

		public PartyGuestInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(guestId);
			writer.WriteVarULong(hostId);
			writer.WriteUTF(name);
			guestLook.Serialize(writer);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
			writer.WriteShort((short)entities.Count());
			foreach (var objectToSend in entities)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			guestId = reader.ReadVarULong();
			hostId = reader.ReadVarULong();
			name = reader.ReadUTF();
			guestLook = new EntityLook();
			guestLook.Deserialize(reader);
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
			var entitiesCount = reader.ReadUShort();
			var entities_ = new PartyEntityBaseInformation[entitiesCount];
			for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
			{
				var objectToAdd = new PartyEntityBaseInformation();
				objectToAdd.Deserialize(reader);
				entities_[entitiesIndex] = objectToAdd;
			}
			entities = entities_;
		}

	}
}
