using System;
using System.Collections.Generic;	

namespace Patterns.Composite
{
	public abstract class PackageBase
	{
		public List<PackageBase> _dependencies = new List<PackageBase>();

		public bool IsLibrary{get;}

		protected PackageBase(bool isLibrary)
		{
			IsLibrary = isLibrary;
		}

		public virtual void Add(PackageBase package)
		{
			if (!IsLibrary)
			{
				throw new Exception();
			}
			_dependencies.Add(package);
		}

		public virtual void Remove(PackageBase package)
		{
			if (!IsLibrary)
			{
				throw new Exception();
			}
			_dependencies.Remove(package);
		}

		public abstract void Install();
	}

	public class Package : PackageBase
	{
		public Package() : base(false)
		{

		}

		public override void Install()
		{
			Console.WriteLine("Installing Package");
		}
	}

	public class Library : PackageBase
	{

		public Library() : base(true)
		{

		}

		public override void Install()
		{
			foreach(var package in _dependencies)
			{
				package.Install();
			}
		}
	}
}