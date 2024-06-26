public class Pajarito
{
    private String directorioActual, rutaRelativa;

    public Pajarito()
    {
        // Obtener la ruta del directorio actual
        directorioActual = Directory.GetCurrentDirectory();

        // Construir la ruta relativa del archivo
        rutaRelativa = Path.Combine(directorioActual, "Texto.txt");
    }

    public void Menu()
    {
        String frase;
        int delay;
        byte entrada = 0;

        do
        {
            System.Console.WriteLine("\nPrograma de escritura con delay, eliga la opción que desee para continuar: \n");
            System.Console.WriteLine("  1. Escribir frase con delay. \n");
            System.Console.WriteLine("  2. Escribir frase con delay al revés. \n");
            System.Console.WriteLine("  0. Salir \n");
            entrada = (byte)Comprobar.ComprobarNum(1);

            switch (entrada)
            {
                case 0:
                    Console.Clear();
                    System.Console.WriteLine("Saliendo del menú de escritura con delay...");
                    break;
                case 1: 
                    frase = Comprobar.ComprobarCadena(0);
                    delay = Comprobar.ComprobarNum(0);
                    EscribirDelay(frase, delay);
                    break;
                case 2:
                    frase = Comprobar.ComprobarCadena(0);
                    delay = Comprobar.ComprobarNum(0);
                    EscribirDelayReves(frase, delay);
                    break;
                default: 
                    System.Console.WriteLine("No has introducido un valor válido.");
                    break;
            }
        }while(entrada != 0);
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
            for (int i = 0; fraseActual.Length < frase.Length; i++)
            {
                if (frase[pos] == letra)
                {
                    fraseActual += letra;
                    pos++;
                    i = 0;
                    letra = ' ';
                }

                if (frase.Equals(fraseActual))
                {
                    System.Console.WriteLine(fraseActual);
                    break;
                }

                else Console.WriteLine(fraseActual + letra);

                letra++;
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
            for (int i = 0; fraseActual != inversa ; i++)
            {
                // Comprobación de que la letra sea la misma que la de la cadena origina invertida en la posición de [pos]
                if (letra.Equals(inversa[pos])) 
                {   
                    fraseActual += letra;
                    pos++;
                    i = 0;
                    letra = ' ';
                }

                streamWriter.WriteLine(fraseActual);
                letra++;

                // Verificar si la fraseActual coincide con la frase invertida
                if (fraseActual.Equals(inversa))
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
            File.Delete(rutaRelativa);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al vaciar el archivo: " + e.Message);
        }
        finally
        {
            if (File.Exists(rutaRelativa))
            {
                using FileStream fileStream = File.OpenRead(rutaRelativa);
                fileStream.Close();
            }
        }
    }
}