namespace claseMVCts.Migrations
{
    using claseMVCts.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<claseMVCts.Models.LibroDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false; 
        }

        protected override void Seed(claseMVCts.Models.LibroDBContext context)
        {            
            context.libros.AddOrUpdate(i => i.Titulo,
                                        new libro
                                        {
                                            Titulo = "jurassik park",
                                            Fecha = DateTime.Parse("1989-1-11"),
                                            Autor = "jc1",
                                            precio = 7.99M,
                                            Genero = "SciFi",
                                            ruta = "/Content/imagenes/JP1.jpg"
                                        },

                                        new libro
                                        {
                                            Titulo = "Ghostbusters ",
                                            Fecha = DateTime.Parse("1984-3-13"),
                                            Autor = "Comedy",                                            
                                            precio = 8.99M,
                                            Genero = "Fantasía",
                                            ruta = "/Content/imagenes/GB1.jpg"
                                        },

                                         new libro
                                        {
                                            Titulo = "jurassik park3",
                                            Fecha = DateTime.Parse("1989-1-11"),
                                            Autor = "jc1",
                                            precio = 9.99M,
                                            Genero = "Fantasía",
                                            ruta = "/Content/imagenes/JP2.jpg"

                                        },
                                         new libro
                                        {
                                            Titulo = "jurassik park4",
                                            Fecha = DateTime.Parse("1989-1-11"),
                                            Autor = "jc1",
                                            precio = 10.99M,
                                            Genero = "Fantasía",
                                            ruta = "/Content/imagenes/JP1.jpg"
                                        }
                                        
                 );
            Random rnd = new Random(); 
            for (int i = 0; i < 100; i++)
            {
                context.libros.AddOrUpdate(r => r.Titulo,
                    new libro
                    {
                        Titulo = "Harry Potter " + i.ToString(),
                        Fecha = DateTime.Parse("1989-1-11"),
                        Autor = "J.K R",
                        precio = 7.99M,
                        Genero = "Fantasía",
                        ruta = "/Content/imagenes/HP" + 
                            rnd.Next(1, 5).ToString() + ".jpg"
                    });
            }
            
        }
    }
}
