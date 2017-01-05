using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LojaComEntity.Entidades
{
    public class EntidadesContext : DbContext
    {
        // informando ao EF quais classes devem ser mapedas no banco de dados
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categrias { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }

        // informando ao EF o banco que será utilizado e a string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["LojaComEntityConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(stringConexao);
            base.OnConfiguring(optionsBuilder);
        }

        // informa ao EF que queremos criar uma chave primária composta para a entidade ProdutoVenda
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // para mapear a entidade com chave composta, precisamos instanciar um objeto anonimo
            modelBuilder.Entity<ProdutoVenda>().HasKey(pv => new { pv.VendaID, pv.ProdutoID});
            base.OnModelCreating(modelBuilder);
        }
    }
}