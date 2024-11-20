using System;

// Define the delegate type for the events
public delegate void DisplayMessage();

public class Student
{
    // Declare the events
    public event DisplayMessage Pass; // Event for passing
    public event DisplayMessage Fail; // Event for failing

    public void AcceptMarks(int marks)
    {
        if (marks >= 40)
        {
            Pass?.Invoke();  // Trigger the Pass event if there are subscribers
        }
        else
        {
            Fail?.Invoke();  // Trigger the Fail event if there are subscribers
        }
    }
}

public class Program
{
    static void PassMsg()
    {
        Console.WriteLine("Congratulations! You passed with a good score.");
    }

    static void FailMsg()
    {
        Console.WriteLine("Oops! You failed.");
    }

    static void Main(string[] args)
    {
        Student stud = new Student();

        // Bind the events to the delegate methods
        stud.Pass += PassMsg;
        stud.Fail += FailMsg;

        // Test by calling AcceptMarks
        stud.AcceptMarks(30); // Test with a failing score
    }
}
