namespace TP_sala_escape_Roballo_De_La_Fuente.Models
{
    public static class Escape
    {
        private static string[] incognitasSalas = new string[0];
        private static int estadoJuego = 1;

        private static void InicializarJuego()
        {
            incognitasSalas = new string[]
            {
                "Comer", "Sucio", "Celular", "Where"
            };
            estadoJuego = 1;
        }

        public static int GetEstadoJuego()
        {
            return estadoJuego;
        }

        public static bool ResolverSala(int sala, string incognita)
        {
            if (incognitasSalas.Length == 0)
            {
                InicializarJuego();
            }

            if (sala != estadoJuego)
            {
                return false;
            }

            if (incognitasSalas[sala - 1].ToLower() == incognita.ToLower())
            {
                estadoJuego++;
                return true;
            }

            return false;
        }
    }
}
