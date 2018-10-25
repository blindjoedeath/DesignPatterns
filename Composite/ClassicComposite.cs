namespace Patterns.Composite
{
	using System;
	using System.Collections.Generic;

	public abstract class OperationSystem
	{
		public abstract void Work();
	}

	public class Windows : OperationSystem
	{
		public override void Work()
		{
			Console.WriteLine("Работаем плохо");
		}
	}

	public class Linux : OperationSystem
	{
		public override void Work()
		{
			Console.WriteLine("Работаем офигенно, но нет программ");
		}
	}

	public class Mac : OperationSystem
	{
		public override void Work()
		{
			Console.WriteLine("Работаем кайфово=)");
		}
	}

	public interface IVirtualMachine
	{
		void Run();
	}

	public class VirtualMachine : IVirtualMachine
	{
		private OperationSystem _os;

		public VirtualMachine(OperationSystem os)
		{
			_os = os;
		}

		public void Run()
		{
			_os.Work();
		}
	}

	public class VirtualMachineOfCrazy : IVirtualMachine
	{
		private List<IVirtualMachine> _virtualMachines = new List<IVirtualMachine>();

		public void Add(IVirtualMachine vm)
		{
			_virtualMachines.Add(vm);
		}

		public void Remove(IVirtualMachine vm)
		{
			_virtualMachines.Remove(vm);
		}

		public void Run()
		{
			foreach(var vm in _virtualMachines)
			{
				vm.Run();
			}
		}
	}
}

