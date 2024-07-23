Documentación de proyecto .NET Core para la entidad Producto. 
Creada la base de datos para la entidad Producto utilizando el siguiente Query:
![image](https://github.com/user-attachments/assets/7f64d1e6-d4a4-4234-8e72-f7cffd6f0e74)
En VisualStudio Code se hace una solución para en ella hacer la estructura de el proyecto:

![image](https://github.com/user-attachments/assets/40cd8265-f011-4335-afa0-e0e1ce09bcb5)

Se crea la clase Product la cual tendra las propiedades indicadas: 

![image](https://github.com/user-attachments/assets/e42baf8e-e21f-4031-a5ea-9318c3695647)

Se crea el ApplicationContext el cual hereda de DbContext dado por Microsoft.EntityFrameworkCore. ApplicationContext se encarga de inicializar el contexto de la base de datos.
Mientras DbSet se encarga de tener una colección de entidades tipro Product:

![image](https://github.com/user-attachments/assets/6b169f70-9e26-4207-b2db-1bf59472379d)

Se crea una interfaz IProductoRepository la cuál declara métodos de operaciones CRUD 

![image](https://github.com/user-attachments/assets/282ca5c4-7eae-4503-b87b-ee092935d077)

Se crea el repositorio ProductEfRepository el cual implementa la interfaz IProductoRepository utilizando el Entity Framework Cora para así
interacturar con la base de datos. Recibe la clase ApplicationContext como parámetro para poder acceder a la base de datos y realizar operaciones CRUD. 

![image](https://github.com/user-attachments/assets/c843f2ad-c4ae-4b3a-90ea-c1d7837dfb5a)

![image](https://github.com/user-attachments/assets/5e48d2ce-5740-470a-94e4-400fb3ba6b68)

Se crea la clase ProductoController implementando ControllerBase la cual maneja solicitudes HTTP relacionadas con los productos. Recibe instancia IProductoRepository para 
así el controlador pueda acceder a los datos de Product. Se utilizan las solicitudes de HTTP basada en CRUD cada método llamando metodos de IProductoRepository para hacer las tareas:

![image](https://github.com/user-attachments/assets/2d3a72cc-d60d-4cee-97e5-f4ad99a16570)

![image](https://github.com/user-attachments/assets/06ca0694-8d1e-466f-b037-dda67c2f995c)

![image](https://github.com/user-attachments/assets/2b693833-b128-4400-a99b-82ca744638e0)

![image](https://github.com/user-attachments/assets/a69a653d-a4e9-49f8-990b-8fa86df6b74a)

En el startup program Program.cs se añade 
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
La cual utiliza el ApplicationContext para poder utilizar SQL Server con el url dado en DefaultConnection. 
builder.Services.AddTransient<IProductoRepository, ProductEfRepository>();
Permite utilizar IProductRepository dentro de la aplicación. 

![image](https://github.com/user-attachments/assets/8648dfc9-2674-452e-b3a0-998c428005ed)
