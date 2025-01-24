    using TechXpress.Data;
    using TechXpress.Models;

    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
    }

    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _unitOfWork.Reviews.GetAllAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _unitOfWork.Reviews.GetByIdAsync(id);
        }

        public async Task AddReviewAsync(Review review)
        {
            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
            _unitOfWork.Reviews.Update(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(id);
            if (review != null)
            {
                _unitOfWork.Reviews.Remove(review);
                await _unitOfWork.CompleteAsync();
            }
        }
    }