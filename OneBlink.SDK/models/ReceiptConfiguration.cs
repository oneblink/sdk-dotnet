using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public interface IReceiptConfiguration {
      string type {
        get; set;
      }
    }
    public class ReceiptTextComponent: IReceiptConfiguration
    {
       public string type {
        get; set;
       }

       public class configuration {
        public string type {
          get; set;
        }

        public string value {
          get; set;
        }
       }
    }
    public class ReceiptDateComponent: IReceiptConfiguration
    {
      public string type {
        get; set;
       }

       public class configuration {
        public string type {
          get; set;
        }

        public string format {
          get; set;
        }
       }
    }

    public class ReceiptRandomComponent: IReceiptConfiguration
    {
      public string type {
        get; set;
       }

       public class configuration {
        public string type {
          get; set;
        }

        public int length {
          get; set;
        }

        public Boolean numbers {
          get; set;
        }

        public Boolean lowercase {
          get; set;
        }

        public Boolean uppercase {
          get; set;
        }
       }
    }
}