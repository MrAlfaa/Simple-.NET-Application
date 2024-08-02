public interface IPurchaseRequestService
{
    Task<IEnumerable<PurchaseRequest>> GetPendingRequestsAsync();
    Task<PurchaseRequest> GetRequestByIdAsync(int id);
    Task AddRequestAsync(PurchaseRequest request);
    Task ApproveRequestAsync(int id);
    Task DisapproveRequestAsync(int id);
}
