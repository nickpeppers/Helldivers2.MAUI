namespace Helldivers2.MAUI.Pages;

public partial class ModifyNotesPage : BasePage
{
    public ModifyNotesPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        //NOTE: Prevent back button on Android from closing modal should improve this so back works
        return true;
    }
}