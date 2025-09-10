using AIMeetingNotesSummarizer.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;


namespace AIMeetingNotesSummarizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Resolve ViewModel from DI and set DataContext
            DataContext = App.Current.Services.GetRequiredService<MainViewModel>();
        }
    }
}