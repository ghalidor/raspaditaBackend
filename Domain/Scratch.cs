
namespace Domain
{
    public class Scratch_Matrix
    {
        public Int64 id { get; set; }
        public Int64 codigo { get; set; }
        public Int64 simbolos { get; set; }
        public int simPrem { get; set; }
        public int montoPremiado { get; set; }
    }

    public class Scratch_Tp
    {
        public Int64 tp_value { get; set; }

    }
    public class Scratch_new
    {
        public Int64[] TP { get; set; }
        public Int64 simbolos { get; set; }
        public int simPrem { get; set; }
        public int montoPremiado { get; set; }

    }

    public class Scratch_objectonew
    {
        public string ip { get; set; }
        public int indice { get; set; }
    }

    public class Scratch_objecto
    {
        public string ip { get; set; }
        public string ticket { get; set; }
    }

    public class Scratch_monto
    {
        public Int64 monto { get; set; }

    }

    public class Scratch_jugadaobjeto
    {
        public string ip { get; set; }
        public string ticket { get; set; }
        public Boolean premio { get; set; }
        public int creditos_ganados { get; set; }
        public int apuesta { get; set; }
    }

    public class Scratch_jugada
    {
        public Int64 saldo { get; set; }
        public string ip { get; set; }
    }

    public class Scratch_response
    {
        public bool response { get; set; }
    }

    public class Scratch_codigo
    {
        public string codigo { get; set; }
    }
}
