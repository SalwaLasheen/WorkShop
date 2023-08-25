using Secure.Presistence.Context;

namespace Secure.Application.Repository.Concrete
{
    public class WsdlRepositry : IWsdlRepositry
    {
        private readonly SqlDbContext _sqlcontext;
        readonly Dictionary<string, string> errorMesages = new();
        public WsdlRepositry(SqlDbContext sqlcontext)
        {
            _sqlcontext = sqlcontext;
        }

        public void CreateResponse(ResponseWsdl responseWsdl)
        {
            ArgumentNullException.ThrowIfNull((responseWsdl));
            try
            {

                _sqlcontext.ResponseWsdls.Add(responseWsdl);
                _sqlcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMesages.Add("Response Wsdl", ex.InnerException.ToString());
            }
            finally
            {
                //  _sqlcontext.Dispose();
            }
        }

        public Task<ResponseWsdl> GetResponseByDial(string dial)
        {
            var response = _sqlcontext.ResponseWsdls.ToList();
            return Task.FromResult(response.FirstOrDefault());

        }
    }
}
