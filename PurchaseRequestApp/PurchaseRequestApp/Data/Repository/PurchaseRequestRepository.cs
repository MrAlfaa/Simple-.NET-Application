public class PurchaseRequestRepository : IPurchaseRequestRepository
{
    private readonly ApplicationDbContext _context;

    public PurchaseRequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PurchaseRequest>> GetPendingRequestsAsync()
    {
        return await _context.PurchaseRequests
            .Where(r => !r.IsApproved && !r.IsDisapproved)
            .ToListAsync();
    }

    public async Task<PurchaseRequest> GetRequestByIdAsync(int id)
    {
        return await _context.PurchaseRequests.FindAsync(id);
    }

    public async Task AddRequestAsync(PurchaseRequest request)
    {
        await _context.PurchaseRequests.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task ApproveRequestAsync(int id)
    {
        var request = await _context.PurchaseRequests.FindAsync(id);
        if (request != null)
        {
            request.IsApproved = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DisapproveRequestAsync(int id)
    {
        var request = await _context.PurchaseRequests.FindAsync(id);
        if (request != null)
        {
            request.IsDisapproved = true;
            await _context.SaveChangesAsync();
        }
    }
}
