using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategorias2 : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome,ImagemUrl) values('Bebidas','Bebidas.jpg')");
            mb.Sql("Insert into Categorias(Nome,ImagemUrl) values('Comidas','Comidas.jpg')");
            mb.Sql("Insert into Categorias(Nome,ImagemUrl) values('Doces','doces.jpg')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
