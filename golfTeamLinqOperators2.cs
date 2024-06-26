
using System.Runtime.Intrinsics.X86;

var golfTeam = new List<TeamMember>()
{
    new TeamMember() { SSN ="318620034", MemberName = "George Grimes", Age = 33 },
    new TeamMember() {SSN="248161907", MemberName = "Freddy Pham", Age = 69},
    new TeamMember() {SSN="529436614", MemberName = "Romeo Dean", Age = 52 },
    new TeamMember() { SSN="304964975", MemberName = "Morgan Bradshaw", Age= 28},
    new TeamMember() { SSN="541221084", MemberName = "Bradley Cochran", Age = 49 },
    new TeamMember() { SSN = "232370524", MemberName = "Marissa Cardenas", Age = 55 }
    };


var cricketTeam = new List<TeamMember>()
{
    new TeamMember() {SSN = "478623287", MemberName = "Gerard Ashley", Age = 64 },
    new TeamMember() {SSN="248161907", MemberName = "Freddy Pham", Age = 69},
    new TeamMember() { SSN="253265806", MemberName="Asad Donaldson", Age = 76},
    new TeamMember() { SSN="526649003", MemberName = "Alan Shelton", Age = 33 },
    new TeamMember() { SSN="541221084", MemberName = "Bradley Cochran", Age  = 49 },
    new TeamMember() { SSN = "468689231", MemberName = "Josef Mitchell", Age = 77 }
    };


List<TeamMember> members = golfTeam.OrderBy(o => o.SSN).ThenByDescending(d => d.MemberName).ExceptBy(cricketTeam.Select(s => s.ToString()), e => e.ToString()).ToList();

members.ForEach(member => Console.WriteLine(member.ToString()));

public class TeamMember
{
    public string SSN { get; set; }
    public string MemberName { get; set; }
    public int Age { get; set; }
    public override string ToString() => $"<{SSN}> { MemberName}";
}

    