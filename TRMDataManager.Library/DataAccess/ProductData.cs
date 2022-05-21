using System.Collections.Generic;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            var sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("dto.spProductGetAll",
                new {}, "TRMData");

            return output;
        }
    }
}
