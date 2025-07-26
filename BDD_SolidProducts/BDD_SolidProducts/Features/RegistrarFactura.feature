Feature: Registro de Factura de Venta
  Como administrador del sistema
  Quiero registrar facturas de venta
  Para documentar las transacciones con clientes

  Scenario: Registrar factura con un producto
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Nit      | BusinessName | ClientId | PaymentConditionId |
      | 12345678 | Empresa ABC  | 1        | 1                  |
    And agrega los siguientes productos a la factura:
      | ProductId | Price | Quantity | Discount | WarehouseId |
      | 10        | 100   | 2        | 10       | 1           |
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "Factura registrada exitosamente"

  Scenario: Intentar registrar una factura sin productos
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Nit      | BusinessName | ClientId | PaymentConditionId |
      | 87654321 | Empresa XYZ  | 2        | 1                  |
    And no agrega productos a la factura
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "La factura no tiene detalles validos"

  Scenario: Intentar registrar factura con subtotal negativo
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
      | Nit      | BusinessName | ClientId | PaymentConditionId |
      | 12345678 | Empresa XYZ  | 2        | 1                  |
    And agrega los siguientes productos a la factura:
      | ProductId | Price | Quantity | Discount | WarehouseId |
      | 10        | 50    | 1        | 60       | 1           |
    And confirma el registro de la factura
    Then se muestra el mensaje de la factura "Subtotal invalido en producto"
  
  Scenario: Registrar factura con multiples productos
    Given que la aplicacion esta desplegada correctamente
    When el usuario ingresa los datos de la factura:
        | Nit      | BusinessName | ClientId | PaymentConditionId |
        | 12345678 | Multiventas  | 3        | 2                  |
      And agrega los siguientes productos a la factura:
        | ProductId | Price | Quantity | Discount | WarehouseId |
        | 101       | 50    | 2        | 5        | 1           |
        | 102       | 100   | 1        | 0        | 1           |
        | 103       | 20    | 5        | 10       | 1           |
      And confirma el registro de la factura
      Then se muestra el mensaje de la factura "Factura registrada exitosamente"