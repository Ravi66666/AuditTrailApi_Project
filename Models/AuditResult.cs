namespace AuditTrailApi.Models;

public class AuditResult
{
    public string EntityName { get; set; }
    public string UserId { get; set; }
    public DateTime Timestamp { get; set; }
    public List<ChangeDetail> Changes { get; set; }
    public bool ResultIsOk { get; set; } = true;
    public AuditResult()
    {
        Changes = new List<ChangeDetail>();
    }
}

public class ChangeDetail
{
    public string Property { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
}