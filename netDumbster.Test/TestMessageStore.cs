using System.Collections;

namespace netDumbster.Test;

public class TestMessageStore : IMessageStore
{
    private List<SmtpMessage> _messages;

    public TestMessageStore()
    {
        _messages = new List<SmtpMessage>();
    }

    public int Count => _messages.Count;

    public bool IsEmpty => _messages.Count == 0;

    public void Add(RawSmtpMessage message)
    {
        lock (_messages)
        {
            _messages.Add(new SmtpMessage(message));
        }
    }

    public void Clear()
    {
        lock (_messages)
        {
            _messages.Clear();
        }
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
