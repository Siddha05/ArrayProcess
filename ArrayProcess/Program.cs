namespace ArrayProcess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public (int min, int max, double[] avgs) Process(int[,] array)
        {
            int min = array[0,0];
            int max = array[0,0];
            double[] avg = new double[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double row_avg = default;
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] < min) min = array[i,j];
                    if (array[i,j] > max) max = array[i,j];
                    row_avg += array[i,j];
                }
                avg[i] = row_avg / array.GetLength(1);
            }
            return (min, max, avg);
        }
    }
}
