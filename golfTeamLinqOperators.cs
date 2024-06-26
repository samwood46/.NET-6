
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;


var golfTeam = new List<TeamMember>()
{
    new TeamMember() { SSN = 248161907, MemberName = "Freddy Pham", Age = 63 },
    new TeamMember() { SSN = 529436614,    MemberName = "Romeo Dean",   Age = 32 },
    new TeamMember(){ SSN = 541221084, MemberName = "Bradley Cochran", Age = 67 },
    new TeamMember() { SSN = 232370524, MemberName = "Marissa Cardenas", Age = 55 }
};

var cricketTeam = new List<TeamMember>()
{
        new TeamMember() { SSN = 478623287, MemberName = "Gerard Ashley", Age = 54 },
        new TeamMember() { SSN = 248161907, MemberName = "Freddy Pham", Age = 63 },
        new TeamMember() { SSN = 541221084, MemberName = "Bradley Cochran", Age = 67 },
        new TeamMember() { SSN = 468689231, MemberName = "Josef Mitchell", Age = 31 }
        };

// The group is brought together  based on the SSN
// They're grouped together based on their age e. age is now they key
// then they are getting the values with the max key, in this case age
var members = golfTeam.UnionBy(cricketTeam, s => s.SSN).GroupBy(o => o.Age).MaxBy(d => d.Key); 

foreach (var member in members)
{
Console.WriteLine(JsonSerializer.Serialize(member));
    }
public class TeamMember

{
    public TeamMember() { }
    public int SSN { get; set; }
    public string MemberName { get; set; }
    public int Age { get; set; }
}
