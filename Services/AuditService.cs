using AuditTrailApi.Models;
using System.Threading.Channels;

namespace AuditTrailApi.Services;

public class AuditService
{
    //Example 1
    public AuditResult CompareObjectsWithDic(Dictionary<string, object> before, Dictionary<string, object> after, string userId, string entityName, AuditAction action)
    {
        var changes = new List<ChangeDetail>();
        try
        {
            foreach (var kvp in after)
            {
                before.TryGetValue(kvp.Key, out var beforeValue);
                var afterValue = kvp.Value;

                if (!object.Equals(beforeValue, afterValue))
                {
                    changes.Add(new ChangeDetail
                    {
                        Property = kvp.Key,
                        OldValue = beforeValue?.ToString(),
                        NewValue = afterValue?.ToString()
                    });
                }
            }
            return new AuditResult
            {
                EntityName = entityName,
                UserId = userId,
                Timestamp = DateTime.UtcNow,
                Changes = changes
            };
        }
        catch (Exception Ex)
        {
            //Log error
        }
        return new AuditResult
        {
            EntityName = entityName,
            UserId = userId,
            Timestamp = DateTime.UtcNow,
            Changes = changes,
            ResultIsOk = false
        };
    }
    //Example 2
    public AuditResult CompareWihClassObjects(Info before, Info after, string userId, string entityName, AuditAction action)
    {
        var changes = new List<ChangeDetail>();
        try
        {
            if (before.Name != after.Name)
            {
                changes.Add(new ChangeDetail
                {
                    Property = nameof(before.Name),
                    OldValue = before.Name.ToString(),
                    NewValue = after.Name.ToString()
                });
            }
            if (before.Email != after.Email)
            {
                changes.Add(new ChangeDetail
                {
                    Property = nameof(before.Email),
                    OldValue = before.Email.ToString(),
                    NewValue = after.Email.ToString()
                });
            }
            if (before.DOB != after.DOB)
            {
                changes.Add(new ChangeDetail
                {
                    Property = nameof(before.DOB),
                    OldValue = before.Name.ToString(),
                    NewValue = after.Name.ToString()
                });
            }
            return new AuditResult
            {
                EntityName = entityName,
                UserId = userId,
                Timestamp = DateTime.UtcNow,
                Changes = changes
            };
        }
        catch (Exception ex)
        {
            //Log error 
        }
        return new AuditResult
        {
            EntityName = entityName,
            UserId = userId,
            Timestamp = DateTime.UtcNow,
            Changes = changes,
            ResultIsOk = false
        };
    }
}