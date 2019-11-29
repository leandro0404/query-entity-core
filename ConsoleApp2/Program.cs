using System;
using System.Linq;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker.PopularBase();
            var ctx = new Context();

            var t1 = ctx.TipoParte.ToList();
            var t2 = ctx.ClasseTipoParte.ToList();

            var filter = PredicateBuilder.True<ClasseTipoParte>();
            filter = filter.And(x => x.ExisteVinculo == true);
            //filter = filter.And(x => x.CodigoClasse == 1);
            var exp = filter.Compile();

            var pageSettings = new PaginationSettings();
            pageSettings.SortSettings.OrderBy = "CodigoClasse";

            var result = (from classes in ctx.ClasseTipoParte
                          join tipoparte in ctx.TipoParte
                           on 1 equals 1 into Details
                          from m in Details.DefaultIfEmpty()
                          let tp = m
                          select  new ClasseTipoParte
                          {
                              CodigoClasse = classes.CodigoClasse,
                              CodigoTipoParte = m.CodigoTipoParte,
                              Tipo = classes.Tipo,
                              TipoParte = classes.CodigoTipoParte == m.CodigoTipoParte ? tp : null,
                              ExisteVinculo = classes.CodigoTipoParte == m.CodigoTipoParte ? true : false,
                          }).Where(exp).AsQueryable().Page(pageSettings).ToList();

            Console.WriteLine("Hello World!");

        }
    }
}
