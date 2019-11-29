using Bogus;

namespace ConsoleApp2
{
    public static class Faker
    {
        public static void PopularBase()
        {

            var ctx = new Context();


            string locale = "pt_BR";

            var tipoParteFaker = new Faker<TipoParte>(locale)
                   .CustomInstantiator(f => new TipoParte())
                   .RuleFor(o => o.CodigoTipoParte, f => f.IndexFaker + 1)
                   .RuleFor(o => o.Descricao, f => f.Lorem.Sentences(1));
            var tipos = tipoParteFaker.Generate(20);


            var classeTipoParteFaker = new Faker<ClasseTipoParte>(locale)
              .CustomInstantiator(f => new ClasseTipoParte())
              .RuleFor(o => o.CodigoClasse, f => f.IndexFaker + 1)
              .RuleFor(o => o.CodigoTipoParte, f => f.IndexFaker + 1)
              .RuleFor(o => o.Tipo, f => f.IndexFaker);
            var classes = classeTipoParteFaker.Generate(5);


            ctx.TipoParte.AddRange(tipos);
            ctx.ClasseTipoParte.AddRange(classes);
            ctx.SaveChanges();

        }
    }
}
