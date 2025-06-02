using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
  public class DynamicListOptionAttribute
  {
    /// <summary>
    /// The label to display in the forms builder when selecting an element to match the "value" property. E.g. if this options set is for Cities (Sydney, Brisbane, Melbourne) and the parent options set is for States (NSW, QLD, VIC), this label could be "State".
    /// </summary>
    public string label
    {
      get; set;
    }

    /// <summary>
    /// The value of the parent form element option to filter this option. E.g. if this options set is for Cities (Sydney, Brisbane, Melbourne) and the parent options set is for States (NSW, QLD, VIC) and this option represented Sydney, this value would be "NSW".
    /// </summary>
    public string value
    {
      get; set;
    }
  }

  public class DynamicListOption
  {
    /// <summary>
    /// The label displayed to the user for an individual option.
    /// </summary>
    public string label
    {
      get; set;
    }

    /// <summary>
    /// The value for an individual option, sent with form submission data.
    /// </summary>
    public string value
    {
      get; set;
    }

    /// <summary>
    /// An array of option attributes associated with an individual option.
    /// </summary>
    public List<DynamicListOptionAttribute> attributes
    {
      get; set;
    }

    /// <summary>
    /// The color of the button used to display the option, if the element has `buttons` configured as `true`.
    /// </summary>
    public string colour
    {
      get; set;
    }

    /// <summary>
    /// For autocomplete elements this option will always appear in the search results.
    /// </summary>
    public bool displayAlways
    {
      get; set;
    }

    /// <summary>
    /// An image associated with this option.
    /// </summary>
    public string imageUrl
    {
      get; set;
    }
  }
}
