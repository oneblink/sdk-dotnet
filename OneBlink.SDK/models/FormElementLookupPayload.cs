
using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
	public class FormElementLookupPayload<T>
	{
		[JsonProperty]
		public Form definition
		{
			get; set;
		}
		[JsonProperty]
		public FormElement element
		{
			get; set;
		}

		[JsonProperty]
		public T submission
		{
			get; set;
		}
	}
}