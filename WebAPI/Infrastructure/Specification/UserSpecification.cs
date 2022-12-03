﻿using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Models;
using WebAPI.Specification;

namespace WebAPI.Infrastructure.Specification
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification(UserParams userParams) : base(x => 
            (!string.IsNullOrEmpty(userParams.Username) ? x.Username.ToLower().Contains(userParams.Username) : true))
        {
            if (!string.IsNullOrEmpty(userParams.Sort))
            {
                switch (userParams.Sort)
                {
                    case "registeredascending":
                        SortMethod(x => x.DateRegistered);
                        break;

                    case "registereddescending":
                        SortDescendingMethod(x => x.DateRegistered);
                        break;
                }
            }

            Includings.Add(x => x.Follows);
        }
    }
}
