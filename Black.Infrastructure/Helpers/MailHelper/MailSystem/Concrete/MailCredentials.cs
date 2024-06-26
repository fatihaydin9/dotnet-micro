﻿using Black.Infrastructure.Helpers.MailHelper.MailSystem.Abstract;

namespace Black.Infrastructure.Helpers.MailHelper.MailSystem.Concrete;
public class MailCredentials : IMailCredentials
{
    internal string _hostServer;
    internal string _portNumber;
    internal string _userName;
    internal string _password;
    internal bool _serverRequiresSsl;
    internal IMailer _mailer;
    public MailCredentials()
    {

    }
    public MailCredentials(Mailer mailer)
    {
        _mailer = mailer;
    }

    /// <summary>
    /// The SMTP / IMAP server.
    /// </summary>
    /// <param name="hostServer"></param>
    /// <returns></returns>
    public IMailCredentials UsingHostServer(string hostServer)
    {
        _hostServer = hostServer;
        return this;
    }

    /// <summary>
    /// The port number to use when sending emails.
    /// </summary>
    /// <param name="portNumber">The port number.</param>
    /// <returns></returns>
    public IMailCredentials OnPortNumber(string portNumber)
    {
        _portNumber = portNumber;
        return this;
    }
    /// <summary>
    /// The email address to use for sending the email from.
    /// </summary>
    /// <param name="userName">The email address as configured in the SMTP/IMAP server.</param>
    /// <returns></returns>
    public IMailCredentials WithUserName(string userName)
    {
        _userName = userName;
        return this;
    }

    public IMailCredentials HostServerRequresSsl(bool serverRequiresSsl)
    {
        _serverRequiresSsl = serverRequiresSsl;
        return this;
    }

    /// <summary>
    /// Set the password associated with the userName / email address.
    /// </summary>
    /// <param name="password">The password associated with the email address to use when sending emails.</param>
    /// <returns></returns>
    public IMailer WithPassword(string password)
    {
        _password = password;

        (_mailer as Mailer).SetMailCredentials(this);

        return _mailer;
    }

    public bool HostServerRequiresSsl { get { return _serverRequiresSsl; } }

    public string PortNumber { get { return _portNumber; } set { _portNumber = value; } }

    public string HostServer { get { return _hostServer; } set { _hostServer = value; } }

    public string Password { get { return _password; } set { _password = value; } }

    public string UserName { get { return _userName; } set { _userName = value; } }
}
