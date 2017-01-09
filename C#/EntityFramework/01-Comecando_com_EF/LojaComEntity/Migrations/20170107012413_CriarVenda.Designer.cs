using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using LojaComEntity.Entidades;

namespace LojaComEntity.Migrations
{
    [DbContext(typeof(EntidadesContext))]
    [Migration("20170107012413_CriarVenda")]
    partial class CriarVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaComEntity.Entidades.Categoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaID");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.ProdutoVenda", b =>
                {
                    b.Property<int>("VendaID");

                    b.Property<int>("ProdutoID");

                    b.HasKey("VendaID", "ProdutoID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.Venda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.Produto", b =>
                {
                    b.HasOne("LojaComEntity.Entidades.Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.ProdutoVenda", b =>
                {
                    b.HasOne("LojaComEntity.Entidades.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");

                    b.HasOne("LojaComEntity.Entidades.Venda")
                        .WithMany()
                        .HasForeignKey("VendaID");
                });

            modelBuilder.Entity("LojaComEntity.Entidades.Venda", b =>
                {
                    b.HasOne("LojaComEntity.Entidades.Usuario")
                        .WithMany()
                        .HasForeignKey("ClienteID");
                });
        }
    }
}
