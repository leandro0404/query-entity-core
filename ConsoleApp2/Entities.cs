namespace ConsoleApp2
{

    public class FiltroClasseTipoParte
    {
        public int CodigoClasse { get; set; }
        public int CodigoTipoParte { get; set; }
        public bool ExisteVinculo { get; set; }
    }

    public class TipoParte
    {
        public int CodigoTipoParte { get; set; }
        public string Descricao { get; set; }

    }

    public class ClasseTipoParte
    {
        public int CodigoClasse { get; set; }
        public int CodigoTipoParte { get; set; }
        public int Tipo { get; set; }
        public TipoParte TipoParte { get; set; }
        public bool ExisteVinculo { get; set; }
    }
}
