# prueba-tecnica-backend
El sistema se realizó usando una arquitectura hexagonal. 
Se crearon repositorios para abstraer la base de datos y el ORM, en este caso se uso Entity Framework, bajo este diseño es trivial cambiar el ORM a Dapper o cambiar queries para usar vistas o procedimientos sin afectar capas superiores.
La lógica se encapsulo en los servicios. Los controladores exponen una API REST.

<img width="567" height="613" alt="arquitectura backend" src="https://github.com/user-attachments/assets/8739a9cb-8e9c-47d2-bdec-09cd24993b74" />

## Modelo De La Base De Datos
Se crearon 3 tablas. Rutas, operadores y viajes. En la siguiente imagen se puede ver las columnas que tiene cada tabla.
<img width="1270" height="530" alt="columnas base de datos" src="https://github.com/user-attachments/assets/458ea734-734d-4873-a733-7453686659c3" />
