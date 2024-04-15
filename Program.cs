public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escribe una frase a escribir");
        String frase = Console.ReadLine()!;

        System.Console.WriteLine("Escribe la cantidad de delay para escribir.");
        int delay = Convert.ToInt32(Console.ReadLine());

        Pajarito pajarito= new Pajarito();

        pajarito.EscribirDelay(frase, delay);
    }
}
