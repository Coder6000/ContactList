using System;
using System.Collections.Generic;
using System.IO;
using ContactList;

internal class Program
    {
        // TODO: Move the whole program to a "ContactApp" class and only have a ContactApp.Run(); Method in Main.

        static void Main(string[] args)
        {
            ContactApp contactApp = new ContactApp();

            contactApp.Run();
        }
    }
