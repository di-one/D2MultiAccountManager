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
	public class RemodelingInformation
	{
		public const short Id  = 6924;
		public virtual short TypeId => Id;
		public string name { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public ushort cosmeticId { get; set; }
		public IEnumerable<int> colors { get; set; }

		public RemodelingInformation(string name, sbyte breed, bool sex, ushort cosmeticId, IEnumerable<int> colors)
		{
			this.name = name;
			this.breed = breed;
			this.sex = sex;
			this.cosmeticId = cosmeticId;
			this.colors = colors;
		}

		public RemodelingInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteVarUShort(cosmeticId);
			writer.WriteShort((short)colors.Count());
			foreach (var objectToSend in colors)
            {
				writer.WriteInt(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			cosmeticId = reader.ReadVarUShort();
			var colorsCount = reader.ReadUShort();
			var colors_ = new int[colorsCount];
			for (var colorsIndex = 0; colorsIndex < colorsCount; colorsIndex++)
			{
				colors_[colorsIndex] = reader.ReadInt();
			}
			colors = colors_;
		}

	}
}
