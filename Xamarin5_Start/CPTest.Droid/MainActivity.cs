// Copyright 2019, Danny Hacker, Apache License 2.0, Soli Deo Gloria

using Android.App;
using Android.Widget;
using Android.OS;
using CPTest.Shared;

namespace CPTest.Droid
{
    [Activity(Label = "CPTest", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Calculate calc = new Calculate(1); //int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{calc.PostAdd(1)} clicks!"; }; // count++

            SharedButton mySharedButton = new SharedButton();
            mySharedButton.Init(0, 100, 200, 20, "My Shared Button", ButtonHandler);
            m_myButton.Click += delegate {
                mySharedButton.Click(m_myButton.GetX(), m_myButton.GetY());
            };
        }

        Button m_myButton;

        void ButtonHandler(SharedButton.ControlEvent control, float x, float y, float width, float height, string text)
        {
            switch (control)
            {
                case SharedButton.ControlEvent.Init:
                    var layout = FindViewById<LinearLayout>(Resource.Id.myLayout);
                    m_myButton = new Button(this);
                    m_myButton.Text = text;
                    layout.AddView(m_myButton);
                    break;
                case SharedButton.ControlEvent.Click:
                    m_myButton.Text = text;
                    break;
            }
        }
    }
}

