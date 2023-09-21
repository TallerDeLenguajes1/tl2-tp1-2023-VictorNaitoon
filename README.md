# tl2-tp1-2023-VictorNaitoon
## ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
+ La relación entre las clases de Pedido y Cliente es una **Composición**.
+ La relación entre las clases de Pedido y Cadete es una **Agregación**.
+ La relación entre las clases de Cadete y Cadeteria es una **Composición**.

## ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?.
Para este sistema yo considero los siguientes métodos por clases.
**Clase Cadeteria:**
+ AgregarCadete(Cadete cadete): Permite agregar un nuevo cadete a la cadetería.
+ EliminarCadete(int idCadete): Elimina un cadete de la cadetería según el id que le pasamos.
+ ObtenerInformacion(): Genera informe sobre la actividad de la cadetería.
**Clase Cadete:**
Además del método JornalACobrar(), propongo los siguientes métodos:
+ AsignarPedido(Pedido pedido): Asignamos un pedido a un cadete, donde se debería verificar si el pedido ya está asignado a otro cadete.
+ DesignarPedido(Pedido pedido): Designa un pedido de un cliente, esto pasa cuando se cancela un pedido o se reasigna a otro cadete.
+ PedidosEntregados(): Nos da una lista de los pedidos entregados.
+ ObtenerInformacion(): Genera informe de los cadetes mostrando su actividad, cantidad de pedidos que entrego, etc.
## Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.

## ¿Cómo diseñaría los constructores de cada una de las clases?

## ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?



