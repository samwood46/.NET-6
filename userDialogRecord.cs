


using System;
using System.Collections.Generic;
using System.Linq;

public class Result
{
    // Define record types outside of any method or constructor
    public record UserDialog(
        int DialogOrdinalNr,
        string DialogName,
        string DialogTitle,
        ICollection<DialogStep> Steps);

    public record DialogStep(
        int StepNr,
        string Title,
        string Description,
        string Summary);

    // Constructor to initialize the dialogSteps and userDialog
    public Result()
    {
        // Initialize dialogSteps
        IList<DialogStep> dialogSteps = Enumerable.Range(0, 10)
            .Select(index => new DialogStep(index + 1,
                $"This is a basic info screen {index + 1}",
                $"Step description {index + 1}",
                $"Step summary {index + 1}"))
            .ToList();

        // Initialize userDialog using dialogSteps
        UserDialog userDialog = new UserDialog(1, "QuizDialog", "Quiz dialog", dialogSteps);

        // Optionally, perform actions with userDialog
       // Console.WriteLine($"UserDialog created: {userDialog.DialogName}, {userDialog.DialogTitle}");


        // '^' means from the end or the end collection
        IList<DialogStep> lastStepA = userDialog.Steps.TakeLast(4).SkipLast(1).ToList(); //returns 7,8,9 
        IList<DialogStep> lastStepsB= userDialog.Steps.TakeLast(4).Skip(1).ToList(); //returns 8,9,10
        IList<DialogStep> lastStepsC = userDialog.Steps.Take(^4..^1).ToList(); //returns 7,8,9
        IList<DialogStep> lastStepsD = userDialog.Steps.Take(^3..).ToList(); // returns 8,9 
    }

    // Main method to execute the program
    public static void Main(string[] args)
    {
        // Create an instance of Result to run the initialization logic
        Result result = new Result();

        // Optionally, call other methods or perform additional actions here
    }
}


//your code snippet