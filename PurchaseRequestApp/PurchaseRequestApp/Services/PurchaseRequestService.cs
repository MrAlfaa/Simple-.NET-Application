using System.Collections.Generic;
using System.Threading.Tasks;
using PurchaseRequestApp.Models;
using PurchaseRequestApp.Repositories;

namespace PurchaseRequestApp.Services
{
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly IPurchaseRequestRepository _repository;

        public PurchaseRequestService(IPurchaseRequestRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<PurchaseRequest>> GetPendingRequestsAsync()
        {
            return _repository.GetPendingRequestsAsync();
        }

        public Task<PurchaseRequest> GetRequestByIdAsync(int id)
        {
            return _repository.GetRequestByIdAsync(id);
        }

        public Task AddRequestAsync(PurchaseRequest request)
        {
            return _repository.AddRequestAsync(request);
        }

        public Task ApproveRequestAsync(int id)
        {
            return _repository.ApproveRequestAsync(id);
        }

        public Task DisapproveRequestAsync(int id)
        {
            return _repository.DisapproveRequestAsync(id);
        }
    }
}
