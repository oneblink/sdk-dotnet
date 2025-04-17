#pragma warning disable IDE1006 // Names are from OneBlink Types

using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class DrawingTool
    {
        public string type
        {
            get; set;
        }
        public List<GraphicAttributeOption> graphicAttributeOptions
        {
            get; set;
        }
    }
}