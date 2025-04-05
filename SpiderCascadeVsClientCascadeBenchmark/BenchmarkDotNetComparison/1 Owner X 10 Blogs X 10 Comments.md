```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
12th Gen Intel Core i5-12400F, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2 [AttachedDebugger]
  Job-SUQISH : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method              | Mean     | Error    | StdDev   | StdErr   | Min       | Q1       | Median   | Q3       | Max      | Op/s  | Allocated  |
|-------------------- |---------:|---------:|---------:|---------:|----------:|---------:|---------:|---------:|---------:|------:|-----------:|
| FilipTrivanDelete   | 18.01 ms | 0.911 ms | 2.627 ms | 0.268 ms |  4.439 ms | 16.64 ms | 17.91 ms | 19.14 ms | 23.67 ms | 55.52 |  129.74 KB |
| ClientCascadeDelete | 57.15 ms | 1.959 ms | 5.590 ms | 0.577 ms | 37.943 ms | 54.10 ms | 56.48 ms | 60.62 ms | 72.24 ms | 17.50 | 7004.27 KB |
