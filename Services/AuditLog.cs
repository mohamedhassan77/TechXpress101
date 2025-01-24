using TechXpress.Data;
using TechXpress.Models;

public interface IAuditLogService
{
    Task<IEnumerable<AuditLog>> GetAllAuditLogsAsync();
    Task AddAuditLogAsync(AuditLog auditLog);
}

public class AuditLogService : IAuditLogService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuditLogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AuditLog>> GetAllAuditLogsAsync()
    {
        return await _unitOfWork.AuditLogs.GetAllAsync();
    }

    public async Task AddAuditLogAsync(AuditLog auditLog)
    {
        await _unitOfWork.AuditLogs.AddAsync(auditLog);
        await _unitOfWork.CompleteAsync();
    }
}