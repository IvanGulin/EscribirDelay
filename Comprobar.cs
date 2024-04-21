public class Comprobar
{
    public static String ComprobarCadena(byte num)
    {
        String cadena = "";
        do
        {
            try
            {
                if (num == 0) Console.Write("Escribe una frase a escribir: ");
                if (num == 1) Console.Write("Introduce una descripción de la tarea a añadir: ");

                cadena = Console.ReadLine()!;

                if (cadena.Length > 0)
                {
                    cadena = cadena.ToLower();
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

    public static int ComprobarNum(byte tipo)
    {
        try
        {
            string input;
            int delay;
            do
            {
                if (tipo == 0) Console.Write("Escribe una cantidad para el delay: ");
                if (tipo == 1) Console.Write("Escribe una opción: ");
                if (tipo == 2) Console.Write("Escribe el número de ID de la tarea que deseas borrar: ");

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