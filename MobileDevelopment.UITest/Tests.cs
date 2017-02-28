using NUnit.Framework;
using Xamarin.UITest;

namespace MobileDevelopment.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void OpenRepl()
        //{
        //    // Invoke the REPL so that we can explore the user interface
        //    app.Repl();
        //}

        [Test]
        public void TestQuantityIncrement()
        {
            app.Tap(x => x.Marked("OK"));
            app.Tap(x => x.Text("Товар"));
            app.WaitForElement(x => x.Text("Наименование товара"));
            app.Tap(x => x.Text("+"));
            app.Tap(x => x.Text("+"));
            app.WaitForElement(x => x.Text("2"));
            app.WaitForElement(x => x.Text("400"));
        }
    }
}

