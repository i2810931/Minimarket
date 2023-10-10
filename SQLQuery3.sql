/*
CREADO POR CSAR LAZO VEGA
2023-10-08
Elimina un registro específico,
en la tabla categorias.
*/
CREATE PROCEDURE USP_Eliminar_Ca
    @nCodigo_Ca INT
AS
BEGIN
    
    IF EXISTS (SELECT 1 FROM Categorias WHERE cod_categ = @nCodigo_Ca)
    BEGIN
        
        DELETE FROM Categorias WHERE cod_categ = @nCodigo_Ca;
        PRINT 'Registro eliminado correctamente.';
    END
    ELSE
    BEGIN
        
        PRINT 'El registro con el código ' + CAST(@nCodigo_Ca AS VARCHAR) + ' no existe en la tabla Categorias.';
    END
END;
