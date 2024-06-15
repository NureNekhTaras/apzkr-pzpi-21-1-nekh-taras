using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Static
{
    public class AuthHelper
    {
        public static ClaimsIdentity Authenticate(User user)
        {
            var coursesIds = new List<int>();
            var coursesNames = new List<string>();

            foreach (var course in user.Profile.Courses)
            {
                coursesIds.Add(course.Id);
                coursesNames.Add(course.Name);
            }

            var claims = new List<Claim>
            {
                new Claim("Login", user.Login),
                new Claim("Role", user.Profile.Role.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("CoursesIds", string.Join(',', coursesIds)),
                new Claim("CoursesNames", string.Join(',', coursesNames))
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
