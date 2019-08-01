

public class English : Idiom
{

    public override string GetIdiomName()
    {
        return "English";
    }

    //MAIN MENU

    private string[] mainMenu = { "Start", "Settings", "Credits", "Exit" };

    public override string GetMainMenu(int index)
    {
        return mainMenu[index];
    }

    private string[] credits = { "Programmer", "Game Designer", "Story", "Animation", "Sound Artist", "Visual Artist", "Back" };
    public override string GetCredits(int index)
    {
        return "English";
    }


    private string[] Settings = { "Settings", "Music", "Effects", "Idiom", "Back"};
    public override string GetSettings(int index)
    {
        throw new System.NotImplementedException();
    }


}
