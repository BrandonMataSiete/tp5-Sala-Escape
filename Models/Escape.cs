namespace TP_sala_escape_Roballo_De_La_Fuente.Models;

public class Escape
{
    private static string[] incognitasSalas = new string[0];
    private static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas = new string[] { "respuesta1", "respuesta2", "respuesta3", "respuesta4", "respuesta5" };
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

        if (incognitasSalas[sala - 1] == incognita)
        {
            estadoJuego++;
            return true;
        }

        return false;
    }
}
