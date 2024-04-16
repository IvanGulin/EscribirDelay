using System.Globalization;

public class Pajarito
{
    private List<char> caracteresEspañoles;
    private String directorioActual;
    private String rutaRelativa;

    public Pajarito()
    {
        caracteresEspañoles = new List<char>();
        CrearListaLetras();

        // Obtener la ruta del directorio actual
        directorioActual = Directory.GetCurrentDirectory();

        // Construir la ruta relativa del archivo
        rutaRelativa = Path.Combine(directorioActual, "Texto.txt");
    }

    private void CrearListaLetras()
    {
        // Crear una lista para almacenar los caracteres alfanuméricos españoles en UTF-8
        caracteresEspañoles.Add('ñ');
        caracteresEspañoles.Add('Ñ');
        caracteresEspañoles.Add(' ');

        // Agregar letras del alfabeto latino básico (mayúsculas y minúsculas)
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            caracteresEspañoles.Add(letra);
            caracteresEspañoles.Add(char.ToLower(letra));
        }

        // Agregar dígitos del 0 al 9
        for (char digito = '0'; digito <= '9'; digito++)
        {
            caracteresEspañoles.Add(digito);
        }
    }

    public void EscribirDelay(String frase, int delay)
    {
        VaciarArchivo();
        char letra = ' ';
        String fraseActual = "";
        int pos = 0;

        try
        {
            // Abrir el archivo para escribir (crea uno nuevo si no existe)
            using (FileStream fileStream = new FileStream(rutaRelativa, FileMode.Append, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                for (int i = 0; frase != fraseActual; i++)
                {
                    if (i >= caracteresEspañoles.Count)
                    {
                        i = 0;
                    }

                    if (String.Equals(frase[pos], letra))
                    {
                        fraseActual += letra;
                        pos++;
                    }

                    if (frase == fraseActual)
                    {
                        System.Console.WriteLine(fraseActual);
                        return;
                    }

                    else Console.WriteLine(fraseActual + letra);

                    letra = caracteresEspañoles[i];
                    Thread.Sleep(delay);
                    streamWriter.WriteLine(fraseActual + letra);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al escribir en el archivo: " + e.Message);
        }
    }

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
                Console.WriteLine("Escribe una frase a escribir: ");
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

    public int ComprobarNum()
    {
        try
        {
            string input;
            int delay;
            do
            {
                Console.Write("Escribe la cantidad de delay para escribir: ");
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