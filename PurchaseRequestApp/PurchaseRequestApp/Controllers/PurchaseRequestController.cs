using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class PurchaseRequestController : Controller
{
    private readonly IPurchaseRequestService _service;

    public PurchaseRequestController(IPurchaseRequestService service)
    {
        _service = service;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseRequest model)
    {
        if (ModelState.IsValid)
        {
            model.TotalCost = model.ItemCost * model.ItemQuantity;
            await _service.AddRequestAsync(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public async Task<IActionResult> Approve(int id)
    {
        await _service.ApproveRequestAsync(id);
        return RedirectToAction("Approval");
    }

    public async Task<IActionResult> Disapprove(int id)
    {
        await _service.DisapproveRequestAsync(id);
        return RedirectToAction("Approval");
    }

    public async Task<IActionResult> Approval()
    {
        var requests = await _service.GetPendingRequestsAsync();
        return View(requests);
    }
}
