using AuditTrailApi.Models;

namespace AuditTrailApi.Models;

//Example 1
public class AuditRequest
{
    public Dictionary<string, object> Before { get; set; }
    public Dictionary<string, object> After { get; set; }
    public string UserId { get; set; }
    public string EntityName { get; set; }
    public AuditAction Action { get; set; }
}

//Example 2
public class AuditRequestByClassObject
{
    public Info BeforeInfo { get; set; }
    public Info AfterInfo { get; set; }
    public string UserId { get; set; }
    public string EntityName { get; set; }
    public AuditAction Action { get; set; }
}
//Only For Example 2
public class Info
{
    public string Name { get; set; }
    public string DOB { get; set; }
    public string Email { get; set; }
}