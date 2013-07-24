namespace Reactive.EventAggregator.Net35.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using NUnit.Framework;

    [TestFixture]
    public class EventBusTests
    {
        public class ControlLoaded
        {
            public ControlLoaded(Control control)
            {
                this.Control = control;
            }

            public Control Control { get; private set; }
        }

        public class MainForm : Form
        {
            protected SubUserControl SubControl;

            public IList<Control> LoadedControls = new List<Control>();

            public MainForm()
            {
                EventBus.Instance.GetEvent<ControlLoaded>().Subscribe(new Observer<ControlLoaded>(x => this.LoadedControls.Add(x.Control)));

                this.SubControl = new SubUserControl();
            }
        }

        public class SubUserControl : UserControl
        {
            public SubUserControl()
            {
                this.OnLoad(EventArgs.Empty);
            }

            protected override void OnLoad(EventArgs e)
            {
                EventBus.Instance.Publish(new ControlLoaded(this));
            }
        }

        [Test]
        public void Load_WhenUserControlLoaded_ParentFormShouldHaveProcessedEvent()
        {
            var f = new MainForm();

            Assert.That(f.LoadedControls.All(x => x.GetType() == typeof(SubUserControl)));
        }
    }
}