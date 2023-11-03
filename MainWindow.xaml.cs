using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Reporter.Data;
using Reporter.Services;

namespace Reporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddMasaBlazor();

            serviceCollection.AddDbContext<ReporterDbContext>(opts =>
            {
                opts.UseSqlite("Data Source=reporter.db");
            });

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            var services = serviceCollection.BuildServiceProvider();

            Resources.Add("services", services);

            using var scoped = services.CreateScope();
            try
            {
                using var db = scoped.ServiceProvider.GetRequiredService<ReporterDbContext>();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }
    }
}