using LojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario user = new Usuario()
            {
                Nome = "Rodrigo",
                Senha = "123"
            };

            EntidadesContext contexto = new EntidadesContext();
            contexto.Usuarios.Add(user);
            contexto.SaveChanges();
            contexto.Dispose();
        }
    }
}