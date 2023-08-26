namespace Secure.Application.Repository.Interface
{
    public interface IWsdlRepositry
    {
        void CreateResponse(ResponseWsdl responseWsdl);
        Task<List<ResponseWsdl>> GetResponseByDial(string dial);

    }
}
