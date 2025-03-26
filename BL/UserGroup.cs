

using DAL;
using DAL_Interface;
using Entities;

namespace BL;

public class UserGroupBL : IGroupBL 
{
    private readonly IGroupDal _dal;

    public UserGroupBL(IGroupDal dal)
    {
        _dal = dal;
    }

    public IEnumerable < UserGroup> GetUserGroups()
    {
        return _dal.GetAllGroups();
    }

   
}
