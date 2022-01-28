using AdministracionEscuela.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(AdministracionEscuela.Startup))]
namespace AdministracionEscuela
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Iniciamos la clase que se creó abajo para la creación y asignación de roles
            createRolesandUsers();
        }

        public void createRolesandUsers()
        {
            var context = new ApplicationDbContext();

            //A continuación se construyen los roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Para crear el usuario administrador, descomentar las siguientes líneas y correrla una sola vez.

            /*var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@ale.com",
                FechaNacimiento = DateTime.Now,
            };

            var password = "password";

            var usuario = userManager.Create(user, password);

            if (usuario.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, "Admin");
            }*/

            //Se valida la asignación de roles de los usuarios, si no existe las crea
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@ale.com",
                    FechaNacimiento = DateTime.Now,
                };

                var password = "password";

                var usuario = userManager.Create(user, password);

                if (usuario.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }
                        
            if(!roleManager.RoleExists("Profesor"))
            {
                var role = new IdentityRole();
                role.Name = "Profesor";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Directivo"))
            {
                var role = new IdentityRole();
                role.Name = "Directivo";
                roleManager.Create(role);
            }

        }
    }
}
