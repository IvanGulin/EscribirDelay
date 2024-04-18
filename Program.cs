public class Program
{
    public static void Main(string[] args)
    {
        Pajarito pajarito= new Pajarito();
        
        String frase;
        int delay;
        byte entrada = 0;


        do
        {
            System.Console.WriteLine("\nPrograma principal, eliga la opción que desee para continuar: \n");
            System.Console.WriteLine("  1. Escribir frase con delay. \n");
            System.Console.WriteLine("  2. Escribir frase con delay al revés. \n");
            System.Console.WriteLine("  0. Salir \n");
            entrada = (byte)pajarito.ComprobarNum(1);

            switch (entrada)
            {
                case 0:
                    System.Console.WriteLine("Saliendo del programa...");
                    break;
                case 1: 
                    frase = pajarito.ComprobarCadena();
                    delay = pajarito.ComprobarNum(0);
                    pajarito.EscribirDelay(frase, delay);
                    break;
                case 2:
                    frase = pajarito.ComprobarCadena();
                    delay = pajarito.ComprobarNum(0);
                    pajarito.EscribirDelayReves(frase, delay);
                    break;
                default: 
                    System.Console.WriteLine("No has introducido un valor válido.");
                    break;
            }
        }while(entrada != 0);
    }
}
