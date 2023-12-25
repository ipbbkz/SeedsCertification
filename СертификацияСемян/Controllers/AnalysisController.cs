using Microsoft.AspNetCore.Mvc;

namespace СертификацияСемян.Controllers;

public class AnalysisController : Controller
{
    private readonly УправляющийИнспекциями управляющийИнспекциями;
    public AnalysisController(УправляющийИнспекциями управляющийИнспекциями)
    {
        this.управляющийИнспекциями = управляющийИнспекциями ?? throw new ArgumentNullException(nameof(управляющийИнспекциями));
    }

    [HttpGet("analysis/{ид}/file")]
    public Stream GetLabAnalysis(int ид)
    {
        var документы = управляющийИнспекциями.ПолучитьРезультатыАнализов(ид);
        return new MemoryStream(документы ?? Array.Empty<byte>());
    }
}
