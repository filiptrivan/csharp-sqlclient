```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
12th Gen Intel Core i5-12400F, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2 [AttachedDebugger]
  Job-ILIAMZ : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method              | Mean      | Error     | StdDev    | StdErr   | Min       | Q1        | Median    | Q3        | Max       | Op/s   | Gen0       | Allocated    |
|-------------------- |----------:|----------:|----------:|---------:|----------:|----------:|----------:|----------:|----------:|-------:|-----------:|-------------:|
| FilipTrivanDelete   |  44.87 ms |  2.797 ms |  7.611 ms | 0.821 ms |  29.15 ms |  38.27 ms |  45.63 ms |  49.39 ms |  62.91 ms | 22.286 |          - |    427.57 KB |
| ClientCascadeDelete | 570.82 ms | 11.338 ms | 16.971 ms | 3.098 ms | 540.46 ms | 560.54 ms | 572.28 ms | 584.17 ms | 598.62 ms |  1.752 | 47000.0000 | 436822.91 KB |
