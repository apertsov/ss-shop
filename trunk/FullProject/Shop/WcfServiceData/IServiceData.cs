﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using ShopModel.Entities;

namespace WcfServiceData
{
    [ServiceContract]
    public interface IServiceData
    {
        [OperationContract]
        Category LoadCategory(int id);

        [OperationContract]
        List<Category> LoadAllCategory();

        [OperationContract]
        bool CreateCategory(Category category);

        [OperationContract]
        bool UpdateCategory(Category category);

        [OperationContract]
        bool DeleteCategory(Category category);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
