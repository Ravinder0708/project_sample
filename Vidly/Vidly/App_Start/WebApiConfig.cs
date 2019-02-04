using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vidly
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var settings=config.Formatters.JsonFormatter.SerializerSettings;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Formatting = Formatting.Indented;

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// Adding formatter for Json   
			config.Formatters.JsonFormatter.MediaTypeMappings.Add(
				new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

			// Adding formatter for XML   
			config.Formatters.XmlFormatter.MediaTypeMappings.Add(
				new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
		}
	}
}
