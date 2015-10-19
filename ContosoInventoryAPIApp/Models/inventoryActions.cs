using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;


namespace ContosoInventoryAPIApp.Models
{
    public class InventoryActions : IInventoryActions
    {
        //private readonly InventoryDbContext _db = new InventoryDbContext(ConfigurationManager.ConnectionStrings["AdventureWorks2012ConnectionString"].ConnectionString);

        public InventoryActions()
        { }

        [WebGet(UriTemplate = "listInventoryXml",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<InventoryData> listInventoryXml()
        {
            List<InventoryData> data = new List<InventoryData>();
            AdventureWorks2012Entities dbContext = new AdventureWorks2012Entities();
            return (from i in dbContext.vProductAndDescriptions
                    select new InventoryData
                    {
                        partID = i.ProductID,
                        partName = i.ProductModel,
                        partDescription = i.Description
                    }
                    ).Take(10).ToList<InventoryData>();

        }

        [WebGet(UriTemplate = "listInventoryJson",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<InventoryData> listInventoryJson()
        {
            List<InventoryData> data = new List<InventoryData>();
            AdventureWorks2012Entities dbContext = new AdventureWorks2012Entities();
            return (from i in dbContext.vProductAndDescriptions
                    select new InventoryData
                    {
                        partID = i.ProductID,
                        partName = i.ProductModel,
                        partDescription = i.Description
                    }
                    ).Take(10).ToList<InventoryData>();
        }

        [WebGet(UriTemplate = "getProductXml?id={productID}",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        public InventoryData getProductXml(int productId)
        {
            List<InventoryData> data = new List<InventoryData>();
            AdventureWorks2012Entities dbContext = new AdventureWorks2012Entities();
            return (from i in dbContext.vProductAndDescriptions
                    where i.ProductID == productId
                    select new InventoryData
                    {
                        partID = i.ProductID,
                        partName = i.ProductModel,
                        partDescription = i.Description
                    }
                    ).FirstOrDefault();
        }

        [WebGet(UriTemplate = "getProductJson?id={productID}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        public InventoryData getProductJson(int productId)
        {
            List<InventoryData> data = new List<InventoryData>();
            AdventureWorks2012Entities dbContext = new AdventureWorks2012Entities();
            return (from i in dbContext.vProductAndDescriptions
                    where i.ProductID == productId
                    select new InventoryData
                    {
                        partID = i.ProductID,
                        partName = i.ProductModel,
                        partDescription = i.Description
                    }
                    ).FirstOrDefault();
        }
    }
}
