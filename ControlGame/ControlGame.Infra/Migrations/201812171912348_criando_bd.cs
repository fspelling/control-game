namespace ControlGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criando_bd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogador",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome_PrimeiroNome = c.String(maxLength: 100, unicode: false),
                        Nome_UltimoNome = c.String(maxLength: 100, unicode: false),
                        Email_Endereco = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Plataforma");
            DropTable("dbo.Jogador");
        }
    }
}
