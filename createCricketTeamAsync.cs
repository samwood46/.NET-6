

internal class Program // a class that is only accessible within its own assembly
{
    private static async Task Main(string[] args)
    {
        // Define two cricket teams with their members

        (string, string)[] cricketTeam1 = { ("Freddy", "Pham"), ("Bradley", "Cochran"), ("Marissa", "Cardenas") }; //Cricket team 1 
        (string, string)[] cricketTeam2 = { ("Gerard", "Ashley"), ("Josef", "Mitchell"), ("Douglas", "Coleman") }; // Cricket team 2 

        // Start asynchronous tasks to create both cricket teams

        var createTask1 = CreateCricketTeamAsync(cricketTeam1);
        var createTask2 = CreateCricketTeamAsync(cricketTeam2);

        // Wait for both tasks to complete

        var allTasks = Task.WhenAll(createTask2, createTask1); // do both tasks
        try
        {

            await allTasks; // Await the completion of all tasks
        }
        catch (Exception ex)
        {
            // Handle exceptions that occurred during task execution

            if (allTasks.Exception is not null)
            {
                foreach (var exception in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine($"Task execution failed with exception: {exception.Message}");
                }
            }
        }

        // Asynchronous method that returns an asynchronous enumerable sequence of team players
        async Task<IAsyncEnumerable<(string, string)>> CreateCricketTeamAsync((string, string)[] members)
        {
            CricketTeam cricketTeam = new(members);

            IAsyncEnumerable<(string FirstName, string LastName)> teamPlayers = cricketTeam.GetTeamPlayersAsync();

            await foreach (var player in teamPlayers)
            {
                Console.WriteLine($"{player.FirstName} {player.LastName}");
            }
            return teamPlayers;
        }
    }
}
class CricketTeam
{
    private (string, string)[] _members;

    public CricketTeam((string, string)[] members) => _members = members;

    // Asynchronous method that returns an asynchronous enumerable sequence of team players

    public async IAsyncEnumerable<(string, string)> GetTeamPlayersAsync()
    {
        for (int i = 0; i < _members.Length; i++)
        {
            Console.WriteLine($"Getting {i + 1} team player"); // print statement for getting a number of team players 
            // yield allows for multiple return statements ie. good for loops
            yield return _members[i]; //returns the i'th player asynchrnosously 
        }
    }
}

