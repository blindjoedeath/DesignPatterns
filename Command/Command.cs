namespace Patterns.Command 
{
    public interface ICommand
    {
        void Execute();
    }

    public class JumpCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("User jumps");
        }
    }

    public class FireCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("User fires");
        }
    }

    public class UseCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("User uses something");
        }
    }

    public enum InputKey
    {
        SPACE,
        MOUSE_CLICK,
        F
    }

    public class KeyboardMapper
    {
        Dictionary<InputKey, ICommand> Commands = new Dictionary<InputKey, ICommand>() 
        {
            { InputKey.SPACE, new JumpCommand() },
            { InputKey.MOUSE_CLICK, new FireCommand() },
            { InputKey.F, new UseCommand() } 
        };

        public void OnInput(InputKey key)
        {
            this.Commands[key].Execute();
        }
    }
    
    public enum GamepadKey
    {
        X,
        R2,
        Triangle
    }

    public class GamepadMapper
    {
        Dictionary<GamepadKey, ICommand> Commands = new Dictionary<GamepadKey, ICommand>() 
        {
            { GamepadKey.X, new JumpCommand() },
            { GamepadKey.R2, new FireCommand() },
            { GamepadKey.Triangle, new UseCommand() } 
        };

        public void OnInput(GamepadKey key)
        {
            this.Commands[key].Execute();
        }
    }

    public class ShowCase
    {
        public void Run()
        {
            var keyboard = new KeyboardMapper();
            keyboard.OnInput(InputKey.MOUSE_CLICK);

            var gamepad = new GamepadMapper();
            gamepad.OnInput(GamepadKey.X);
        }
    }
}