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