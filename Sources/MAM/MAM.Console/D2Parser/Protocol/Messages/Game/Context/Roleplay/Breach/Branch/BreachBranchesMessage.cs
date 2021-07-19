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
	public class BreachBranchesMessage : NetworkMessage
	{
		public const uint Id = 1846;
		public override uint MessageId => Id;
		public IEnumerable<ExtendedBreachBranch> branches { get; set; }

		public BreachBranchesMessage(IEnumerable<ExtendedBreachBranch> branches)
		{
			this.branches = branches;
		}

		public BreachBranchesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)branches.Count());
			foreach (var objectToSend in branches)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var branchesCount = reader.ReadUShort();
			var branches_ = new ExtendedBreachBranch[branchesCount];
			for (var branchesIndex = 0; branchesIndex < branchesCount; branchesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<ExtendedBreachBranch>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				branches_[branchesIndex] = objectToAdd;
			}
			branches = branches_;
		}

	}
}
