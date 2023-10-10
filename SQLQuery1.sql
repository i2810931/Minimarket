/*
CREADO POR CSAR LAZO VEGA
2023-10-08
Busca y recupera registros,
en la tabla categorias.
*/
CREATE PROCEDURE USP_Listado_ca
    @cTexto VARCHAR(100) = ''
AS
BEGIN
    SELECT cod_categ, descripcion_ca
    FROM Categorias
    WHERE estado = 1
        AND UPPER(RTRIM(LTRIM(CONVERT(CHAR(10), cod_categ))) + RTRIM(LTRIM(descripcion_ca))) LIKE '%' + UPPER(LTRIM(RTRIM(@cTexto))) + '%';
    -- RTRIM elimina espacios a la derecha
    -- LTRIM elimina espacios a la izquierda
    -- CONVERT convierte a tipo CHAR
    -- UPPER convierte a mayúsculas
END;
