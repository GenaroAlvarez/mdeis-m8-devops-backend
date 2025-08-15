Feature: Registro de Factura de Venta
  Como administrador del sistema
  Quiero registrar facturas de venta
  Para documentar las transacciones con clientes

Scenario: Registrar factura con un producto
	Given que la aplicacion esta desplegada correctamente
	When el usuario ingresa los datos de la factura:
		| ClientId | PaymentConditionId |
		| 1        | 1					|
	And agrega los siguientes detalles de factura:
		| ProductId | Quantity |
		| 1         | 2        |
	And confirma el registro de la factura
	Then se muestra el mensaje correcto de registro "Factura de venta ha sido registrado exitosamente"


Scenario: Registrar factura con multiples detalles
	Given que la aplicacion esta desplegada correctamente
	When el usuario ingresa los datos de la factura:
		| ClientId | PaymentConditionId |
		| 1        | 2                  |
	And agrega los siguientes detalles de factura:
		| ProductId | Quantity |
		| 1			| 2        |
		| 2			| 1        |
		| 3			| 5        |
	And confirma el registro de la factura
	Then se muestra el mensaje correcto de registro "Factura de venta ha sido registrado exitosamente"


Scenario: Intentar registrar factura con cantidad negativa
	Given que la aplicacion esta desplegada correctamente
	When el usuario ingresa los datos de la factura:
		| ClientId | PaymentConditionId |
		| 1        | 1                  |
	And agrega los siguientes detalles de factura:
		| ProductId | Quantity |
		| 1         | -1       |
	Then se muestra el mensaje de error de cantidad negativa "Quantity must be >= 1"


Scenario: Intentar registrar una factura sin detalles
	Given que la aplicacion esta desplegada correctamente
	When el usuario ingresa los datos de la factura:
		| ClientId | PaymentConditionId |
		| 1        | 1                  |
	And no agrega detalles a la factura
	And confirma el registro de la factura
	Then se muestra el mensaje de error sin detalle "There are no products selected"
