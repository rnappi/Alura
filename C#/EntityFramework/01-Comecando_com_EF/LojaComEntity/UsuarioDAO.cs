using LojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    class UsuarioDAO : BaseContext<Usuario>
    {
        public override Usuario BuscarPorId(int Id)
        {
            return Context.Usuarios.FirstOrDefault(u => u.ID == Id);
        }

        public override void Remove(Usuario usuario)
        {
            Context.Usuarios.Remove(usuario);
            this.SaveChanges();
        }

        public override void Salva(Usuario usuario)
        {
            Context.Usuarios.Add(usuario);
            this.SaveChanges();
        }
    }
}