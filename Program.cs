using System;
using System.Collections.Generic;

namespace DemoACS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = TspFileReader.ReadTspFile(@"C:\Users\QuocVinh\Downloads\Compressed\asc\asc\test\demo.tsp");

            DoThi dothi = new DoThi(points, true);
            GreedyAlgorithm greedyAlgorithm = new GreedyAlgorithm(dothi);
            double greedyShortestTourDistance = greedyAlgorithm.Run();

            Parameters parameters = new Parameters()
            {
                T0 = (1.0 / (dothi.Dimensions * greedyShortestTourDistance))
            };
            parameters.Show();

            Solver solver = new Solver(parameters, dothi);
            List<double> results = solver.RunACS();

            Console.ReadLine();
        }
    }
}
