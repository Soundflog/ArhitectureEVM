using System.Diagnostics;
using System.Threading.Channels;
using Lab5_TestingCPU;

Stopwatch stopwatch = new Stopwatch();
Random rnd = new Random();

stopwatch.Restart();

Console.WriteLine(stopwatch.ElapsedMilliseconds);


stopwatch.Stop();

