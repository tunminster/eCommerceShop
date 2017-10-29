using eCommerceShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace eCommerShop.WindowService
{
    public partial class MessageService : ServiceBase
    {
        private Timer _timer;
        private int _interval;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMessageManager _messageManager;

        public MessageService(IMessageManager messageManager)
        {
            InitializeComponent();
            _messageManager = messageManager;
        }

        public void Start(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            log.Info("Message service started.");
            _timer = new Timer();
            _timer.Interval = ServiceConfig.WakeUpInterval;
            _interval = 0;
            _timer.Elapsed += TimerCallback;
            _timer.Start();
        }

        protected override void OnStop()
        {
            log.Info("Message service stopped.");
            _timer.Stop();
            _timer.Elapsed -= TimerCallback;
            _timer.Dispose();
        }

        private void TimerCallback(object sender, ElapsedEventArgs e)
        {
            UpdateTimer();

            if(!_messageManager.IsProcessRunning())
            {
                log.Info("MessageManager started.");

                try
                {
                    _messageManager.DoProcess();
                }
                catch(Exception ex)
                {
                    log.Error(ex.Message);
                }
                finally
                {
                    log.Info("MessageManager process finished.");
                }
            }
        }

        protected void UpdateTimer()
        {
            _interval++;
            if (_interval > ServiceConfig.TimerInterval)
                _interval = 1;
        }
    }
}
