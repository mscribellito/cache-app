using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CacheApp.Models;

namespace CacheApp.Authorization
{
    public class ResourceIsOwnerAuthorizationHandler
                : AuthorizationHandler<OperationAuthorizationRequirement, IOwnable>
    {
        UserManager<IdentityUser> _userManager;

        public ResourceIsOwnerAuthorizationHandler(UserManager<IdentityUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   IOwnable resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.
            if (requirement.Name != Operations.Create.Name &&
                requirement.Name != Operations.Read.Name &&
                requirement.Name != Operations.Update.Name &&
                requirement.Name != Operations.Delete.Name)
            {
                return Task.CompletedTask;
            }

            if (resource.UserId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}