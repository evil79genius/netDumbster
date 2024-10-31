namespace netDumbster.smtp;

public interface IMessageStore : IEnumerable<SmtpMessage>
{
    public void Add(RawSmtpMessage message);
    public int Count { get; }
    public bool IsEmpty { get; }
    public void Clear();
}
