using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using matrixes;


namespace working_with_matrixes_from_files
{
     class Program
    {
        static void Main(string[] args)
        {
            string path;

            if (args.Length > 0)
            {
                //входной параметр main 
                path = args[0];
            }
            else
            {
                //входной параметр для ввода после начала работы программы, если в main ничего не было передано 
                Console.WriteLine("Input the directory:");
                path = Console.ReadLine();
            }
            
            DirectoryInfo dir = new DirectoryInfo(path);

            if (Directory.Exists(path))
            {

                Console.WriteLine("Checking directory:");
                FileInfo[] files = dir.GetFiles();
                if (files.Count() > 0) {
                    foreach (FileInfo i in files)
                    {
                        Console.WriteLine("File:" + "\"" + i.Name + "\"");
                    }
                    foreach (FileInfo i in files)
                    {
                        Console.WriteLine("going into file: " + i.Name);
                        operation(path, i.Name);
                    }
                }  
                else
                {
                    Console.WriteLine("Directry is empty");
                } 
            }
            else
            {
                Console.WriteLine("Directry does not exist");
            }

        }

        static void operation(string path, string file)
        {

            Console.WriteLine("\n\n");

            //full way to file
            string way = path + @"\" + file;
            //connecting to file
            StreamReader sr = new StreamReader(way, System.Text.Encoding.Default);

            //getting operation name
            string opername = sr.ReadLine();
            Console.WriteLine("Operation name: " + opername);

            //getting out of empty spot between operation and matrix itself
            string randomstring = sr.ReadLine();
            

            string newfilename = file + "_result.txt";
            //writting every line of matrix into list
            ArrayList a = filetolist(way,sr);
            Console.WriteLine("Arraylist is ready");
            Matrix matrixA = new Matrix(a);
            Console.WriteLine("matrix is ready");
            //multiply,add, subtract, transpose
            switch (opername) {
                case "multiply":
                    Console.WriteLine("Reading next matrix");
                    ArrayList b = filetolist(way, sr);
                    Matrix matrixB  = new Matrix(b);
                    Console.WriteLine("multipling");
                    matrixA = operations.multiply(matrixA, matrixB);
                    matrixA.fileprint(path +@"\"+ newfilename);
                break;

                case "add":
                    Console.WriteLine("Reading next matrix");
                    ArrayList c = filetolist(way, sr);
                    Matrix matrixC = new Matrix(c);
                    Console.WriteLine("Adding");
                    operations.add(matrixA, matrixC);
                    matrixA.fileprint(path + @"\" + newfilename);
                break;

                case "subtract":
                    Console.WriteLine("Reading next matrix");
                    ArrayList d = filetolist(way, sr);
                    Matrix matrixD = new Matrix(d);
                    Console.WriteLine("Substracting");
                    operations.substract(matrixA, matrixD);
                    matrixA.fileprint(path + @"\" + newfilename);
                break;

                case "transpose":
                    Console.WriteLine("Transponsing");
                    matrixA =operations.transpose(matrixA);
                    matrixA.fileprint(path + @"\"+ newfilename);
                    while (sr.Peek() > -1)
                    {
                        Console.WriteLine("Reading next matrix");
                        ArrayList E = filetolist(way, sr);
                        matrixA = new Matrix(E);
                        Console.WriteLine("Transponsing");
                        matrixA=operations.transpose(matrixA);
                        matrixA.fileprint(path + @"\" + newfilename);
                    }
                break;
            
            }
            Console.WriteLine("All Operations are done");


        }

        static ArrayList filetolist(string path, StreamReader sr)
        {
            ArrayList a = new ArrayList();
            //убираем пустую строчку после названия операции
            string line_of_matrix = sr.ReadLine();
            Console.WriteLine("Reading data form file\n");

            while (line_of_matrix != null && line_of_matrix!=string.Empty)
            {

                a.Add(line_of_matrix);
                line_of_matrix = sr.ReadLine();
            }

            return a;
        }

    }
}


