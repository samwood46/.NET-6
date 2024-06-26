using System;


DialogStep defaultStep = new(1, "This is a dialog step", "Step description", "Step summary");
Dialog welcomeDialog = new(1, "Welcome Dialog", "This is a welcome dialog.", new List<DialogStep>());
Dialog wizardDialog = welcomeDialog; // since they are records they are just sharing the same instance in memory
Dialog questionnaireDialog = welcomeDialog with {};

// Creating secretDialog with a new Dialog object in memory,
// initializing its Steps property with a new list containing defaultStep.
Dialog secretDialog = welcomeDialog with { Steps = new List<DialogStep>() { defaultStep } }; 

// Adding defaultStep to welcomeDialog's Steps list affects wizardDialog and questionnaireDialog
// since they reference the same Dialog object in memory.

welcomeDialog.Steps.Add(defaultStep); 
Console.WriteLine(welcomeDialog.Equals(wizardDialog));
Console.WriteLine(welcomeDialog.Equals(questionnaireDialog));
Console.WriteLine(welcomeDialog.Equals(secretDialog));
Console.WriteLine("-----");
Console.WriteLine(wizardDialog.Steps.Count);
Console.WriteLine(questionnaireDialog.Steps.Count);
Console.WriteLine(secretDialog.Steps.Count);

record struct Dialog(int OrdinalNr, string DialogName, string DialogTitle, IList<DialogStep> Steps)
{

    public bool Equals(Dialog? dialog) // dialog can be null
    {
        if (!dialog.HasValue) // if is null return false
            return false;
        if (object.Equals(this, dialog!)) // '!''s purpose is to indicate to the compiler that you are confident that a particular reference will not be null at runtime, even if the compiler cannot determine it statically.
            return true;
        return object.ReferenceEquals(this, dialog!); //checking if the two objects are refernecing the same object in memory
    }

}



record struct DialogStep(int StepNr, string Title, string Description, string Summary);
