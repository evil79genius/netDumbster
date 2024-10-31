using System.Collections;

namespace netDumbster.smtp;

public class SimpleSmtpMessageStore : IMessageStore
{
    private ConcurrentBag<SmtpMessage> _messages;

    public SimpleSmtpMessageStore()
    {
        _messages = new ConcurrentBag<SmtpMessage>();
    }

    public int Count => _messages.Count;

    public bool IsEmpty => _messages.IsEmpty;

    public void Add(RawSmtpMessage message)
    {
        _messages.Add(new SmtpMessage(message));
    }

    public void Clear()
    {
#if NETCOREAPP2_0_OR_GREATER
        _messages.Clear();
#else
        while (!_messages.IsEmpty)
        {
            _messages.TryTake(out SmtpMessage _);
        }
#endif
    }

    public IEnumerator<SmtpMessage> GetEnumerator()
    {
        return _messages.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _messages.GetEnumerator();
    }
}
