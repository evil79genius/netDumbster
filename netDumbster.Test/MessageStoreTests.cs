namespace netDumbster.Test;

public class MessageStoreTests : TestsBase
{
    protected override SimpleSmtpServer StartServer()
    {
        return SimpleSmtpServer.Start();
    }

    protected override SimpleSmtpServer StartServer(int port)
    {
        return SimpleSmtpServer.Start(port);
    }
}
