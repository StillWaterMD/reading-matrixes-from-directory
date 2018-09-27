using System;
using System.Collections;

namespace matrixes
{
    public class Matrix
    {
        private int[,] matrix;
        private int N;
        private int M;


        public int getN()
        {
            return this.N;
        }

        public int getM()
        {
            return this.M;
        }

        public int GetElement(int i,int j)
        {
            return matrix[i,j];
        }
        public void SetElement(int i, int j, int x)
        {
            this.matrix[i, j] = x;
        }

        public void print()
        {
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }

                Console.WriteLine('\n');
            }
               

        }

        public void AddElement(int i, int j, int x)
        {
            matrix[i,j] += x;
        }

        public void swap(int i, int j)
        {
            int temp = matrix[i,j];
            matrix[i,j] = matrix[j,i];
            matrix[j,i] = temp;

        }

        public Matrix(int N, int M)
        {
            matrix = new int[N,M];
            this.M = M;
            this.N = N;

        }

        public Matrix (ArrayList a)
        {

            int [] tempint=NumsFromString(a[0].ToString());
            this.N = a.Count;
            this.M = tempint.Length;
            this.matrix = new int[N, M];
            arraytoline(tempint, 0);

            if (N > 1)
            {
                for (int i = 1; i < N; ++i)
                {
                    //вытаскиваем строку из списка

                    tempint = NumsFromString(a[i].ToString());
                    //записываем строку в массив
                    arraytoline(tempint, i);
                }
            }
           
        }

        public void fileprint(string path)
        {
            Console.WriteLine("Writting result into file:" +"\""+path+ "\"");

            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    System.IO.File.AppendAllText(path, matrix[i,j]+" ");
                }

                System.IO.File.AppendAllText(path, "\r\n");

            }

            System.IO.File.AppendAllText(path, "\r\n");
        }


        
        private void arraytoline(int[] array,int line)
        {
            for (int i=0; i<array.Length; ++i)
            {
                matrix[line, i] = array[i];
            }
        }


        //fuction that takes numbers from string into array
        //numbers are separated with spacebars

        private int [] NumsFromString(String a)
        {
            String [] b =a.Split(' ');
            int[] Num = new int[b.Length];
           
            for (int i = 0; i < Num.Length; ++i)
            {
                Console.WriteLine("Getting element:"+ b[i].TrimEnd(' '));
                Num[i] = Convert.ToInt32(b[i]);
            }

            return Num;
        }
               
    }

    public class operations
    {
        public static Matrix multiply(Matrix A, Matrix B)
        {
            //if (A.getM() != B.getN()) return false;

            int n = A.getN();
            int m = A.getM();
            int l = B.getM();
            Matrix C = new Matrix(A.getN(), B.getM());

            for (int i = 0; i < n; i++)
                for (int j = 0; j < l; j++)
                    for (int k = 0; k < m; k++)
                        C.AddElement(i, j, A.GetElement(i, k) * B.GetElement(k,j));

            return C;

        }

        public static bool add(Matrix A, Matrix B)
        {
            if (A.getN() != B.getN() || A.getM() != B.getM())
            {
                return false;
            }
                            

            for (int i = 0; i < A.getN(); i++)
                for (int j = 0; j < A.getM(); j++)
                    A.AddElement(i, j, B.GetElement(i, j));

            return true;

        }

        public static bool substract(Matrix A, Matrix B)
        {

            if (A.getN() != B.getN() || A.getM() != B.getM()) return false;
            for (int i = 0; i < A.getN(); i++)
                for (int j = 0; j < A.getM(); j++)
                    A.AddElement(i, j, -1*B.GetElement(i, j));

            return true;
        }

        public static Matrix transpose(Matrix A)
        {
            if (A.getM() == A.getN())
            {
            
                for (int i = 0; i < A.getN(); i++)
                    for (int j = i; j < A.getM(); j++)
                        A.swap(i, j);

                return A;
            }
            else
            {
             
                Matrix B = new Matrix(A.getM(), A.getN());
                for (int i = 0; i < A.getN(); i++)
                    for (int j = 0; j < A.getM(); j++)
                        B.SetElement(j, i, A.GetElement(i, j));
                                                
                return B;
            }
        }

    }

}

