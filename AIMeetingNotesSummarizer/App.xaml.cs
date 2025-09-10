using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AIMeetingNotesSummarizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current!;
        public IServiceProvider Services { get; }


        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            Services = services.BuildServiceProvider();
            InitializeComponent();
        }


        private void ConfigureServices(ServiceCollection services)
        {
            // ViewModels
            services.AddSingleton<ViewModels.MainViewModel>();


            // Services
            services.AddSingleton<Services.ITranscriptionService, Services.StubTranscriptionService>();
            services.AddSingleton<Services.ISummarizationService, Services.SimpleSummarizationService>();
            services.AddSingleton<Services.IPersistenceService, Services.FilePersistenceService>();
        }
    }
}