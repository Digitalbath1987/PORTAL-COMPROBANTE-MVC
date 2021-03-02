using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;
using Rotativa;


namespace ALO.WebSite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            ViewBag.Mensaje = "";
            return View();

        }


        public ActionResult Print(int ID_PAGO)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PAGO_COMP_CAB> LST_CAB = new List<oSP_READ_PAGO_COMP_CAB>();
                List<oSP_READ_PAGO_COMP_DET> LST_DET = new List<oSP_READ_PAGO_COMP_DET>();


                //===========================================================
                // LLAMAR CABECERA                                
                //===========================================================
                LST_CAB = LEER_CABECERA(ID_PAGO);

                if (LST_CAB == null)
                {
                    ViewBag.Mensaje = "NO SE ENCONTRARON DATOS ASOCIADOS A SU ID PAGO";
                    return View("Error");
                }
 

                //===========================================================
                // LLAMAR DETALLE                                
                //===========================================================
                LST_DET = LEER_DETALLES(ID_PAGO);

                if (LST_DET == null)
                {
                    ViewBag.Mensaje = "NO SE ENCONTRARON DATOS ASOCIADOS A SU ID PAGO";
                    return View("Error");
                }


                //===========================================================
                // SE CREA OBJETO COMPLEJO
                //===========================================================

                PAGOS_VIEW Pagos_View = new PAGOS_VIEW();
                    Pagos_View.ID_PAGO = ID_PAGO;
                    Pagos_View.LST_CAB = LST_CAB;
                    Pagos_View.LST_DET = LST_DET;

                //===========================================================
                // RETORNA VIEW
                //===========================================================
                return new ActionAsPdf("Pdf", new { ID_PAGO = ID_PAGO })
                { FileName = "Comprobante_Pago_" + ID_PAGO.ToString() + ".pdf",
                  PageSize = Rotativa.Options.Size.A4
                };



            }
            catch
            {
                ViewBag.Mensaje = "ERROR DE CONECCION";
                return View("Error");
            }
        }



    
        public ActionResult Pagos(int ID_PAGO)
        {
            try
            {
                    //===========================================================
                    // DECLARACION DE VARIABLES                                
                    //===========================================================
                    List<oSP_READ_PAGO_COMP_CAB> LST_CAB = new List<oSP_READ_PAGO_COMP_CAB>();
                    List<oSP_READ_PAGO_COMP_DET> LST_DET = new List<oSP_READ_PAGO_COMP_DET>();
  

                    //===========================================================
                    // LLAMAR CABECERA                                
                    //===========================================================
                    LST_CAB = LEER_CABECERA(ID_PAGO);

                    if (LST_CAB == null)
                    {
                         ViewBag.Mensaje = "NO SE ENCONTRARON DATOS ASOCIADOS A SU ID PAGO";
                         return View("Error");
                    }
 

                    //===========================================================
                    // LLAMAR DETALLE                                
                    //===========================================================
                    LST_DET = LEER_DETALLES(ID_PAGO);

                    if (LST_DET == null)
                    {
                        ViewBag.Mensaje = "NO SE ENCONTRARON DATOS ASOCIADOS A SU ID PAGO";
                        return View("Error");
                    }


                    //===========================================================
                    // SE CREA OBJETO COMPLEJO
                    //===========================================================

                    PAGOS_VIEW Pagos_View = new PAGOS_VIEW();
                    Pagos_View.ID_PAGO = ID_PAGO;
                    Pagos_View.LST_CAB = LST_CAB;
                    Pagos_View.LST_DET = LST_DET;

                    //===========================================================
                    // RETORNA VIEW
                    //===========================================================
                     return View(Pagos_View);


            }
            catch
            {
                ViewBag.Mensaje = "ERROR DE CONECCION";
                return View("Error");
            }
        }




        public ActionResult Pdf(int ID_PAGO)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PAGO_COMP_CAB> LST_CAB = new List<oSP_READ_PAGO_COMP_CAB>();
                List<oSP_READ_PAGO_COMP_DET> LST_DET = new List<oSP_READ_PAGO_COMP_DET>();


                //===========================================================
                // LLAMAR CABECERA                                
                //===========================================================
                LST_CAB = LEER_CABECERA(ID_PAGO);


                if (LST_CAB == null)
                {
                    ViewBag.Mensaje = "NO SE ENCONTRARON DATOS ASOCIADOS A SU ID PAGO";
                    return View("Error");
                }



                //===========================================================
                // LLAMAR DETALLE                                
                //===========================================================
                LST_DET = LEER_DETALLES(ID_PAGO);

                if (LST_DET == null)
                {
                    ViewBag.Mensaje = "NO SE ENCONTRARON DATOS ASOCIADOS A SU ID PAGO";
                    return View("Error");
                }


                //===========================================================
                // SE CREA OBJETO COMPLEJO
                //===========================================================

                PAGOS_VIEW Pagos_View = new PAGOS_VIEW();
                Pagos_View.ID_PAGO = ID_PAGO;
                Pagos_View.LST_CAB = LST_CAB;
                Pagos_View.LST_DET = LST_DET;

                //===========================================================
                // RETORNA VIEW
                //===========================================================
                return View(Pagos_View);




            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "ERROR DE CONECCION";
                return View("Error");
            }
        }








        /// <summary>
        /// LEER DETALLES
        /// </summary>
        /// <param name="ID_PAGO"></param>
        /// <returns></returns>
        private List<oSP_READ_PAGO_COMP_DET> LEER_DETALLES(int ID_PAGO)
        {

            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PAGO_COMP_DET> LST_REST = new List<oSP_READ_PAGO_COMP_DET>();


                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_PAGO_COMP_DET ParametrosInput = new iSP_READ_PAGO_COMP_DET();
                ParametrosInput.ID_PAGO = ID_PAGO;


                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                using (SMetodos Servicio = new SMetodos())
                {
                    LST_REST = Servicio.SP_READ_PAGO_COMP_DET(ParametrosInput);
                }

                if (LST_REST == null)
                {
                    return null;
                }
                if (LST_REST.Count <= 0)
                {
                    return null;
                }



                //===========================================================
                // VERIFICAR BLOQUEOS
                //===========================================================
                return LST_REST;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER CABECERA
        /// </summary>
        /// <param name="ID_PAGO"></param>
        /// <returns></returns>
        private List<oSP_READ_PAGO_COMP_CAB> LEER_CABECERA(int ID_PAGO)
        {

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PAGO_COMP_CAB> LST_REST = new List<oSP_READ_PAGO_COMP_CAB>();


                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_PAGO_COMP_CAB ParametrosInput = new iSP_READ_PAGO_COMP_CAB();
                ParametrosInput.ID_PAGO = ID_PAGO;


                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                using (SMetodos Servicio = new SMetodos())
                {
                    LST_REST = Servicio.SP_READ_PAGO_COMP_CAB(ParametrosInput);
                }

                if (LST_REST == null)
                {
                    return null;
                }
                if (LST_REST.Count <= 0)
                {
                    return null;
                }

                //===========================================================
                // VERIFICAR BLOQUEOS
                //===========================================================
                return LST_REST;
            }
            catch
            {
                throw;
            }
        }













    }
}