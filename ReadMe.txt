Write a multithreaded program.
Your program will have an array of integers as follows:
int[] data = new int[10000000];
Create the following function
static void calc( int startingIndex, int reps )
{
  // assign into the data array from startingIndex to
  // startingIndex + reps the following:
  // Math.Atan(i) * Math.Acos(i) * Math.Cos(i) * Math.Sin(i);
}
You will call calc twice. Each time you call it you need to get an elapsed time—how long did
the function take (in milliseconds). The first time it will be not be in a separate thread as
follows:
calc( 0, data.Length );
The next time it is called it must be in four threads, splitting up the processing between all
threads.
Your program must output the following:
Sequentially, calc takes 7654 milliseconds to run.
Multithreaded, calc takes 3123 milliseconds to run.