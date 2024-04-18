public class Pajarito
{
    private List<char> caracteresESP;
    private String directorioActual;
    private String rutaRelativa;

    public Pajarito()
    {
        caracteresESP = new List<char>();
        CrearListaLetras();

        // Obtener la ruta del directorio actual
        directorioActual = Directory.GetCurrentDirectory();

        // Construir la ruta relativa del archivo
        rutaRelativa = Path.Combine(directorioActual, "Texto.txt");
    }

    private void CrearListaLetras()
    {
        // Crear una lista para almacenar los caracteres ASCII
        for (char var = (char)1; var <= 255; var++)
        {
            caracteresESP.Add(var);
        }
    }

    // Método que muestra por pantalla el proceso de encontrar todos los caracteres de una cadena hasta llegar a tener todos los caracteres iguales
    // a los de la cadena original, y almacena todos los valores que se generan en cada iteración en un archivo.
    public void EscribirDelay(String frase, int delay)
    {
        VaciarArchivo();
        char letra = ' ';
        String fraseActual = "";
        int pos = 0;

        try
        {
            // Abrir el archivo para escribir (crea uno nuevo si no existe)
            using FileStream fileStream = new FileStream(rutaRelativa, FileMode.Append, FileAccess.Write);
            using StreamWriter streamWriter = new StreamWriter(fileStream);
            for (int i = 0; fraseActual.Length != frase.Length; i++)
            {
                if (String.Equals(frase[pos], letra))
                {
                    fraseActual += letra;
                    pos++;
                    i = 0;
                }

                if (frase == fraseActual)
                {
                    System.Console.WriteLine(fraseActual);
                    break;
                }

                else Console.WriteLine(fraseActual + letra);

                letra = caracteresESP[i];
                Thread.Sleep(delay);
                streamWriter.WriteLine(fraseActual + letra);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al escribir en el archivo: " + e.Message);
        }
    }

    // Método para escribir el proceso de recorrer todas las letras de una cadena hasta que todas las letras son iguales a la cadena original al reves
    // Se le pasa por parametros una cadena que se le dará la vuelta dentro del método y un número (ms) que sera el tiempo que esperará el metodo para cada iteración
    // Y almacena la salida de cada iteración en un archivo y muestra por pantalla esa misma salida.
    public void EscribirDelayReves(String frase, int delay)
    {
        VaciarArchivo();
        char letra = ' ';
        String fraseActual = "";
        String inversa = CadenaInversa(frase);
        int pos = 0;

        try
        {
            // Abrir el archivo para escribir (crea uno nuevo si no existe)
            using FileStream fileStream = new FileStream(rutaRelativa, FileMode.Append, FileAccess.Write);
            using StreamWriter streamWriter = new StreamWriter(fileStream);

            // Repetir hasta que la fraseActual sea igual a la frase original
            for (int i = 0; ; i++)
            {
                // Comprobación de que la letra sea la misma que la de la cadena origina invertida en la posición de [pos]
                if (letra == inversa[pos]) 
                {   
                    fraseActual += letra;
                    pos++;
                    i = 0;
                }

                streamWriter.WriteLine(fraseActual);
                letra = caracteresESP[i];

                // Verificar si la fraseActual coincide con la frase invertida
                if (fraseActual == inversa)
                {
                    Console.WriteLine(fraseActual);
                    break; 
                }
                else Console.WriteLine(letra + fraseActual);

                Thread.Sleep(delay);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al escribir en el archivo: " + e.Message);
        }
    }

    // Método para crear una cadena inversa de otra cadena.
    private string CadenaInversa(string cadena)
    {
        System.Text.StringBuilder inversa = new System.Text.StringBuilder();
        for (int i = cadena.Length - 1; i >= 0; i--)
        {
            inversa.Append(cadena[i]);
        }
        return inversa.ToString();
    }

    // Método que vacia el archivo en el que se almacenan las salidas de las cadenas.
    private void VaciarArchivo()
    {
        try
        {
            // Vaciar el contenido del archivo
            File.WriteAllText(rutaRelativa, string.Empty);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al vaciar el archivo: " + e.Message);
        }
    }

    public String ComprobarCadena()
    {
        String cadena = "";
        do
        {
            try
            {
                Console.Write("Escribe una frase a escribir: ");
                cadena = Console.ReadLine()!;

                if (cadena.Length > 0)
                {
                    return cadena;
                }
                else
                {
                    System.Console.WriteLine("Tienes que meter al menos un carácter, inténtalo de nuevo.");
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        } while (true);
    }

    public int ComprobarNum(byte tipo)
    {
        try
        {
            string input;
            int delay;
            do
            {
                if (tipo == 0) Console.Write("Escribe una cantidad para el delay: ");
                if (tipo == 1) Console.Write("Escribe una opción: ");
                input = Console.ReadLine()!;
                
                if (int.TryParse(input, out delay))
                {
                    return delay;
                }
                else
                {
                    Console.WriteLine("Debes ingresar un número válido. Inténtalo de nuevo.");
                }
            } while (true);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrió un error: " + e.Message + ". Asignando el valor 0");
            return 0;
        }
    }
}