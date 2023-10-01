using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace raspaditaAPi.utilities
{
    public class ControllerMethods
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        public ControllerMethods(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        public IEnumerable<permiso> listaControladores()
        {
            DateTime fecha = DateTime.Now;
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
               ad => ad.AttributeRouteInfo != null && !ad.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any()).Select(ad => new permiso
               {
                   method = ad.ActionConstraints?.OfType<HttpMethodActionConstraint>().FirstOrDefault()?.HttpMethods.First(),
                   action = ad.RouteValues["action"],
                   controlador = ad.RouteValues["Controller"],
                   uri = (ad.AttributeRouteInfo != null) ? ad.AttributeRouteInfo.Template : "---------------",
                   tipo = "accion",
                   fecharegistro = fecha,
                   estado = true
               }).OrderBy(x => x.controlador).ToList();

            StreamReader r = new StreamReader("Utilities/vistas.json");
            string jsonVistas = r.ReadToEnd();
            List<permiso> permisosvista = JsonConvert.DeserializeObject<List<permiso>>(jsonVistas);
            permiso regpermiso = new permiso();
            foreach(var item in permisosvista)
            {
                regpermiso = new permiso();
                regpermiso.method = item.method;
                regpermiso.action = item.action;
                regpermiso.controlador = item.controlador;
                regpermiso.uri = item.uri;
                regpermiso.tipo = item.tipo;
                regpermiso.fecharegistro = fecha;
                regpermiso.estado = true;

                routes.Add(regpermiso);
            }

            IEnumerable<permiso> permisos = routes;
            return permisos;
        }
    }
}
