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
