using Authrz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Authrz.Utils
{


    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        readonly string[] _claim;

        public AuthorizationFilter(params string[] claim)
        {
            _claim = claim;
        }
        public string getUri(AuthorizationContext context, string controller, string action)
        {
            UrlHelper urlHelper = new UrlHelper(context.RequestContext);
            return urlHelper.Action( action, controller);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
        
            // N.V.T -- kiểm tra nếu không có yêu cầu nào thì cho phép truy cập 
            if (_claim.Length == 0)
            {
                return;
            }
            User user = (User)HttpContext.Current.Session["User"];

            if (user == null)
            {
                // Có thể trả về một trang Unauthorised khác
                filterContext.Result = new RedirectResult(getUri(filterContext, "Error", "Err403"));
                return;
            }

            // kiểm tra với danh sách yêu cầu
            bool flag = false;
            foreach (var item in _claim)
            {
                if (item.Equals(user.Role))
                    flag = true;
            }
            if (flag == false)
            {
                filterContext.Result = new RedirectResult(getUri(filterContext, "Error", "Err403"));
            }

        }

    }
}