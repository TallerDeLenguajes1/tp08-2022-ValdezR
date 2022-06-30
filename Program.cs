    Console.WriteLine("Ingrese el directorio");
    int verif = 0;
    string path;
    do
    {
        if (verif > 0)
        {
            Console.WriteLine("\nEl directorio ingresado no existe, ingrese de nuevo");
        }

        path = Console.ReadLine();
        verif++;
    } while (!Directory.Exists(path));

    if (Directory.GetFiles(path).Length > 0)
    {
        List<string> archivos = Directory.GetFiles(path).ToList();//creo una lista con los archivos//Directory,GetFile: Devuelve los nombres de archivo  con sus rutas

        var escribir = new StreamWriter(File.Open("../index.csv", FileMode.Create));//abre el archivo index y si no existe lo crea

        int i = 1;
        foreach (var item in archivos)
        {

            string arreglo = Path.GetFileNameWithoutExtension(item); //Devuelve el nombre de archivo sin la extensión de una ruta de acceso
            string ext = Path.GetExtension(item);//Devuelve la extensión de una ruta de acceso de archivo
            string insertar = $"{i},{arreglo},{ext}";//arma la cadena a insertar en el archivo CSV
            escribir.WriteLine(insertar);//inserta en el archivo INDEX los datos del primer archivo recorrido del directorio seleccionado
            i++;
        }
        Console.WriteLine("\nNombre de archivos insertados en index.csv:");
        escribir.Close(); //cierro el archivo ESCRIBIR creado con streamWriter
        
        var leer = new StreamReader(File.Open("../index.csv", FileMode.Open));//Abre el archivo existente
        Console.WriteLine(leer.ReadToEnd());//lee todos los caracteres hasta el final y los devuelve como una cadena unica
        leer.Close();//Cierra el archivo abierto recientemente

    }
    else
    {
        Console.WriteLine("\nNo hay ningún archivo en esa carpeta");
    }