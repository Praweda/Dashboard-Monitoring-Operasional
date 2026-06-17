using System;

namespace BJB.Dashboard.Library.Message.Response;

public class ResponseEntity
{
    public bool success { get; set; }
    public bool exception { get; set; } = false;
    public string? code { get; set; }
    public string? message { get; set; }
    public object? result { get; set; }
}
