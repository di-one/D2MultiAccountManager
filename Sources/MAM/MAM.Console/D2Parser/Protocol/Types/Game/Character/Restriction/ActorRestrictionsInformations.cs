namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActorRestrictionsInformations
	{
		public const short Id  = 1254;
		public virtual short TypeId => Id;
		public bool cantBeAggressed { get; set; }
		public bool cantBeChallenged { get; set; }
		public bool cantTrade { get; set; }
		public bool cantBeAttackedByMutant { get; set; }
		public bool cantRun { get; set; }
		public bool forceSlowWalk { get; set; }
		public bool cantMinimize { get; set; }
		public bool cantMove { get; set; }
		public bool cantAggress { get; set; }
		public bool cantChallenge { get; set; }
		public bool cantExchange { get; set; }
		public bool cantAttack { get; set; }
		public bool cantChat { get; set; }
		public bool cantBeMerchant { get; set; }
		public bool cantUseObject { get; set; }
		public bool cantUseTaxCollector { get; set; }
		public bool cantUseInteractive { get; set; }
		public bool cantSpeakToNPC { get; set; }
		public bool cantChangeZone { get; set; }
		public bool cantAttackMonster { get; set; }
		public bool cantWalk8Directions { get; set; }

		public ActorRestrictionsInformations(bool cantBeAggressed, bool cantBeChallenged, bool cantTrade, bool cantBeAttackedByMutant, bool cantRun, bool forceSlowWalk, bool cantMinimize, bool cantMove, bool cantAggress, bool cantChallenge, bool cantExchange, bool cantAttack, bool cantChat, bool cantBeMerchant, bool cantUseObject, bool cantUseTaxCollector, bool cantUseInteractive, bool cantSpeakToNPC, bool cantChangeZone, bool cantAttackMonster, bool cantWalk8Directions)
		{
			this.cantBeAggressed = cantBeAggressed;
			this.cantBeChallenged = cantBeChallenged;
			this.cantTrade = cantTrade;
			this.cantBeAttackedByMutant = cantBeAttackedByMutant;
			this.cantRun = cantRun;
			this.forceSlowWalk = forceSlowWalk;
			this.cantMinimize = cantMinimize;
			this.cantMove = cantMove;
			this.cantAggress = cantAggress;
			this.cantChallenge = cantChallenge;
			this.cantExchange = cantExchange;
			this.cantAttack = cantAttack;
			this.cantChat = cantChat;
			this.cantBeMerchant = cantBeMerchant;
			this.cantUseObject = cantUseObject;
			this.cantUseTaxCollector = cantUseTaxCollector;
			this.cantUseInteractive = cantUseInteractive;
			this.cantSpeakToNPC = cantSpeakToNPC;
			this.cantChangeZone = cantChangeZone;
			this.cantAttackMonster = cantAttackMonster;
			this.cantWalk8Directions = cantWalk8Directions;
		}

		public ActorRestrictionsInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, cantBeAggressed);
			flag = BooleanByteWrapper.SetFlag(flag, 1, cantBeChallenged);
			flag = BooleanByteWrapper.SetFlag(flag, 2, cantTrade);
			flag = BooleanByteWrapper.SetFlag(flag, 3, cantBeAttackedByMutant);
			flag = BooleanByteWrapper.SetFlag(flag, 4, cantRun);
			flag = BooleanByteWrapper.SetFlag(flag, 5, forceSlowWalk);
			flag = BooleanByteWrapper.SetFlag(flag, 6, cantMinimize);
			flag = BooleanByteWrapper.SetFlag(flag, 7, cantMove);
			writer.WriteByte(flag);
			flag = BooleanByteWrapper.SetFlag(flag, 0, cantAggress);
			flag = BooleanByteWrapper.SetFlag(flag, 1, cantChallenge);
			flag = BooleanByteWrapper.SetFlag(flag, 2, cantExchange);
			flag = BooleanByteWrapper.SetFlag(flag, 3, cantAttack);
			flag = BooleanByteWrapper.SetFlag(flag, 4, cantChat);
			flag = BooleanByteWrapper.SetFlag(flag, 5, cantBeMerchant);
			flag = BooleanByteWrapper.SetFlag(flag, 6, cantUseObject);
			flag = BooleanByteWrapper.SetFlag(flag, 7, cantUseTaxCollector);
			writer.WriteByte(flag);
			flag = BooleanByteWrapper.SetFlag(flag, 0, cantUseInteractive);
			flag = BooleanByteWrapper.SetFlag(flag, 1, cantSpeakToNPC);
			flag = BooleanByteWrapper.SetFlag(flag, 2, cantChangeZone);
			flag = BooleanByteWrapper.SetFlag(flag, 3, cantAttackMonster);
			flag = BooleanByteWrapper.SetFlag(flag, 4, cantWalk8Directions);
			writer.WriteByte(flag);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			cantBeAggressed = BooleanByteWrapper.GetFlag(flag, 0);
			cantBeChallenged = BooleanByteWrapper.GetFlag(flag, 1);
			cantTrade = BooleanByteWrapper.GetFlag(flag, 2);
			cantBeAttackedByMutant = BooleanByteWrapper.GetFlag(flag, 3);
			cantRun = BooleanByteWrapper.GetFlag(flag, 4);
			forceSlowWalk = BooleanByteWrapper.GetFlag(flag, 5);
			cantMinimize = BooleanByteWrapper.GetFlag(flag, 6);
			cantMove = BooleanByteWrapper.GetFlag(flag, 7);
			flag = reader.ReadByte();
			cantAggress = BooleanByteWrapper.GetFlag(flag, 0);
			cantChallenge = BooleanByteWrapper.GetFlag(flag, 1);
			cantExchange = BooleanByteWrapper.GetFlag(flag, 2);
			cantAttack = BooleanByteWrapper.GetFlag(flag, 3);
			cantChat = BooleanByteWrapper.GetFlag(flag, 4);
			cantBeMerchant = BooleanByteWrapper.GetFlag(flag, 5);
			cantUseObject = BooleanByteWrapper.GetFlag(flag, 6);
			cantUseTaxCollector = BooleanByteWrapper.GetFlag(flag, 7);
			flag = reader.ReadByte();
			cantUseInteractive = BooleanByteWrapper.GetFlag(flag, 0);
			cantSpeakToNPC = BooleanByteWrapper.GetFlag(flag, 1);
			cantChangeZone = BooleanByteWrapper.GetFlag(flag, 2);
			cantAttackMonster = BooleanByteWrapper.GetFlag(flag, 3);
			cantWalk8Directions = BooleanByteWrapper.GetFlag(flag, 4);
		}

	}
}
