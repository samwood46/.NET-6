
using System.Linq;
using System.Xml.Linq;


// struct in c# is a lightweight data structure that can contain fields, properties and methods and other members
// Structs are value types, meaning they store their data directly within their memory allocation and are typically used for small, simple data types.
// a record is a special type introduced in c# 9.0 that is used for immutable data representation
// newer feature introduced in C# 9.0
// record struct combines the 2 ie immuatble data objects, promoting safer and more predicatble code, 

//ie. simplifies comparison operations based on value rather than reference 
// ie. records reduce 
public record struct Dialog 
{
    
    public Dialog(int dialogNr, string dialogName, string dialogTitle)
    {
        DialogOrdinalNr = dialogNr;
        DialogName = dialogName;
        DialogTitle = dialogTitle;
        DialogNotes = Array.Empty<string>();
    }

    // Constructor that initializes a Dialog object with dialog number, name, and title,
    // and calls another constructor of the same class to reuse initialization logic.
    public Dialog(int dialogNr, string dialogName, string dialogTitle, string dialogNote)
        : this(dialogNr, dialogName, dialogTitle) // this is referencing the constructor above, which basically means that you can create a dialog with or without a dialogNote
    {
        DialogOrdinalNr = dialogNr;
        DialogName = dialogName;
        DialogTitle = dialogTitle;
        AddDialogNote(dialogNote);




    }
    public int DialogOrdinalNr { get; private set; }
    public string DialogName { get; set; }
    public string DialogTitle { get; set; }
    public string[] DialogNotes { get; set; }


    public void AddDialogNote(string dialogNote)
    {
        DialogNotes ??= Array.Empty<string>(); // can be nullable 
        DialogNotes = DialogNotes.Append(dialogNote).ToArray();
    }

}
public class Result
{
    public static void Main(string[] args)
    {
        Dialog questionnaireDialog1 = new(1, "Questionnaire Dialog", "This is a questionnaire dialog.");
        Dialog questionnaireDialog2 = questionnaireDialog1 with{ DialogNotes = Array.Empty<string>() }; // This line makes an immutable copy of questionnaireDialog1 and the DialogNotes for questionnaireDialog2  = Array.Empty<string>()

        Console.WriteLine(questionnaireDialog1 == questionnaireDialog2);
        Console.WriteLine(questionnaireDialog2);
    }
}
