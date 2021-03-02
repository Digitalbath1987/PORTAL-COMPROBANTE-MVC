using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALO.Entidades
{



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class Item_Seleccion
    {
        public int Id { get; set; }
        public string IdStr { get; set; }
        public string Nombre { get; set; }
        public string Orden { get; set; }

    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_RETURN_STATUS
    {
        public Decimal RETURN_VALUE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/

    public class iSP_READ_PAGO_COMP_CAB
    {
        public Int32 ID_PAGO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_PAGO_COMP_CAB
    {
        public Int32 NRO_PAGO { get; set; }
        public Int32 NRO_CAJA { get; set; }
        public DateTime FECHA_PAGO { get; set; }
        public String HORA_PAGO { get; set; }
        public String SUCURSAL { get; set; }
        public String IDENTIFICADOR { get; set; }
        public String NOMBRE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_PAGO_COMP_DET
    {
        [Range(1, int.MaxValue, ErrorMessage = "ID PAGO NO ES VALIDO")]
        [Required(ErrorMessage = "ID PAGO ES REQUERIDO")]
        public Int32 ID_PAGO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_PAGO_COMP_DET
    {
        public Int32 ID_INSTITUCION { get; set; }
        public String EMPRESA { get; set; }
        public String OPERACION { get; set; }
        public String PRODUCTO { get; set; }
        public String SUB_PRODUCTO { get; set; }
        public Decimal CAPITAL { get; set; }
        public Decimal INTERES { get; set; }
        public Decimal GASTOS_COBRANZA { get; set; }
        public Decimal OTROS_GASTOS { get; set; }
        public Decimal COSTAS_PERSONALES { get; set; }
        public Decimal COSTAS_PROCESALES { get; set; }
        public Decimal HONORARIO_ATRASO { get; set; }
        public Decimal INTERES_ATRASO { get; set; }
        public Int32 CUOTA { get; set; }
        public String FECHA_VENCIMIENTO { get; set; }
        public String TIPO_PAGO { get; set; }
        public String FECHA_DOCUMENTO { get; set; }
         public Int32 ID_TIPO_DEUDA_DETALLE { get; set; }
        
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class PAGOS_VIEW
    {
        public Int32 ID_PAGO { get; set; }
        public List<oSP_READ_PAGO_COMP_CAB> LST_CAB { get; set; }
        public List<oSP_READ_PAGO_COMP_DET> LST_DET { get; set; }

    }


}
