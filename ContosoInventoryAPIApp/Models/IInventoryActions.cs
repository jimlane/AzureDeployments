using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ContosoInventoryAPIApp.Models
{
    [ServiceContract]
    public interface IInventoryActions
    {
        [WebGet(UriTemplate = "listInventoryXml",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<InventoryData> listInventoryXml();

        [WebGet(UriTemplate = "listInventoryJson",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<InventoryData> listInventoryJson();

        [WebGet(UriTemplate = "getProductXml",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        InventoryData getProductXml(int inventoryId);

        [WebGet(UriTemplate = "getProductJson",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        InventoryData getProductJson(int inventoryId);
    }
}
