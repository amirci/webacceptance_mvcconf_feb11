using System;
using System.Collections.Generic;
using System.IO;
using Cassini;
using MavenThought.Commons.Extensions;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Utility
{
    /// <summary>
    /// Steps related to browser operations
    /// </summary>
    public class Browser
    {
        /// <summary>
        /// Path to find the web application
        /// </summary>
        const string relativePath = @"main\MavenThought.MediaLibrary.WebClient";

        /// <summary>
        /// Port to use
        /// </summary>
        private static int Port = 8091;

        /// <summary>
        /// Main URL for the application
        /// </summary>
        private static readonly string ApplicationURL = string.Format("http://localhost:{0}", Port);

        /// <summary>
        /// Browser initialization
        /// </summary>
        static Browser()
        {
            // Get the path to the application
            var physicalPath = GetPhysicalPath();

            // Update database file configuration in the boo file
            UpdateConfiguraiton(physicalPath);

            // Initialize the web server
            WebServer = new Server(Port, "/", physicalPath);
        }

        /// <summary>
        /// Browser used or the tests
        /// </summary>
        public static IE Instance
        {
            get { return (IE) FeatureContext.Current["browser"]; }
            
            set { FeatureContext.Current["browser"] = value;  }
        }

        /// <summary>
        /// Get the web server
        /// </summary>
        protected static Server WebServer { get; private set; }

        /// <summary>
        /// Go to a path in the application
        /// </summary>
        /// <param name="path">Path to go</param>
        public static void GoTo(string path)
        {
            Instance.GoTo(String.Format("{0}/{1}", ApplicationURL, path));  
            Instance.Refresh();          
        }

        /// <summary>
        /// Initialize the browser
        /// </summary>
        public static void InitializeBrowser()
        {
            WebServer.Start();

            Instance = new IE(ApplicationURL);
        }

        /// <summary>
        /// Shutdown the browser
        /// </summary>
        public static void ShutdownBrowser()
        {
            Instance.Close();

            WebServer.Stop();
        }

        /// <summary>
        /// Calculates the physical path for the web application
        /// </summary>
        /// <returns>A string with the path</returns>
        private static string GetPhysicalPath()
        {
            var dir = Directory.GetCurrentDirectory();

            var index = dir.LastIndexOf("test");

            dir = dir.Remove(index);

            return Path.Combine(dir, relativePath);
        }

        /// <summary>
        /// Updates the boo configuration with the path to the storage
        /// </summary>
        /// <param name="applicationPath">Path to the web application</param>
        private static void UpdateConfiguraiton(string applicationPath)
        {
            // Get the file name
            var booConfigFileName = Path.Combine(applicationPath, "Global.boo");

            // Read the file and change the line
            var configFile = File.ReadAllLines(booConfigFileName);

            var index = configFile.IndexOf(line => line.Contains("databaseFile"));

            configFile[index] = string.Format("  databaseFile = \"{0}\"",Storage.DatabaseFile.Replace("\\", "/"));

            // Write the file
            File.WriteAllLines(booConfigFileName, configFile);
        }
    }
}