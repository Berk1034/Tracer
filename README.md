# Task
## It is necessary to implement a method runtime meter.

*The class should implement the following interface:*
````C#
public interface ITracer
{
  // called at the beginning of the measured method
  void StartTrace ();

  // called at the end of the measured method
  void StopTrace ();

  // get measurement results
  TraceResult GetTraceResult ();
}
````
*The structure of `TraceResult` is at the discretion of the author.
`Tracer` should collect the following information about the measured method:*

* *method name;*
* *class name with a measured method;*
* *method execution time.*

*The total execution time of the analyzed methods in one thread should also be calculated.*

*Trace results of nested methods should be presented in the appropriate place in the result tree.*

*The measurement result should be presented in two formats: **JSON and XML** (for classes that implement serialization into these formats, it is necessary to develop a common interface).*

*The finished result (received JSON and XML) should be output to the console and written to a file. For these classes, it is necessary to develop a common interface, it is permissible to create one reusable class, regardless of where the result should be output (see General errors).*

**The completed work code should consist of three projects:**
* *The main part of the library that implements the measurement and formatting of results.*
* *Unit tests for the main part of the library.*
* *A console application containing classes for outputting results to the console and a file that demonstrates the general case of the library (in multi-threaded mode when tracing nested methods).*
