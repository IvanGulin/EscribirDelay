public class Program
{
    public static void Main(string[] args)
    {
        Pajarito pajarito= new Pajarito();
        
        String frase = pajarito.ComprobarCadena();
        
        int delay = pajarito.ComprobarNum();

        pajarito.EscribirDelay(frase, delay);
    }
}
