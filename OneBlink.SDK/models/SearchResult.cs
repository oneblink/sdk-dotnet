namespace OneBlink.SDK.Model
{
    public abstract class SearchResult
    {
        public SearchMeta meta
        {
            get; set;
        }
    }

    public class SearchMeta
    {
        public long? limit
        {
            get; set;
        }
        public long? offset
        {
            get; set;
        }
        public long? nextOffset
        {
            get; set;
        }
        public long? total
        {
            get; set;
        }
    }
}
