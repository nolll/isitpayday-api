using System.Text;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class JsonResult(object data) : ActionResult
{
    [UsedImplicitly]
    public Encoding? ContentEncoding { get; set; }

    [UsedImplicitly]
    public string? ContentType { get; set; }

    [UsedImplicitly]
    public object Data { get; set; } = data;
}