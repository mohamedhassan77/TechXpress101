using TechXpress.Data;
using TechXpress.Models;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task<Payment> GetPaymentByIdAsync(int id);
    Task AddPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
}

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        return await _unitOfWork.Payments.GetAllAsync();
    }

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        return await _unitOfWork.Payments.GetByIdAsync(id);
    }

    public async Task AddPaymentAsync(Payment payment)
    {
        await _unitOfWork.Payments.AddAsync(payment);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        _unitOfWork.Payments.Update(payment);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeletePaymentAsync(int id)
    {
        var payment = await _unitOfWork.Payments.GetByIdAsync(id);
        if (payment != null)
        {
            _unitOfWork.Payments.Remove(payment);
            await _unitOfWork.CompleteAsync();
        }
    }
}