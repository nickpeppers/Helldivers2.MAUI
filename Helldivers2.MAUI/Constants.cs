namespace Helldivers2.MAUI
{
    public static class Constants
    {
        //Helldivers2 api urls
        public const string WarStatusUrl = "https://helldiverstrainingmanual.com/api/v1/war/status";
        public const string WarInfoUrl = "https://helldiverstrainingmanual.com/api/v1/war/info";
        public const string WarNewsUrl = "https://helldiverstrainingmanual.com/api/v1/war/news";
        public const string WarCampaignUrl = "https://helldiverstrainingmanual.com/api/v1/war/campaign";
        public const string WarHistoryUrl = "https://helldiverstrainingmanual.com/api/v1/war/history/";
        public const string PlanetsUrl = "https://helldiverstrainingmanual.com/api/v1/planets";

        //Cache keys
        public const string Notes = "Notes";
        public const string Campaigns = "Campaigns";

        //Keys for passing Note data between ViewModels
        public const string NoteType = "NoteType";
        public const string ModifyNote = "ModifyNote";
        public const string AddNote = "AddNote";
        public const string CancelEdit = "CancelEdit";
        public const string RemoveNote = "RemoveNote";
    }
}