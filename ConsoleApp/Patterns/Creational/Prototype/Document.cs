using System.Text.Json;

namespace ConsoleApp.Patterns.Creational.Prototype;

public class Document(string title, string content) : IPrototype<Document>
{
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;

    public Document Clone() => new (Title, Content);

    public override string ToString() => JsonSerializer.Serialize(this);
}
