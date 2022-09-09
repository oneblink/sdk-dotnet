namespace OneBlink.SDK.Model
{
    public class FormStoreSearchFreshdeskDependentFieldFilter : IFormStoreInterface
    {
        public FormStoreSearchStringArrayFilter category
        {
            get; set;
        }
        public FormStoreSearchStringArrayFilter subCategory
        {
            get; set;
        }
        public FormStoreSearchStringArrayFilter item
        {
            get; set;
        }
    }
}