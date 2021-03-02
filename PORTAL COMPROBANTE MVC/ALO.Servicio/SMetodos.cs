using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALO.Entidades;
using ALO.Utilidades;

namespace ALO.Servicio
{
    public class SMetodos: IDisposable
    {

        /// <summary>
        /// DESTRUCTOR
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SMetodos()
        {


        }


        string SISTEMA = "WEB_COMPROBANTE";


        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_PAGO_COMP_CAB> SP_READ_PAGO_COMP_CAB(iSP_READ_PAGO_COMP_CAB Input)
        {
            List<oSP_READ_PAGO_COMP_CAB> ListaRest = new List<oSP_READ_PAGO_COMP_CAB>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_PAGO_COMP_CAB>("SP_READ_PAGO_COMP_CAB", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_PAGO_COMP_CAB>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_PAGO_COMP_DET> SP_READ_PAGO_COMP_DET(iSP_READ_PAGO_COMP_DET Input)
        {
            List<oSP_READ_PAGO_COMP_DET> ListaRest = new List<oSP_READ_PAGO_COMP_DET>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_PAGO_COMP_DET>("SP_READ_PAGO_COMP_DET", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_PAGO_COMP_DET>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


    }   



}
