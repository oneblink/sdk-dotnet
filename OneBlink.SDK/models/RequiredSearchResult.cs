namespace OneBlink.SDK.Model
{
    public abstract class RequiredSearchResult
    {
        public RequiredSearchMeta meta
        {
            get; set;
        }
    }

    public class RequiredSearchMeta
    {
        public long limit
        {
            get; set;
        }
        public long offset
        {
            get; set;
        }
        public long? nextOffset
        {
            get; set;
        }
    }
}
