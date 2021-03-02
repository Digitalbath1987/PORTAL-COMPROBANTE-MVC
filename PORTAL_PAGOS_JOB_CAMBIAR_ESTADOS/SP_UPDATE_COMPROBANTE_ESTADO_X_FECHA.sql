USE [IBR_ALO_RECAUDACION]
GO

/****** Object:  StoredProcedure [dbo].[SP_CREATE_COB_DOCUMENTO]    Script Date: 22-02-2021 13:05:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure SP_UPDATE_COMPROBANTE_ESTADO_X_FECHA

As
Begin
SET ROWCOUNT 0
SET NOCOUNT ON
SET ANSI_NULLS OFF
/*-----------------------------------------------------------------*/
/*------------------------- Begin User Code -----------------------*/
/*-----------------------------------------------------------------*/
/*-----------------------------------------------------------------*/
/* DATOS DEL SERVICIO                                              */
/*-----------------------------------------------------------------*/
/* SISTEMA             : MANTENEDORES                              */
/* OBJETIVO            : INGRESO DE DATOS EN TABLA                 */
/*-----------------------------------------------------------------*/
/* PROGRAMADOR         : MARIO ROSALES FIGUEROA    			       */
/*-----------------------------------------------------------------*/
	DECLARE  @CUR_ID_COB_DOCUMENTO INT
	        ,@FECHA_ACTUAL         DATE = GETDATE()  


    DECLARE ACTUALIZAR_ESTADO_COMPROBANTE CURSOR FOR
		
		SELECT ID_COB_DOCUMENTO
		FROM   IBR_ALO_RECAUDACION..COB_DOCUMENTO WITH(NOLOCK)
		WHERE  FECHA_DEPOSITO          <= @FECHA_ACTUAL
		AND    ID_COB_ESTADO_DOCUMENTO  = 1

    OPEN ACTUALIZAR_ESTADO_COMPROBANTE
    FETCH NEXT FROM ACTUALIZAR_ESTADO_COMPROBANTE
		INTO @CUR_ID_COB_DOCUMENTO
    WHILE @@FETCH_STATUS = 0
    BEGIN

/*-----------------------------------------------------------------*/
/* ACTUALIZA ID_COB_ESTADO_DOCUMENTO                               */
/*-----------------------------------------------------------------*/
		UPDATE COB_DOCUMENTO
		SET ID_COB_ESTADO_DOCUMENTO = 6
		WHERE ID_COB_DOCUMENTO = @CUR_ID_COB_DOCUMENTO

	FETCH NEXT FROM ACTUALIZAR_ESTADO_COMPROBANTE
		INTO @CUR_ID_COB_DOCUMENTO
	END
	CLOSE ACTUALIZAR_ESTADO_COMPROBANTE
	DEALLOCATE ACTUALIZAR_ESTADO_COMPROBANTE
/*-----------------------------------------------------------------*/
/*------------------------- End User Code -------------------------*/
/*-----------------------------------------------------------------*/
End
GO


