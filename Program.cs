public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escribe una frase a escribir");
        String frase = Console.ReadLine()!;

        System.Console.WriteLine("Escribe la cantidad de delay para escribir.");
        int delay = Convert.ToInt32(Console.ReadLine());

        
        
        // Crear una lista para almacenar los caracteres alfanuméricos españoles en UTF-8
        List<char> caracteresEspañoles = new List<char>();
        caracteresEspañoles.Add('ñ');
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

        void EscribirDelay(String frase, int delay)
        {
            char letra = ' ';
            String fraseActual = "";
            int pos = 0;

            for (int i = 0; frase != fraseActual; i++)
            {
                if (i >= caracteresEspañoles.Count)
                {
                    i = 0;
                }
                if (frase[pos] == letra)
                {
                    fraseActual += letra;
                    pos++;
                }
                if (frase == fraseActual) System.Console.WriteLine(fraseActual);
                else Console.WriteLine(fraseActual + letra);
                
                letra = caracteresEspañoles[i];
                Thread.Sleep(delay);
            }
        }
        EscribirDelay(frase, delay);
    }
}
