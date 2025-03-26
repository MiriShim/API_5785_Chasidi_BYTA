using Entities;

namespace BL
{
    public interface  IGroupBL
    {
        public IEnumerable<UserGroup> GetUserGroups();
        
    }
}