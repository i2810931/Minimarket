/*
CREADO POR CSAR LAZO VEGA
2023-10-08
Inserta nuevos registra o actualiza registros existentes,
en la tabla categorias.
*/
CREATE PROCEDURE USP_Guardar_Ca
    @nOpcion INT = 0,
    @nCodigo_Ca INT = 0,
    @Descripcion_Ca VARCHAR(40) = ''
AS
BEGIN
    IF @nOpcion = 1 -- Nuevo registro
    BEGIN
        INSERT INTO Categorias (descripcion_ca, estado)
        VALUES (@Descripcion_Ca, 1);
    END
    ELSE -- Actualiza
    BEGIN
        UPDATE Categorias
        SET descripcion_ca = @Descripcion_Ca
        WHERE cod_categ = @nCodigo_Ca;
    END
END;
