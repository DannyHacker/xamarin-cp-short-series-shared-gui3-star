// Copyright 2019, Danny Hacker, Apache License 2.0, Soli Deo Gloria

using System;
using CPTest.Shared;
using UIKit;

namespace CPTest.iOS
{
    public partial class ViewController : UIViewController
    {
        Calculate calc = new Calculate(1); //int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", calc.PostAdd(1)); //count++);
                Button.SetTitle(title, UIControlState.Normal);
            };

            SharedButton mySharedButton = new SharedButton();
            mySharedButton.Init(0, 100, 200, 20, "My Shared Button", ButtonHandler);
            m_myButton.TouchUpInside += delegate
            {
                mySharedButton.Click((float)m_myButton.Frame.X, (float)m_myButton.Frame.Y);
            };
        }

        UIButton m_myButton;

        void ButtonHandler(SharedButton.ControlEvent control, float x, float y, float width, float height, string text)
        {
            switch (control)
            {
                case SharedButton.ControlEvent.Init:

                    m_myButton = UIButton.FromType(UIButtonType.System);
                    m_myButton.SetTitle(text, UIControlState.Normal);
                    m_myButton.Frame = new CoreGraphics.CGRect(x, y, width, height);
                    View.Add(m_myButton);
                    break;
                case SharedButton.ControlEvent.Click:
                    m_myButton.SetTitle(text, UIControlState.Normal);
                    break;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
