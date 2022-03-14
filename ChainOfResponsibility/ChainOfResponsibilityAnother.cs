using System;
using System.Linq;
using System.Collections.Generic;	

namespace Patterns.ChainOfResponsibilityAnother
{
    public abstract class UIResponder
    {
        public UIResponder Parent;

        private bool _isUserInteractionEnabled = true;

        public bool IsUserInteractionEnabled
        { 
            get
            {
                var parentState = this.Parent?.IsUserInteractionEnabled ?? true;
                return this._isUserInteractionEnabled && parentState;
            }
            set
            {
                this._isUserInteractionEnabled = value;
            }
        }
    }

    public class View: UIResponder
    {
        public void AddSubview(View view)
        {
            view.Parent = this;
        }

        public void OnClick()
        {
            if (this.IsUserInteractionEnabled)
            {
                Console.WriteLine("View reacts on interaction");
            }
            else
            {
                Console.WriteLine("View is not interactable");
            }
        }
    }

    public class ShowCase
    {
        public void Run()
        {
            var mainView = new View();
            var container = new View();
            var button = new View();

            mainView.AddSubview(container);
            container.AddSubview(button);

            Console.WriteLine("Button initial reaction:");
            button.OnClick();

            mainView.IsUserInteractionEnabled = false;
            Console.WriteLine("Button reaction after screen view interaction disabled:");
            button.OnClick();
        }
    }
}