using System.ComponentModel;

namespace ShopModel.Entities
{
    public class ShippingDetails:IDataErrorInfo
    {
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public string this[string columnName]
        {
            get
            {
                if ((columnName == "Name") && (string.IsNullOrEmpty(Name)))
                    return "Please input name";
                if ((columnName=="NumberPhone")&&(string.IsNullOrEmpty(NumberPhone)))
                return "Please input number phone";
                if ((columnName == "Address") && (string.IsNullOrEmpty(Address)))
                    return "Please input address";
                return null;
            }
        }
        public string Error
        {
            get { return null; }
        }
    }
}
