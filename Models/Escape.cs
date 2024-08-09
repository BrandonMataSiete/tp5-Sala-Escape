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

        public static string GetPista1(int sala)
        {
            string pista = "";
            if (sala == 1)
            {
                pista = "La comida es algo que está prohibido en el aula.";
            }
            else if (sala == 2)
            {
                pista = "Recuerda que el desorden no es bien visto en ningún lugar.";
            }
            else if (sala == 3)
            {
                pista = "Los dispositivos tecnológicos no son permitidos sin autorización.";
            }
            else if (sala == 4)
            {
                pista = "En SQL, las condiciones deben ser específicas.";
            }
            return $"<button type='button' onclick=\"alert('{pista}')\">Pista 1</button>";
        }

        public static string GetPista2(int sala)
        {
            string pista = "";
            if (sala == 1)
            {
                pista = "Piensa en lo que no deberías hacer mientras estás en clase.";
            }
            else if (sala == 2)
            {
                pista = "Piensa en lo que debes hacer después de utilizar un espacio.";
            }   
            else if (sala == 3)
            {
                pista = "Considera lo que no se puede usar sin permiso en clase.";
            }
            else if (sala == 4)
            {
                pista = "¿Qué necesitas para filtrar datos en SQL?";
            }

            return $"<button type='button' onclick=\"alert('{pista}')\">Pista 2</button>";
        }
        public static int GetTotalSalas()
        {
            return incognitasSalas.Length;
        }
    }
}