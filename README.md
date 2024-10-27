# API de Gestión de Productos

Esta es una API RESTful para la gestión de productos, que permite realizar operaciones básicas como crear, leer, actualizar y eliminar productos. La API utiliza el patrón de mediación mediante MediatR para mantener el código limpio y desacoplado.

## Rutas de la API

### 1. Obtener Producto por ID

- **URL:** `/products/{id}`
- **Método:** `GET`
- **Descripción:** Recupera los detalles de un producto específico utilizando su ID.
- **Parámetros:**
  - `id` (GUID): El identificador único del producto.
- **Respuesta Exitosa:**
  - **Código:** `200 OK`
  - **Cuerpo:** Detalles del producto en formato JSON.

- **Respuesta no encontrada:**
  - **Código:** `404 Not Found`

**Ejemplo de Solicitud:**
```http
GET /products/123e4567-e89b-12d3-a456-426614174000
```

### 2. Listar Productos

- **URL:** `/products`
- **Método:** `GET`
- **Descripción:** Devuelve una lista de todos los productos disponibles en el sistema.
- **Respuesta Exitosa:**
  - **Código:** `200 OK`
  - **Cuerpo:** Lista de productos en formato JSON.

**Ejemplo de Solicitud:**
```http
GET /products
```

### 3. Crear Producto

- **URL:** `/products`
- **Método:** `POST`
- **Descripción:** Agrega un nuevo producto al sistema.
- **Cuerpo de la Solicitud:** Detalles del producto en formato JSON.
- **Respuesta Exitosa:**
  - **Código:** `201 Created`
  - **Cuerpo:** `{ "id": "nuevo-id" }`

- **Respuesta de Error:**
  - **Código:** `400 Bad Request`

**Ejemplo de Solicitud:**
```http
POST /products
Content-Type: application/json

{
  "name": "Nuevo Producto",
  "description": "Descripción del producto",
  "price": 19.99
}
```

### 4. Actualizar Producto

- **URL:** `/products`
- **Método:** `PUT`
- **Descripción:** Actualiza los detalles de un producto existente.
- **Cuerpo de la Solicitud:** Detalles del producto en formato JSON.
- **Respuesta Exitosa:**
  - **Código:** `200 OK`
  - **Cuerpo:** `{ "id": "id-del-producto-actualizado" }`

- **Respuesta no encontrada:**
  - **Código:** `404 Not Found`

**Ejemplo de Solicitud:**
```http
PUT /products
Content-Type: application/json

{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Producto Actualizado",
  "description": "Nueva descripción",
  "price": 29.99
}
```

### 5. Eliminar Producto

- **URL:** `/products/{id}`
- **Método:** `DELETE`
- **Descripción:** Elimina un producto existente utilizando su ID.
- **Respuesta Exitosa:**
  - **Código:** `204 No Content`

**Ejemplo de Solicitud:**
```http
DELETE /products/123e4567-e89b-12d3-a456-426614174000
```

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir, por favor abre un *issue* o envía un *pull request*.

## Licencia

Este proyecto está bajo la Licencia MIT. Para más detalles, consulta el archivo [LICENSE](LICENSE).
