using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApiCRUD.Data.Interfaces;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    //En la clase Startup, debemos agregar nuestro repositorio: services.AddScoped<IApiRepository, ApiRepository>();
    public class ApiRepository : IApiRepository //Implementar de la interface creada para estos fines
    {
        private readonly DataContext _context;
        public ApiRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Producto> GetProductoByIdAsync(int Id)
        {
           var producto = await _context.Productos.FirstOrDefaultAsync(u => u.Id == Id);
           return producto;
        }

        public async Task<Producto> GetProductoByNombreAsync(string nombre)
        {
            var productos = await _context.Productos.FirstOrDefaultAsync(u => u.Nombre == nombre);
            return productos;
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            var productos = await _context.Productos.ToListAsync();
            return productos;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            return usuario;
        }

        public async Task<Usuario> GetUsuarioByNombreAsync(string nombre)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nombre );
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}