using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into produtos (nome,descricao,preco,imagemurl,estoque,datacadastro,categoriaid)" +
                "values('Coca-Cola Diet','refrigerante diet 350ml',5.50,'cocacola.jpg',50,now(),1)");

            mb.Sql("insert into produtos (nome,descricao,preco,imagemurl,estoque,datacadastro,categoriaid)" +
                "values('X burguer','x burguer',15.00,'xburguer.jpg',50,now(),2)");

            mb.Sql("insert into produtos (nome,descricao,preco,imagemurl,estoque,datacadastro,categoriaid)" +
                "values('brigadeiro','chocolate',3.00,'brigadeiro.jpg',50,now(),3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Produtos");
        }
    }
}
