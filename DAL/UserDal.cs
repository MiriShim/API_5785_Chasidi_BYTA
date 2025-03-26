using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace DAL
{
    public class UserDal
    {
        public bool AddNewUser(User newUser)
        {
            try
            {
                //צור אוביקט ממחלקת הקונטקסט הראשית, אשר יודע לנהל את כל הפעולות מול מסד הנתונים
                ShimonovichUserAccountsContext context = new();
                //הוסף את היוזר החדש לרשימת היוזרים הקיימת בקונטקסט
                context.Users.Add(newUser);
                //שמור את כל השינויים שנעשו בקונטקסט כמו הוספת רשומה הפעם, לתוך מסד הנתונים האמיתי
                context.SaveChanges();
                return true;//הצלחתי!
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User > GetUsers()
        {
            try
            {
                //צור אוביקט ממחלקת הקונטקסט הראשית, אשר יודע לנהל את כל הפעולות מול מסד הנתונים
                ShimonovichUserAccountsContext context = new();
                  
                return context.Users.Include(a=>a.UserPermissions ).Include(u=>u.UserGroupMemberships).ToList();  
            }
            catch (Exception ex)
            {
                 
                return null;
            }
        }
    }
}
