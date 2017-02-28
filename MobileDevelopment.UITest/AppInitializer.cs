using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MobileDevelopment.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            FileInfo fileInfo = new FileInfo(currentFile);
            string directory = fileInfo.Directory.Parent.Parent.Parent.FullName;
            var pathToAPK = Path.Combine(directory, "MobileDevelopment", "MobileDevelopment.Droid", "bin", "Release", "MobileDevelopment.Droid.APK");

            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(pathToAPK)
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

