// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Sorting.Benchmarks;

var summary = BenchmarkRunner.Run<SortBenchmarks>();