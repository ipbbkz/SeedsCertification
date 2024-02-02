using Microsoft.AspNetCore.Mvc;

namespace СертификацияСемян.Controllers;

public class RequestController
{
    private readonly УправляющийЗаявками управляющийЗаявками;

    public RequestController(УправляющийЗаявками управляющийЗаявками)
    {
        this.управляющийЗаявками = управляющийЗаявками ?? throw new ArgumentNullException(nameof(управляющийЗаявками));
    }

    [HttpGet("requests/{ид}/nematods")]
    public Stream GetNematods(int ид)
    {
        var документы = управляющийЗаявками.ПолучитьЗаключениеОНематодах(ид);
        return new MemoryStream(документы);
    }

    [HttpGet("requests/{ид}/certificateorigin")]
    public Stream GetCertificateOrigin(int ид)
    {
        var документы = управляющийЗаявками.ПолучитьСвидетельствоПроисхожденияСемян(ид);
        return new MemoryStream(документы);
    }
}
