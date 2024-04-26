using Helldivers2.MAUI.Pages;

namespace Helldivers2.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ModifyNotesPage), typeof(ModifyNotesPage));
        }
    }
}