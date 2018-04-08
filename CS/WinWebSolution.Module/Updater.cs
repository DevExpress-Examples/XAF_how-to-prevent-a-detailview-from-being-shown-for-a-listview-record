using System;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace WinWebSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Person p = ObjectSpace.CreateObject<Person>();
            p.FirstName = "Dennis";
            p.LastName = "Garavsky";
            p.Birthday = new DateTime(1987, 2, 23);
            ObjectSpace.CommitChanges();          
        }
    }
}
