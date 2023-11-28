using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDTodos.Filter
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            if(context.HttpContext.Session.GetString("isAuth")== null)
            {
                context.Result = new RedirectResult("/User/Login");
            }
        }
    }
}
