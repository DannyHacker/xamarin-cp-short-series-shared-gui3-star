// Copyright 2019, Danny Hacker, Apache License 2.0, Soli Deo Gloria

using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace CPTest.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
