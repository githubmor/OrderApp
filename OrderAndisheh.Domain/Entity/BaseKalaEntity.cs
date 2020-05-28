namespace OrderAndisheh.Domain.Entity
{
    public class BaseKalaEntity
    {
        public BaseKalaEntity(string Name, string Code, string FaniCode)
        {
            this._name = Name;
            this._code = Code;
            this._faniCode = FaniCode;
        }
        private string _name;
        private string _code;
        private string _faniCode;
        public string Name { get { return _name; } }
        public string Code { get { return _code; } }
        public string FaniCode { get { return _faniCode; } }
    }
}