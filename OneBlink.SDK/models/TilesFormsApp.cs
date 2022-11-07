namespace OneBlink.SDK.Model
{
    public class TilesFormsApp : FormsAppBase
    {
        public TilesFormsApp()
        {
            this.type = "TILES";
        }
        public string slug
        {
            get; set;
        }
        public FormsListStyles styles
        {
            get; set;
        }
    }
}