using System.Web;
using System.Web.Mvc;

namespace Vidly
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AuthorizeAttribute());
			//filters.Add(new RequireHttpsAttribute());//This filter is used for application to not to run on http. Application run only HTTPS
		}
	}
}
