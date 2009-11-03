using System;
using System.Net;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace Inflectra.SpiraTest.AddOns.SpiraTestMSTestExtension
{
    /// <summary>
    /// The aspect that allows you to override the default SpiraTest configuration settings for the test fixture
    /// </summary>
    public class SpiraTestConfigurationAspect : TestAspect<SpiraTestConfigurationAttribute>, IMessageSink, ITestAspect
    {
        protected string url;

        #region Fields

        private IMessageSink _nextSink;

        #endregion // Fields

        #region IMessageSink Members

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessage SyncProcessMessage(IMessage msg)
        {
            if (msg == null) throw new ArgumentNullException("msg");

            SpiraTestConfigurationAttribute TestClassAttribute = GetAttribute(msg);
            if (TestClassAttribute != null)
            {
                //Get the URL, Login, Password, ProjectId and ReleaseId from the test class attribute
                string url = TestClassAttribute.Url;
                string login = TestClassAttribute.Login;
                string password = TestClassAttribute.Password;
                int projectId = TestClassAttribute.ProjectId;
                Nullable<int> releaseId = TestClassAttribute.ReleaseId;
                Nullable<int> testSetId = TestClassAttribute.TestSetId;
            }

            IMessage returnMessage = _nextSink.SyncProcessMessage(msg);

            return returnMessage;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new InvalidOperationException();
        }

        public IMessageSink NextSink
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
            get { return _nextSink; }
        }

        #endregion // IMessageSink Members

        #region ITestAspect

        public void AddMessageSink(IMessageSink messageSink)
        {
            _nextSink = messageSink;
        }

        #endregion // ITestAspect
    }
}
