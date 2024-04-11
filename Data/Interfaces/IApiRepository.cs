using System.Collections.Generic;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data.Interfaces
{
    public interface IApiRepository
    {
         // En la carpeta Data, un nivel arriba, implementamos la clase concreta ApiRepository para consumir esta interface
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> GetUsuarioByNombreAsync(String nombre);
        Task<IEnumerable<Producto>> GetProductosAsync();
        Task<Producto> GetProductoByIdAsync(int Id);
        Task<Producto> GetProductoByNombreAsync(string nombre);

    }
}