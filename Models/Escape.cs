namespace TP_sala_escape_Roballo_De_La_Fuente.Models
{
    public static class Escape
    {
        private static string[] incognitasSalas = new string[0];
        private static int estadoJuego = 1;

        public static void InicializarJuego()
        {
            incognitasSalas = new string[]
            {
                "100", "Harina", "El tano", "Mila napo"
            };
            estadoJuego = 1;
        }

        public static int GetEstadoJuego()
        {
            return estadoJuego;
        }

        public static int GetTotalSalas()
        {
            return incognitasSalas.Length;
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
