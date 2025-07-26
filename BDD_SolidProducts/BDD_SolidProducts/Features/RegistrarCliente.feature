Feature: Registro de Cliente
  Como administrador del sistema
  Quiero registrar clientes
  Para que puedan emitirse facturas asociadas

  Scenario: Registrar cliente con datos validos
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos del cliente:
      | Code  | Name       | ClientGroupId |
      | C001  | Juan Perez | 1             |
    And confirma el registro del cliente
    Then se muestra el mensaje del cliente "Cliente registrado exitosamente"

  Scenario: Intentar registrar cliente con campos vacios
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos del cliente:
      | Code | Name | ClientGroupId |
      |      |      | 1             |
    And confirma el registro del cliente
    Then se muestra el mensaje del cliente "Faltan datos obligatorios"