use products;

INSERT INTO ClientGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Clientes Premium', 'PREM', 15.5, GETUTCDATE(), NULL, NULL);

INSERT INTO ClientGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Clientes Corporativos', 'CORP', 20.0, GETUTCDATE(), NULL, NULL);

INSERT INTO ClientGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Clientes Minoristas', 'MINO', 5.0, GETUTCDATE(), NULL, NULL);

INSERT INTO ClientGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Clientes Mayoristas', 'MAYO', 25.0, GETUTCDATE(), NULL, NULL);

INSERT INTO ClientGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Clientes VIP', 'VIP', 30.0, GETUTCDATE(), NULL, NULL);


INSERT INTO ProductGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Electrónicos', 'ELEC', 10.5, GETUTCDATE(), NULL, NULL);

INSERT INTO ProductGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Línea Blanca', 'LBLA', NULL, GETUTCDATE(), NULL, NULL);

INSERT INTO ProductGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Muebles', 'MUEB', 5.0, GETUTCDATE(), NULL, NULL);

INSERT INTO ProductGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Herramientas', 'HERR', 7.5, GETUTCDATE(), NULL, NULL);

INSERT INTO ProductGroups (Name, Code, Discount, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Tecnología', 'TECH', 12.0, GETUTCDATE(), NULL, NULL);


INSERT INTO PaymentConditions (Name, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Contado', GETUTCDATE(), NULL, NULL);

INSERT INTO PaymentConditions (Name, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Crédito 30 días', GETUTCDATE(), NULL, NULL);

INSERT INTO PaymentConditions (Name, CreatedAt, UpdatedAt, DeletedAt)
VALUES ('Crédito 60 días', GETUTCDATE(), NULL, NULL);

INSERT INTO Warehouses (Name, CreatedAt) VALUES(N'ALMACEN PRINCIPAL', GETUTCDATE());

INSERT INTO Products (Code, Name, Price, ProductGroupId, Brand, CreatedAt) VALUES
(N'P01', N'Sprite', 10.00, (SELECT id FROM ProductGroups WHERE Code = 'ELEC'), N'MARCA', GETUTCDATE()),
(N'P02', N'PRODUCTO 2', 100.00, (SELECT id FROM ProductGroups WHERE Code = 'LBLA'), N'MARCA', GETUTCDATE()),
(N'P03', N'PRODUCTO 3', 100.00, (SELECT id FROM ProductGroups WHERE Code = 'MUEB'), N'MARCA', GETUTCDATE()),
(N'P04', N'PRODUCTO 4', 100.00, (SELECT id FROM ProductGroups WHERE Code = 'HERR'), N'MARCA', GETUTCDATE()),
(N'P05', N'PRODUCTO 5', 100.00, (SELECT id FROM ProductGroups WHERE Code = 'TECH'), N'MARCA', GETUTCDATE());

INSERT INTO DocumentTypes(Code, Name, CreatedAt) VALUES
('CI', 'Carnet de Identidad', GETUTCDATE()),
('NIT', 'Número de Identificación Tributaria', GETUTCDATE());
