using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL
    {
        public bool AddUser(UserDTO newUser)
        {
            //יוצרת מופע אוביקט ממחלקה של פעולות מסד נתונים
            DAL.UserDal dal = new();
            //יצירת אוביקט המגדיר את המיפוי בין אוביקט מסוג UserDTO לאוביקט מסוג User
            MapperConfiguration mapperConfiguration = new(cfg =>

                cfg
                //הגדרת מיפוי של פרופרטיות המקור והיעד
                .CreateMap<UserDTO, User>()

                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                //עבור שדה זמן יש להמיר את הערך לזמן תקין   
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToDateTime(new TimeOnly(0, 0, 0))))
                .ForMember(dest => dest, opt => opt.MapFrom(src => src.CreatedAt.ToDateTime(new TimeOnly(0, 0, 0))))
                
                );
            Mapper mapper = new(mapperConfiguration);
            User user = mapper.Map<User>(newUser);

            return dal.AddNewUser(user);
        }

        public List<UserDTO>  GetUsers( )
        {
            //יוצרת מופע אוביקט ממחלקה של פעולות מסד נתונים
            DAL.UserDal dal = new();
            var users = dal.GetUsers(); 

            //יצירת אוביקט המגדיר את המיפוי בין אוביקט מסוג UserDTO לאוביקט מסוג User
            MapperConfiguration mapperConfiguration = new(cfg =>

                cfg
                //הגדרת מיפוי של פרופרטיות המקור והיעד
                .CreateMap<User , UserDTO>()

                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                //עבור שדה זמן יש להמיר את הערך לזמן תקין   
                 .ForMember(dest => dest.MainGroup , opt => opt.MapFrom(src => src.UserGroupMemberships.FirstOrDefault().Group.GroupName  ))
                 .ForMember(dest => dest.NumberOfPrivatePermissions , opt => opt.MapFrom(src => src.UserPermissions.Count()  ))

                );
            Mapper mapper = new(mapperConfiguration);
            
            var   userDTOs = users.ConvertAll (u=> mapper.Map < UserDTO>  (u));

            return userDTOs;

        }
    }
}
