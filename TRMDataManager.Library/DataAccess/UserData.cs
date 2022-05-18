using System.Linq;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public UserModel GetUserById(string id)
        {
            var sql = new SqlDataAccess();
            
            var p = new { Id = id };

            var output = sql.LoadData<UserModel, dynamic>("dto.spUserLookup", p, "TRMData");
            
            return output.SingleOrDefault();
        }
    }
}