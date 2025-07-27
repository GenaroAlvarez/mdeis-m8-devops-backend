Feature: Registro de Factura de Venta
  Como administrador del sistema
  Quiero registrar facturas de venta
  Para documentar las transacciones con clientes

  Scenario: Registrar factura con un producto
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Total | ClientId | PaymentConditionId |
      | 190   | 1        | 1                  |
    And agrega los siguientes detalles de factura:
      | ProductId | Price | Quantity | Subtotal |
      | 10        | 100   | 2        | 190      |
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "Factura registrada exitosamente"

  Scenario: Intentar registrar una factura sin detalles
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Total | ClientId | PaymentConditionId |
      | 0     | 2        | 1                  |
    And no agrega detalles a la factura
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "La factura no tiene detalles validos"

  Scenario: Intentar registrar factura con subtotal negativo
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Total | ClientId | PaymentConditionId |
      | -10   | 2        | 1                  |
    And agrega los siguientes detalles de factura:
      | ProductId | Price | Quantity | Subtotal |
      | 10        | 50    | 1        | -10      |
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "Subtotal invalido en producto"

  Scenario: Registrar factura con multiples detalles
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Total | ClientId | PaymentConditionId |
      | 390   | 3        | 2                  |
    And agrega los siguientes detalles de factura:
      | ProductId | Price | Quantity | Subtotal |
      | 101       | 50    | 2        | 100      |
      | 102       | 100   | 1        | 100      |
      | 103       | 20    | 5        | 190      |
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "Factura registrada exitosamente"
