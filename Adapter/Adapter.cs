using System;
    
namespace Patterns.Adapter
{
    public interface IUserInterface
    {
        void OpenWindow();
        void CloseWindow();
    }

    public class WindowsUI : IUserInterface
    {
        public void OpenWindow()
        {
            Console.WriteLine("Bill Geits is opening the window");
        }

        public void CloseWindow()
        {
            Console.WriteLine("Bill Geits is closing the window");
        }
    }

    public class BillGeitsFan
    {
        public IUserInterface _ui;

        public BillGeitsFan(IUserInterface ui)
        {
            _ui = ui;
        }

        public void Use()
        {
            _ui.OpenWindow();
            _ui.CloseWindow();
        }
    }

    public class IOSInterface
    {
        public void UnlockDevice()
        {
            Console.WriteLine("Opened ios menu");
        }

        public void LockDevice()
        {
            Console.WriteLine("Closed ios menu");
        }
    }

    public class Adapter : IUserInterface
    {
        public IOSInterface _iosInterface;

        public Adapter (IOSInterface iosInterface)
        {
            _iosInterface = iosInterface;
        }

        public void OpenWindow()
        {
            _iosInterface.UnlockDevice();
        }

        public void CloseWindow()
        {
            _iosInterface.LockDevice();
        }
    }
}
