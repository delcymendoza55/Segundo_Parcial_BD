using Infraestructura.Conexiones;
using Primer_Parcial_Cuentas.Cuentas_Parcial1;
using Servicios.ContactService;
using System.Reflection.PortableExecutable;


//****************************** PROBAR CONEXION DE BD *************************************************

//ConexionDB objBaseDatos = new ConexionDB("Server=localhost;Port=5432;Database=Cuentas_Primer_Parcial;Username=postgres;Password=1234;");
//if (objBaseDatos.probarConexion())
//Console.WriteLine("Se conectó a la base de datos");
//Console.WriteLine("...");

//---------------------------------- CIUDAD SERVICE ----------------------------------------------------
Console.WriteLine("TABLA CIUDADES");

CiudadesService ciudadesService = new CiudadesService("Server=localhost;Port=5432;Database=Cuentas_Primer_Parcial;Username=postgres;Password=1234");

////PARA INSERTAR
//ciudadesService.insertarCiudad(new Infraestructura.Modelos.CiudadesModel
//{
//    Ciudad = "Luque",
//    Departamento = "Central",
//    Cod_Postal = 1516,
//});

//PARA OBTENER
var ciudades = ciudadesService.obtenerCiudad(2);
Console.WriteLine($"Ciudad: {ciudades.Ciudad},Departamento: {ciudades.Departamento},Cod_Postal: {ciudades.Cod_Postal}");

//PARA MODIFICAR
ciudades.Ciudad = "Mariano Roque Alonso";
ciudades.Departamento = "Central";
ciudades.Cod_Postal = 1122;
ciudadesService.modificarCiudad(ciudades);

Console.WriteLine("-----------------------------------");


//---------------------------------- PERSONA SERVICE ----------------------------------------------------------------
Console.WriteLine("TABLA PERSONAS");

PersonasService personasService = new PersonasService("Server=localhost;Port=5432;Database=Cuentas_Primer_Parcial;Username=postgres;Password=1234");

////PARA INSERTAR
//personasService.insertarPersona(new Infraestructura.Modelos.PersonasModel
//{
//    Id_Ciudad = 1,
//     Nombre = "Ana",
//     Apellido = "Gomez",
//     Tipo_Docu = "Cédula",
//     Nro_Docu = "1523261",
//     Direccion = "Av.Artigas 152",
//     Celular = "(0981)522-253",
//     Email = "anagomez@gmail.com",
//     Estado = "Activo",
//});

//PARA OBTENER
var personas = personasService.obtenerPersona(3);
Console.WriteLine($"Id_Ciudad: {personas.Id_Ciudad},Nombre: {personas.Nombre}, Apellido: {personas.Apellido},Tipo_Docu: {personas.Tipo_Docu},Nro_Docu:{personas.Nro_Docu}," +
    $"Direccion:{personas.Direccion}, Celular:{personas.Celular},Email:{personas.Email},Estado:{personas.Estado}");

//PARA MODIFICAR
personas.Id_Ciudad = 3;
personas.Nombre = "Paula";
personas.Apellido = "Abad";
personas.Tipo_Docu = "Cédula";
personas.Nro_Docu = "4782147";
personas.Direccion = "Av. Gral.Diaz 584";
personas.Celular = "(0984)147-159";
personas.Email = "vargaskaren@hotmail.com";
personas.Estado = "Activo";
personasService.modificarPersona(personas);

Console.WriteLine("-----------------------------------");


//---------------------------------- CLIENTES SERVICE ----------------------------------------------------------------
Console.WriteLine("TABLA CLIENTES");

ClientesService clientesService = new ClientesService("Server=localhost;Port=5432;Database=Cuentas_Primer_Parcial;Username=postgres;Password=1234");

////PARA INSERTAR
//clientesService.insertarCliente(new Infraestructura.Modelos.ClientesModel
//{
//    Id_Persona = 4,
//    Fecha_Ingreso = DateTime.Parse("2022-05-23"),
//    Calificacion = "Óptimo",
//    Estado = "Activo",

//}) ; 

//PARA OBTENER
var clientes = clientesService.obtenerCliente(2);
Console.WriteLine($"Id_Persona: {clientes.Id_Persona},Fecha_Ingreso: {clientes.Fecha_Ingreso}, Calificacion: {clientes.Calificacion},Estado: {clientes.Estado}");

//PARA MODIFICAR
clientes.Id_Persona = 2;
clientes.Fecha_Ingreso = DateTime.Parse("2022-05-23");
clientes.Calificacion = "Irregular";
clientes.Estado = "Activo";

clientesService.modificarCliente(clientes);

Console.WriteLine("-----------------------------------");


//---------------------------------- CUENTAS SERVICE ----------------------------------------------------------------
Console.WriteLine("TABLA CUENTAS");
CuentasService cuentasService = new CuentasService("Server=localhost;Port=5432;Database=Cuentas_Primer_Parcial;Username=postgres;Password=1234");

////PARA INSERTAR
//cuentasService.insertarCuenta(new Infraestructura.Modelos.CuentasModel
//{
//        Id_Cliente =3,
//        Nro_Cuenta="4878920478",
//        Fecha_Alta= DateTime.Parse("2023-05-08"),
//        Tipo_Cuenta="Cuenta Corriente",
//        Estado="Activo",
//        Saldo=5597481.2m,
//        nroCuenta="2565852",
//        nroContrato="548812",
//        Costo_Mantenimiento=15251.12m,
//        Promedio_Acreditacion="5845415",
//        Moneda="Guaranies",

//});

//PARA OBTENER
var cuentas = cuentasService.obtenerCuenta(4);
Console.WriteLine($"Id_Cliente: {cuentas.Id_Cliente},Nro_Cuenta: {cuentas.Nro_Cuenta}, " +
    $"Fecha_Alta: {cuentas.Fecha_Alta},Tipo_Cuenta: {cuentas.Tipo_Cuenta},Estado:{cuentas.Estado}," +
    $"Saldo:{cuentas.Saldo}, nroCuenta:{cuentas.nroCuenta},nroContrato:{cuentas.nroContrato}," +
    $"Costo_Mantenimiento:{cuentas.Costo_Mantenimiento},Promedio_Acreditacion:{cuentas.Promedio_Acreditacion}," +
    $"Moneda:{cuentas.Moneda}");

//PARA MODIFICAR

cuentas.Id_Cliente = 3;
cuentas.Nro_Cuenta = "5898920478";
cuentas.Fecha_Alta = DateTime.Parse("2023-05-08");
cuentas.Tipo_Cuenta = "Cuenta Corriente";
cuentas.Estado = "Activo";
cuentas.Saldo = 5548971.12m;
cuentas.nroCuenta = "2565852";
cuentas.nroContrato = "548812";
cuentas.Costo_Mantenimiento = 15251.12m;
cuentas.Promedio_Acreditacion = "5845415";
cuentas.Moneda = "Guaranies";
cuentasService.modificarCuenta(cuentas);

Console.WriteLine("-----------------------------------");



//---------------------------------- MOVIMIENTOS SERVICE ----------------------------------------------------------------
Console.WriteLine("TABLA MOVIMIENTOS");

MovimientosService movimientosService = new MovimientosService("Server=localhost;Port=5432;Database=Cuentas_Primer_Parcial;Username=postgres;Password=1234");

////PARA INSERTAR
//movimientosService.insertarMovimiento(new Infraestructura.Modelos.MovimientosModel
//{
//    Id_Cuenta = 4,
//    Fecha_Movimiento = DateTime.Parse("2023-09-21"),
//    Tipo_Movimiento = "Debito",
//    Saldo_Anterior = 2500000.90m,
//    Saldo_Actual = 1000000.0m,
//    Monto_Movimiento =1500000.00m,
//    Cuenta_Origen = 1500000.0m,
//    Cuenta_Destino =1500000.0m,
//    Canal = 3.00m,

//});

//PARA OBTENER
var movimientos = movimientosService.obtenerMovimiento(1);
Console.WriteLine($"Id_Cuenta: {movimientos.Id_Cuenta},Fecha_Movimiento: {movimientos.Fecha_Movimiento}, " +
    $"Tipo_Movimiento: {movimientos.Tipo_Movimiento},Saldo_Anterior: {movimientos.Saldo_Anterior}," +
    $"Saldo_Actual:{movimientos.Saldo_Actual},Monto_Movimiento:{movimientos.Monto_Movimiento}," +
    $" Cuenta_Origen:{movimientos.Cuenta_Origen}," +
    $"Cuenta_Destino:{movimientos.Cuenta_Destino},Canal:{movimientos.Canal}");

//PARA MODIFICAR
movimientos.Id_Cuenta = 3;
movimientos.Fecha_Movimiento = DateTime.Parse("2023-05-12");
movimientos.Tipo_Movimiento = "Credido";
movimientos.Saldo_Anterior = 1500000.0m;
movimientos.Saldo_Actual = 2000000.0m;
movimientos.Monto_Movimiento = 500000.0m;
movimientos.Cuenta_Origen = 500000.0m;
movimientos.Cuenta_Destino = 500000.0m;
movimientos.Canal = 1.0m;
movimientosService.modificarMovimiento(movimientos);

Console.WriteLine("-----------------------------------");

Console.WriteLine("Ejecutada Correctamente......");
