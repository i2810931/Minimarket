USE Minimarket;
GO

CREATE TABLE UnidadMedia (
    idUnidades INT PRIMARY KEY,
    abreviaturaUm VARCHAR(255),
    descripcionUm VARCHAR(255),
    estado BIT
);

CREATE TABLE TB_CATEGORIA (
    codigo_ca INT PRIMARY KEY NOT NULL,
    description_ca VARCHAR(50),
    estado BIT
);

CREATE TABLE TB_MARCAS (
    codigo_ma INT PRIMARY KEY NOT NULL,
    description_ma VARCHAR(50),
    estado BIT
);

CREATE TABLE Productos (
    idCodigo INT PRIMARY KEY,
    descripcion VARCHAR(255),
    stockMin INT,
    stockMax INT,
    idCategoria INT,
    idMarcas INT,
    unidades INT,
    FOREIGN KEY (idCategoria) REFERENCES TB_CATEGORIA(codigo_ca),
    FOREIGN KEY (idMarcas) REFERENCES TB_MARCAS(codigo_ma),
    FOREIGN KEY (unidades) REFERENCES UnidadMedia(idUnidades)
);
