using System;

namespace Patterns.Bridge
{
	abstract class Controller
	{
		public void Draw()
		{
			Console.WriteLine("Drawing controller");
		}

		public abstract void Move();
	}

	class Keyboard : Controller
	{
		public override void Move()
		{
			Console.WriteLine("Нажали стрелку вправо/влево");
		}
	}

	class Gamepad : Controller
	{
		public override void Move()
		{
			Console.WriteLine("Наклонили стик");
		}
	}


	abstract class GameInterface
	{
		protected Controller _controller;

		public abstract void MovePlayer();

		protected GameInterface(Controller controller)
		{
			_controller = controller;
		}
	}

	class TouchInterface : GameInterface
	{
		public TouchInterface(Controller controller) : base(controller)
		{

		}

		public override void MovePlayer()
		{
			Console.WriteLine("Нажали на экран");
			_controller.Move();
		}
	}

	class RealInterface : GameInterface
	{
		public RealInterface(Controller controller) : base(controller)
		{

		}

		public override void MovePlayer()
		{
			Console.WriteLine("Взаимодействуем с реальным объектом");
			_controller.Move();
		}
	}
}