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
	public class HumanOptionFollowers : HumanOption
	{
		public new const short Id = 2314;
		public override short TypeId => Id;
		public IEnumerable<IndexedEntityLook> followingCharactersLook { get; set; }

		public HumanOptionFollowers(IEnumerable<IndexedEntityLook> followingCharactersLook)
		{
			this.followingCharactersLook = followingCharactersLook;
		}

		public HumanOptionFollowers() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)followingCharactersLook.Count());
			foreach (var objectToSend in followingCharactersLook)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var followingCharactersLookCount = reader.ReadUShort();
			var followingCharactersLook_ = new IndexedEntityLook[followingCharactersLookCount];
			for (var followingCharactersLookIndex = 0; followingCharactersLookIndex < followingCharactersLookCount; followingCharactersLookIndex++)
			{
				var objectToAdd = new IndexedEntityLook();
				objectToAdd.Deserialize(reader);
				followingCharactersLook_[followingCharactersLookIndex] = objectToAdd;
			}
			followingCharactersLook = followingCharactersLook_;
		}

	}
}
