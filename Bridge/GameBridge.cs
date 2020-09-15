using System;

namespace Patterns.Bridge
{
	public interface IMobType
	{
		void Move();
		void Voice();
		void Attack();
		void Stay();
	}

	public class Dragon: IMobType
	{
		public void Move()
		{
			Console.WriteLine("Dragon is flying");
		}

		public void Voice()
		{
			Console.WriteLine("Dragon is screaming");
		}

		public void Attack()
		{
			Console.WriteLine("Dragon spits fire");
		}

		public void Stay()
		{
			Console.WriteLine("Dragon has landed");
		}
	}

	public class Spider: IMobType
	{
		public void Move()
		{
			Console.WriteLine("Spider runs on web");
		}

		public void Voice()
		{
			Console.WriteLine("Shhh!");
		}

		public void Attack()
		{
			Console.WriteLine("Spits poison");
		}

		public void Stay()
		{
			Console.WriteLine("Spider weaves a wave");
		}
	}

	public class PleasureScraper: IMobType
	{
		public void Move()
		{
			Console.WriteLine("Walks and watching");
		}

		public void Voice()
		{
			Console.WriteLine("...");
		}

		public void Attack()
		{
			Console.WriteLine("Bites");
		}

		public void Stay()
		{
			Console.WriteLine("Takes money");
		}
	}

	public abstract class Mob
	{
		protected IMobType _mobType;

		protected Mob(IMobType mobType)
		{
			_mobType = mobType;
		}

		public void OnBeingAttacked()
		{
			_mobType.Attack();
		}

		public abstract void DefaultBehaviour();
	}

	public class AggressiveMob: Mob
	{
		public AggressiveMob(IMobType mobType): base(mobType)
		{

		}

		public override void DefaultBehaviour()
		{
			_mobType.Move();
			_mobType.Attack();
		}
	}

	public class PassiveMob: Mob
	{
		public PassiveMob(IMobType mobType): base(mobType)
		{

		}

		public override void DefaultBehaviour()
		{
			_mobType.Stay();
			_mobType.Voice();
		}
	}
}