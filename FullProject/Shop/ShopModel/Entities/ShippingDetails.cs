using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ShopModel.Entities
{
    public class ShippingDetails:IDataErrorInfo
    {
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public string OnDateTime { get; set; }
        public string this[string columnName]
        {
            get
            {
                if ((columnName == "Name") && (string.IsNullOrEmpty(Name)))
                    return "Please input name";
                if ((columnName == "Name") && (Name.Length < 3)) return "Field Name May be at Least 3 chars";
                if ((columnName=="NumberPhone")&&(string.IsNullOrEmpty(NumberPhone)))
                return "Please input number phone";
                const string patternPhone =
                    @"^((((\+)?[0-9]\([0-9]-?[0-9]{3}\))|((\+)?[0-9]{2}-?[0-9]{3}))*-[0-9]{3}-?[0-9]{2}-?[0-9]{2})|([0-9]?[0-9]?[0-9]-?[0-9]{2}-?[0-9]{2})|(10[0-9])$";
                if ((columnName == "NumberPhone") && (!Regex.IsMatch(NumberPhone, patternPhone)))
                    return "Please input correct number phone";
                if ((columnName == "Address") && (string.IsNullOrEmpty(Address)))
                    return "Please input address";
                if ((columnName == "Address") && (Address.Length<10))
                    return "Please input valid address";
                return null;
            }
        }
        public string Error
        {
            get { return null; }
        }
    }
}
