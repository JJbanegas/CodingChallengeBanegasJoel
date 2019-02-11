/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Dtos;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        static ResourceManager rm = new ResourceManager("CodingChallenge.Data.Res",
        Assembly.GetExecutingAssembly());

        public static string Imprimir(List<Forma> formas, string lenguaje = "es-AR")
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{rm.GetString("Lista vacía de formas", new CultureInfo(lenguaje))}!</h1>");
            }
            else
            {
                sb.Append($"<h1>{rm.GetString("Reporte de Formas", new CultureInfo(lenguaje))}</h1>");
                var camposCalculados = ObtenerCamposCalculados(formas);
                var listaAgrupada = ObtenerListaAgrupada(camposCalculados);
                var lineas = ObtenerLineas(camposCalculados, listaAgrupada, lenguaje);
                foreach (var item in lineas)
                {
                    sb.Append(item);
                }

                // FOOTER
                sb.Append($"{rm.GetString("TOTAL", new CultureInfo(lenguaje))}:<br/>");
                sb.Append(formas.Count + " " + $"{rm.GetString("formas", new CultureInfo(lenguaje))}" + " ");
                sb.Append($"{rm.GetString("Perimetro", new CultureInfo(lenguaje))} " + (listaAgrupada.Select(x => x.Perimetro).Sum()).ToString("#.##") + " ");
                sb.Append($"{rm.GetString("Area", new CultureInfo(lenguaje))} " + (listaAgrupada.Select(x => x.Area).Sum()).ToString("#.##"));
            }

            return sb.ToString();
        }

        public static List<Forma> ObtenerCamposCalculados(List<Forma> formas)
        {
            List<Forma> valores = new List<Forma>();
            foreach (var item in formas)
            {
                Forma l = new Forma();
                l.Nombre = item.Nombre;
                l.Perimetro = (decimal)item.GetType().GetMethod("GetPerimetro").Invoke(item, null);
                l.Area = (decimal)item.GetType().GetMethod("GetArea").Invoke(item, null);
                valores.Add(l);
            }
            return valores;
        }

        public static List<string> ObtenerLineas(List<Forma> camposCalculados, List<Forma> listaAgrupada, string lenguaje)
        {
            List<string> lineasObtenidas = new List<string>();
            if (listaAgrupada.Count > 0)
            {
                foreach (var item in listaAgrupada)
                {
                    var cant = camposCalculados.Where(x => x.Nombre == item.Nombre).Count();
                    var nombre = cant > 1 ? item.Nombre + "s" : item.Nombre;
                    var y = $"{cant} {rm.GetString(nombre, new CultureInfo(lenguaje))} | {rm.GetString("Area", new CultureInfo(lenguaje))} {item.Area:#.##} | {rm.GetString("Perimetro", new CultureInfo(lenguaje))} {item.Perimetro:#.##} <br/>";
                    lineasObtenidas.Add(y);
                }
            }

            return lineasObtenidas;
        }

        public static List<Forma> ObtenerListaAgrupada(List<Forma> camposCalculados)
        {
            var lFiltro = (from x in camposCalculados
                           group x by x.Nombre into g
                           select new Forma()
                           {
                               Area = g.Sum(x => x.Area),
                               Perimetro = g.Sum(x => x.Perimetro),
                               Nombre = g.Key
                           }).ToList();
            return lFiltro;
        }
    }
}
