using System;
using System.Collections.Generic;
using System.IO;

namespace dParadig.Models
{
    public class JefeAreaDL
    {
        public List<JefeArea> ObtenerJefes()
        {
            List<JefeArea> listaJefes = new List<JefeArea>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Jefes.txt");

            using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    var datos = linea.Split(';');

                    JefeArea jefeArea = new JefeArea();
                    jefeArea.IdJefe = int.Parse(datos[0].Trim());
                    jefeArea.Nombre = datos[1].Trim();
                    jefeArea.Apellidos = datos[2].Trim();

                    listaJefes.Add(jefeArea);
                }
            }

            return listaJefes;
        }

        public JefeArea ObtenerJefe(int codigo)
        {
            JefeArea jefeArea = new JefeArea();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Jefes.txt");

            using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                string linea;
                while ((linea = tr.ReadLine()) != null)
                {
                    var datos = linea.Split(';');
                    
                    if (codigo == int.Parse(datos[0].Trim()))
                    {
                        jefeArea.IdJefe = int.Parse(datos[0].Trim());
                        jefeArea.Nombre = datos[1].Trim();
                        jefeArea.Apellidos = datos[2].Trim();
                    }
                }
            }

            return jefeArea;
        }

        public string Crear(JefeArea jefeArea)
        {
            string resultado = "Correcto";
            List<JefeArea> listaJefes = new List<JefeArea>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Jefes.txt");
            string temp = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "JefesTemp.txt");
            int idNuevo = 0;

            try
            {
                using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    using (TextWriter writer = File.CreateText(temp))
                    {
                        string linea;
                        while ((linea = tr.ReadLine()) != null)
                        {
                            var datos = linea.Split(';');

                            writer.WriteLine(datos[0].Trim() + ";" + datos[1].Trim() + ";" + datos[2].Trim());
                            idNuevo = int.Parse(datos[0].Trim());
                        }
                        idNuevo++;

                        writer.WriteLine(idNuevo.ToString() + ";" + jefeArea.Nombre + ";" + jefeArea.Apellidos);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            finally
            {
                File.Delete(fuente);
                File.Move(temp, fuente);
            }

            return resultado;
        }

        public string Editar(JefeArea jefeArea)
        {
            string resultado = "Correcto";
            List<JefeArea> listaJefes = new List<JefeArea>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Jefes.txt");
            string temp = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "JefesTemp.txt");
            int idJefe = 0;

            try
            {
                using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    using (TextWriter writer = File.CreateText(temp))
                    {
                        string linea;
                        while ((linea = tr.ReadLine()) != null)
                        {
                            var datos = linea.Split(';');
                            idJefe = int.Parse(datos[0].Trim());

                            if (idJefe == jefeArea.IdJefe)
                            {
                                writer.WriteLine(jefeArea.IdJefe + ";" + jefeArea.Nombre.Trim() + ";" + jefeArea.Apellidos.Trim());
                            }
                            else
                            {
                                writer.WriteLine(datos[0].Trim() + ";" + datos[1].Trim() + ";" + datos[2].Trim());
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            finally
            {
                File.Delete(fuente);
                File.Move(temp, fuente);
            }

            return resultado;
        }

        public string Eliminar(int idJefe)
        {
            string resultado = "Correcto";
            List<JefeArea> listaJefes = new List<JefeArea>();
            string fuente = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "Jefes.txt");
            string temp = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Fuente"), "JefesTemp.txt");
            int idJefeActual = 0;

            try
            {
                using (TextReader tr = new StreamReader(new FileStream(fuente, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    using (TextWriter writer = File.CreateText(temp))
                    {
                        string linea;
                        while ((linea = tr.ReadLine()) != null)
                        {
                            var datos = linea.Split(';');
                            idJefeActual = int.Parse(datos[0].Trim());

                            if (idJefeActual == idJefe)
                            {
                                //Nada
                            }
                            else
                            {
                                writer.WriteLine(datos[0].Trim() + ";" + datos[1].Trim() + ";" + datos[2].Trim());
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            finally
            {
                File.Delete(fuente);
                File.Move(temp, fuente);
            }

            return resultado;
        }

    }
}