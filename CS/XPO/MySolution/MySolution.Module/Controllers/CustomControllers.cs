using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace dxTestSolution.Module.Controllers {
    public class CustomController : ViewController {
        protected override void OnActivated() {
            base.OnActivated();
            ListViewProcessCurrentObjectController targetController = Frame.GetController<ListViewProcessCurrentObjectController>();
            if (targetController != null) {
                targetController.ProcessCurrentObjectAction.Enabled["MyReason"] = false;
            }
        }
    }
}
