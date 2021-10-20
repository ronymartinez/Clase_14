using System;
using System.IO;

namespace Clase_Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //VerificarSistemaOperativo();
            //ObtenerInformacion();
            //ObtenerInformacionAlmacenamiento();
            //TrabajarConRutas();
            EscribirArchivoTextoConStreamReaderYFinally();
            LeerArchivoTextoConStreamReaderYFinally();

        }
        static void VerificarSistemaOperativo()
        {
            Console.WriteLine($"Es Windows? {OperatingSystem.IsWindows()}");
            Console.WriteLine($"Es Linux? {OperatingSystem.IsLinux()}");
            Console.WriteLine($"Es MacOs? {OperatingSystem.IsMacOS()}");
            Console.WriteLine($"Es IOS? {OperatingSystem.IsIOS()}");
            Console.WriteLine($"Es Android? {OperatingSystem.IsAndroid()}\n");
        }
        static void ObtenerInformacion()
        {
            Console.WriteLine("sistema Operativo {0}", Environment.OSVersion);
            Console.WriteLine("Plataforma {0}", Environment.OSVersion.Platform);
            Console.WriteLine("Version {0}", Environment.OSVersion.Version);
            Console.WriteLine("Version {0}", Environment.OSVersion.VersionString);
            Console.WriteLine("Cant procesadores lógicos {0}", Environment.ProcessorCount);
            Console.WriteLine("Arq 64 bits? {0}", Environment.Is64BitProcess);
            Console.WriteLine("Usuario OS {0}", Environment.UserName);
            Console.WriteLine($"Texto {Environment.NewLine} salto de línea\n");
        }

        static void ObtenerInformacionAlmacenamiento()
        {
            DriveInfo[] volumenes = DriveInfo.GetDrives();
            foreach (DriveInfo unidad in volumenes)
            {
                Console.WriteLine($"{unidad.Name}");
                Console.WriteLine($"{unidad.DriveType}");
                Console.WriteLine($"{unidad.DriveFormat}");
                Console.WriteLine($"{unidad.TotalSize}");
                Console.WriteLine($"{unidad.AvailableFreeSpace}");
                Console.WriteLine($"----------{Environment.NewLine}");
            }
        }
        static void CrearDirectorio()
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine($"Ruta escritorio: {rutaEscritorio}");

            string rutaNuevoDirectorio = Path.Combine(rutaEscritorio, "Prueba");
            Console.WriteLine($"Ruta nuevo directorio: {rutaNuevoDirectorio}");

            bool existeDirectorio = Directory.Exists(rutaNuevoDirectorio);


            Directory.CreateDirectory(rutaNuevoDirectorio);

        }

        static void TrabajarConRutas()
        {
            string rutaAbsoluta = Path.GetFullPath(".");
            Console.WriteLine($"Ruta Absoluta: {rutaAbsoluta}");

            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaRelativa = Path.GetRelativePath(rutaEscritorio, ".");
            Console.WriteLine($"Ruta Relativa escritorio a app: {rutaRelativa}");

            string rutaRelativa2 = Path.GetRelativePath(rutaEscritorio, ".");
        }

        static void EscribirArchivoTextoConStreamReaderYFinally()
        {
            StreamWriter streamWriter = null;
            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos");

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                ruta = Path.Combine(ruta, "HolaMundo.txt");

                streamWriter = new StreamWriter(ruta, true);
                streamWriter.WriteLine("¡Hola, ");
                streamWriter.Write("mundo");
            }
            finally
            {
                if (streamWriter is not null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }
        static void LeerArchivoTextoConStreamReaderYFinally()
        {
            StreamReader streamReader = null;
            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "HolaMundo.txt");


                streamReader = new StreamReader(ruta);

                while (!streamReader.EndOfStream)
                {
                    string lineaTexto = streamReader.ReadLine();
                    Console.WriteLine(lineaTexto);
                }
            }
            finally
            {
                if (streamReader is not null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }
        }

        static void EscribirArchivoTextoConStreamWriterYUsing()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Archivos", "HolaMundo.txt");

            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.WriteLine("¡Hola, ");
                streamWriter.Write("mundo");
            }
        }

    }
}
