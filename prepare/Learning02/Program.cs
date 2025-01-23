using System;

class Program
{
    static void Main(string[] args)
    {
        var resume = new Resume();
        resume._name = "Bob";

        var job1 = new Job();
        job1._company = "Generic Corp";
        job1._jobTitle = "HR";
        job1._startYear = 1969;
        job1._endYear = 1984;

        var job2 = new Job();
        job2._company = "Meta";
        job2._jobTitle = "Supa Hacka";
        job2._startYear = 1985;
        job2._endYear = 2000;

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}