// See https://aka.ms/new-console-template for more information

using Algorithms.Benchmarks;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<SortBenchmarks>();