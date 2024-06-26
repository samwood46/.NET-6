
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;


TeamMember globalTeamMember = new(529436614, "Romeo Dean");
RegionalTeamMember regionalTeamMember = new(248161907, "Freddy Pham", "Massachusetts");
Console.WriteLine(globalTeamMember.ToString());
Console.WriteLine(regionalTeamMember.ToString());
public record TeamMember
{

    public TeamMember() { }
    public TeamMember(int SSN, string MemberName)
    {

        this.SSN = SSN; //for these lines to work we need setters and getters ie lines 20 and 21
        this.MemberName = MemberName;
    }
    public int SSN { get; set; }
    public string MemberName { get; set; }

     
    // In C#, override means that a method in a derived class is replacing a method in its base class.
    public override sealed string ToString() => $"<{SSN}> {MemberName}"; 
}
public record RegionalTeamMember(int SSN, string MemberName, string RegionName): TeamMember
   // regionalteammember is a derived class of teammember 
{
    public override string ToString() => $"<{SSN}> {MemberName} [{RegionName}]";
}