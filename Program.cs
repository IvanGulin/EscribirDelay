public class Program
{
    public static void Main(string[] args)
    {
        Pajarito pajarito= new Pajarito();
        ListaTareas listaTareas = new ListaTareas();
        Menu();
        
        void Menu()
        { 
            byte entrada = 0;

            do
            {
                System.Console.WriteLine("\nPrograma de escritura con delay, eliga la opción que desee para continuar: \n");
                System.Console.WriteLine("  1. Entrar en el menú de: Escribir con delay. \n");
                System.Console.WriteLine("  2. Entrar en el menú de: Lista de tareas. \n");
                System.Console.WriteLine("  0. Salir \n");
                entrada = (byte)Comprobar.ComprobarNum(1);

                switch (entrada)
                {
                    case 0:
                        System.Console.WriteLine("Saliendo del programa...");
                        break;
                    case 1: 
                        pajarito.Menu();
                        break;
                    case 2:
                        listaTareas.ListaTareasMenu();
                        break;
                    default: 
                        System.Console.WriteLine("No has introducido un valor válido.");
                        break;
                }
            }while(entrada != 0);
        }
    }
}
