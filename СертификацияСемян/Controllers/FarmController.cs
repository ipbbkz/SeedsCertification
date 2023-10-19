using Microsoft.AspNetCore.Mvc;

namespace СертификацияСемян.Controllers;

public class FarmController
{
    private readonly УправляющийХозяйствами управляющийХозяйствами;

    public FarmController(УправляющийХозяйствами управляющийХозяйствами)
    {
        this.управляющийХозяйствами = управляющийХозяйствами ?? throw new ArgumentNullException(nameof(управляющийХозяйствами));
    }

    [HttpGet("farms/{ид}/fields/{идПоля}/documents")]
    public Stream GetField(int ид, int идПоля)
    {
        var документы = управляющийХозяйствами.ПолучитьДокументыНаПоле(идПоля);
        return new MemoryStream(документы);
    }
}
