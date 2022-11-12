namespace testeSelecao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inserir : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        idConta = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        descricao = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.idConta);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contas");
        }
    }
}
