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

namespace eCommerceShop.Ws
{
    partial class MessageService : ServiceBase
    {
        private Timer _timer;
        private int _interval;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MessageService()
        {
            InitializeComponent();
        }

        public void Start(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            log.Info("Message service started.");
            _timer = new Timer();
            _timer.Interval = ServiceConfig.WakeUpInterval;
            _interval = 0;
            _timer.Elapsed += TimerCallback;

        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        private void TimerCallback(object sender, ElapsedEventArgs e)
        {
            UpdateTimer();

            //if()
        }

        protected void UpdateTimer()
        {
            _interval++;
            if (_interval > ServiceConfig.TimerInterval)
                _interval = 1;
        }
    }
}
