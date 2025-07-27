Feature: Registro de Cliente
  Como administrador del sistema
  Quiero registrar clientes
  Para que puedan emitirse facturas asociadas

  Scenario: Registrar cliente con datos validos
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos del cliente:
		| Code | Name       | Email          | DocumentNumber | DocumentTypeId |
		| C001 | Juan Perez | juan@gmail.com | 1234567890     | 1              |
    And confirma el registro del cliente
    Then se muestra el mensaje del cliente "Cliente registrado exitosamente"

  Scenario: Intentar registrar cliente con campos vacios
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos del cliente:
        | Code | Name       | Email          | DocumentNumber | DocumentTypeId |
	    |      | Juan Perez | juan@gmail.com | 1234567890     |                |
    And confirma el registro del cliente
    Then se muestra el mensaje del cliente "Faltan datos obligatorios"