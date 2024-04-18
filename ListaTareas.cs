public class ListaTareas
{
    private String directorioActual, rutaRelativa;
    private LinkedList<String> listaTareas;
    private short indice = 1;

    public ListaTareas()
    {
        // Iniciando coleccion "listaTareas".
        listaTareas = new LinkedList<String> ();

        // Obtener la ruta del directorio actual
        directorioActual = Directory.GetCurrentDirectory();

        // Construir la ruta relativa del archivo
        rutaRelativa = Path.Combine(directorioActual, "Tareas.txt");

        FileStream fileStream = new FileStream(rutaRelativa, FileMode.Append, FileAccess.Write);
        fileStream.Close();

        if(indice != 1) indice = (short)(listaTareas.Count + 1);
    }
    public void ListaTareasMenu()
    {
        byte entrada = 0;

        do
        {
            System.Console.WriteLine("\nLista de tareas, elige una de las siguientes opciones: \n");
            System.Console.WriteLine("  1. Añadir tarea a la lista. \n");
            System.Console.WriteLine("  2. Eliminar tarea de la lista. \n");
            System.Console.WriteLine("  3. Mostrar lista de tareas. \n");
            System.Console.WriteLine("  0. Salir \n");
            entrada = (byte)Comprobar.ComprobarNum(1);

            switch (entrada)
            {
                case 0:
                    System.Console.WriteLine("Saliendo del programa...");
                    break;
                case 1: 
                    AddTarea();
                    break;
                case 2: 
                    DelTarea();
                    break;
                case 3: 
                    ShowTarea(0, false);
                    break;
                default: 
                    System.Console.WriteLine("No has introducido un valor válido.");
                    break;
            }
        }while(entrada != 0);
    }

    private String ShowTarea(short num, bool buscar)
    {
        short cont = 1;
        if (buscar)
        {
            foreach (var tarea in listaTareas)
            {
                if (num == cont) return tarea;
                cont++;
            }
        }
        
        else
        {
            System.Console.WriteLine("\n\nMostrando la lista de tareas completa:");
            foreach (var tarea in listaTareas)
            {
                System.Console.WriteLine("\t" + cont + ". " + tarea.ToString().ToUpper());
                cont++;
            }
        }
        System.Console.WriteLine();
        return "";
    }

    private void DelTarea()
    {
        short borrar = (short)Comprobar.ComprobarNum(2);
        String tarea = ShowTarea(borrar, true);

        if (tarea != null) 
        {
            System.Console.WriteLine("Borrando la tarea {" + tarea.ToString() + "} de la lista de tareas...");
            listaTareas.Remove(tarea);
            ReescribirFichero(listaTareas);
        }   
        else System.Console.WriteLine("No has introducido una tarea existente.");
    }

    private void ReescribirFichero(LinkedList<String> listaTareas)
    {
        try
        {
            // Abrir el archivo en modo de escritura, sobrescribiendo el contenido existente
            using StreamWriter streamWriter = new StreamWriter(rutaRelativa);
            indice = 1;

            foreach (var tarea in listaTareas)
            {
                streamWriter.WriteLine(indice + " - " + tarea.ToString());
                indice++;
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al vaciar el archivo: " + e.Message);
        }
    }

    private void AddTarea()
    {
        String tarea = Comprobar.ComprobarCadena(1);
        try
        {
            listaTareas.AddLast(tarea);
            ListaTareasArchivos(tarea);
        }catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void ListaTareasArchivos(String tarea)
    {
        try
        {
            // Abrir el archivo para escribir (crea uno nuevo si no existe)
            using FileStream fileStream = new FileStream(rutaRelativa, FileMode.Append, FileAccess.Write);
            using StreamWriter streamWriter = new StreamWriter(fileStream);
            {
                streamWriter.WriteLine(indice + " - " + tarea);
                indice++;
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al escribir en el archivo: " + e.Message);
        }   
    }
}