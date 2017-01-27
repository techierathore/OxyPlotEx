using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace OxyPlotEx
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var vSampleData = new OxyExData();
            var vTabMain = new TabbedPage();
            vTabMain.Children.Add(new PieEx {Title="Pie", BindingContext= vSampleData });
            vTabMain.Children.Add(new AreaSeriesEx { Title="Area", BindingContext = vSampleData });
            vTabMain.Children.Add(new BarEx { Title = "Bar", BindingContext = vSampleData });
            vTabMain.Children.Add(new StackedBar { Title = "Stack-Bar", BindingContext = vSampleData });
            MainPage = vTabMain;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }

   
}
