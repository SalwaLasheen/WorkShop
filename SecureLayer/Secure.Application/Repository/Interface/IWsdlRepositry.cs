using CommonComponent.Application.Dtos.Response;

namespace Secure.Application.Repository.Interface
{
    public interface IWsdlRepositry
    {
        void CreateResponse(ResponseWsdl responseWsdl);
       Task<ResponseWsdl> GetResponseByDial(string dial);

    }
}
