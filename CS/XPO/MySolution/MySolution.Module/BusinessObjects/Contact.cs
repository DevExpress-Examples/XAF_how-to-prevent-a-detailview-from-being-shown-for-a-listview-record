using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace MySolution.Module.BusinessObjects {
    [DefaultClassOptions]

    public class Contact : BaseObject {
        public Contact(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }
        string _firstName;
        public string FirstName {
            get {
                return _firstName;
            }
            set {
                SetPropertyValue(nameof(FirstName), ref _firstName, value);
            }
        }
        string _lastName;
        public string LastName {
            get {
                return _lastName;
            }
            set {
                SetPropertyValue(nameof(LastName), ref _lastName, value);
            }
        }
        int _age;
        public int Age {
            get {
                return _age;
            }
            set {
                SetPropertyValue(nameof(Age), ref _age, value);
            }
        }

    }
}