// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Service.Benchmark;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<FilterBenchmark>();

//FilterBenchmark filterBenchmark = new FilterBenchmark();

//var a = filterBenchmark.GetOrderDtos();
//var b = filterBenchmark.GetOrderDtosAsync();
//Console.WriteLine(a);
//Console.WriteLine(b);